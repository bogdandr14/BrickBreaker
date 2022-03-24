using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace BrickBreakerGame
{
    public partial class BrickBreakerForm : Form
    {
        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        SerialPort _serialPort;
        bool _continue;
        int ballSpeed = 5;
        int ballDX = 1;
        int ballDY = 1;

        int paddleSpeed = 10;
        int inputDX = 0;

        Image[,] Blocks;
        int blockRows;
        int blockCols;
        int blockCount = 0;
        bool gameRunning = false;
        Thread readThread;

        Random rand = new Random();
        public BrickBreakerForm()
        {
            InitializeComponent();
            InitializeSerialPortRead();

            readThread = new Thread(Read);
            readThread.Start();
        }

        ~BrickBreakerForm()
        {
            _continue = false;
        }
        private void ShowMenu(bool show = true)
        {
            //lblStart.Visible = show;
            //lblGameOver.Visible = show;
            if (!show)
            {
                InitializeGame();
            }
            gameRunning = !show;
            gameTimer.Enabled = !show;
            Invalidate();
        }

        private int MakeBlocks(int rows, int cols)
        {
            Blocks = new Image[rows, cols];
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    int index = rand.Next(0, imageList1.Images.Count);
                    Blocks[i, j] = imageList1.Images[index];
                }
            }
            return rows * cols;
        }

        private void MovePaddle(int newXPos)
        {
            if (newXPos < 0)
            {
                newXPos = 0;
            }
            else if (newXPos > ClientRectangle.Width - picPaddle.Width)
            {
                newXPos = ClientRectangle.Width - picPaddle.Width;
            }
            picPaddle.Left = newXPos;
        }

        private void BrickBreakerForm_Load(object sender, EventArgs e)
        {
            InitializeGame();

            gameTimer.Interval = 16; //60fps
            gameTimer.Tick += GameTimer_Tick;
        }

        private void InitializeGame()
        {
            MovePaddle((ClientRectangle.Width - picPaddle.Width) / 2);

            MoveBall((ClientRectangle.Width - picBall.Width) / 2, (ClientRectangle.Height - picBall.Height) / 3 * 2);

            blockRows = 7;
            blockCols = imageList1.Images.Count * 2;
            blockCount = MakeBlocks(blockRows, blockCols);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            MovePaddle(picPaddle.Left + inputDX);
            MoveBall(picBall.Left + ballSpeed * ballDX, picBall.Top + ballSpeed * ballDY);
            DetectCollisionWithPaddle();
            DetectCollisionWithBrick();
        }

        private void MoveBall(int newXPos, int newYPos)
        {
            Point ballPos = new Point(newXPos, newYPos);
            picBall.Location = ballPos;

            if (ballPos.X < 0 || ballPos.X > ClientRectangle.Width - picBall.Width)
            {
                ballDX = -ballDX;
            }
            if (ballPos.Y < 0)
            {
                ballDY = -ballDY;
            }
            if (ballPos.Y > ClientRectangle.Height)
            {
                //GAME OVER
                ShowMenu();
            }
        }

        private void DetectCollisionWithPaddle()
        {
            if (picBall.Bounds.IntersectsWith(picPaddle.Bounds))
            {
                ballDY = -ballDY;
            }
        }

        private void DetectCollisionWithBrick()
        {
            Point ballPos = picBall.Location;
            Point[] ballCornersPoints = new Point[]
            {
                new Point(ballPos.X, ballPos.Y),
                new Point(ballPos.X + picBall.Width, ballPos.Y),
                new Point(ballPos.X, ballPos.Y + picBall.Height),
                new Point(ballPos.X +picBall.Width, ballPos.Y + picBall.Height),
            };
            int imgWidth = imageList1.ImageSize.Width;
            int imgHeight = imageList1.ImageSize.Height;

            int initialXpos = (ClientRectangle.Width - imgWidth * blockCols) / 2;
            int initialYpos = 30;

            int blockHitCount = 0;
            foreach (Point bollCorner in ballCornersPoints)
            {
                int currentBrickRow = (bollCorner.Y - initialYpos) / imgHeight;
                int currentBrickCol = (bollCorner.X - initialXpos) / imgWidth;
                if (currentBrickCol >= 0 && currentBrickCol < blockCols && currentBrickRow >= 0 && currentBrickRow < blockRows)
                {
                    if (Blocks[currentBrickRow, currentBrickCol] != null)
                    {
                        Blocks[currentBrickRow, currentBrickCol] = null;
                        Rectangle rectangleToInvalidate = new Rectangle()
                        {
                            X = initialXpos + currentBrickCol * imgWidth,
                            Y = initialYpos + currentBrickRow * imgHeight,
                            Width = imgWidth,
                            Height = imgHeight
                        };
                        Invalidate(rectangleToInvalidate);
                        ++blockHitCount;
                    }
                }
            }
            if (blockHitCount > 0)
            {
                ballDY = -ballDY;
                blockCount -= blockHitCount;
                if (blockCount == 0)
                {
                    ShowMenu();
                }
            }
        }

        private void BrickBreakerForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (lblStart.Visible)
            {
                return;
            }
            int imgWidth = imageList1.ImageSize.Width;
            int imgHeight = imageList1.ImageSize.Height;

            int initialXpos = (ClientRectangle.Width - imgWidth * blockCols) / 2;
            int ypos = 30;

            for (int i = 0; i < blockRows; ++i)
            {
                int xpos = initialXpos;

                for (int j = 0; j < blockCols; ++j)
                {
                    if (Blocks[i, j] != null)
                    {
                        g.DrawImage(Blocks[i, j], xpos, ypos);
                    }
                    xpos += imgWidth;
                }
                ypos += imgHeight;
            }
        }

        private void BrickBreakerForm_KeyDown(object sender, KeyEventArgs e)
        {
            /*switch (e.KeyCode)
            {
                case Keys.Space:
                    if (!gameRunning)
                    {
                        ShowMenu(false);
                    }
                    break;
                case Keys.Left:
                    if (gameRunning)
                    {
                        inputDX = -paddleSpeed;
                    }
                    break;
                case Keys.Right:
                    if (gameRunning)
                    {
                        inputDX = paddleSpeed;
                    }
                    break;
            }*/
        }

        private void BrickBreakerForm_KeyUp(object sender, KeyEventArgs e)
        {
            /* inputDX = 0;*/
        }

        public void InitializeSerialPortRead()
        {
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            

            // Create a new SerialPort object with default settings.
            _serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            _serialPort.PortName = "COM2";
            _serialPort.BaudRate = 9600;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 50;
            _serialPort.WriteTimeout = 50;

            _serialPort.Open();
            _continue = true;
        }
        public void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    switch (message)
                    {
                        case "S":
                            if (!gameRunning)
                            {
                                ShowMenu(false);
                            }
                            break;
                        case "L":
                            if (gameRunning)
                            {
                                inputDX = -paddleSpeed;
                            }
                            break;
                        case "R":
                            if (gameRunning)
                            {
                                inputDX = paddleSpeed;
                            }
                            break;
                        default:
                            if (gameRunning)
                            {
                                inputDX = 0;
                            }
                            break;
                    }
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
}
