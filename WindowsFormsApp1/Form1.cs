using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string toSend;
        public static bool _continue = false;
        private Thread sendThread;
        private static SerialPort _serialPort = null;

        public Form1()
        {
            InitializeComponent();
            sendThread = new Thread(SendData);
            sendThread.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxComPort.Items.AddRange(ports);
            cBoxComPort2.Items.AddRange(ports);

            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
            serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

            _serialPort = serialPort1;

            _serialPort.Open();
            _continue = true;

        }

        private void tBoxDataOutButton(object sender, KeyEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                switch(e.KeyCode)
                {
                    case Keys.Left:
                        toSend = "L";
                        break;
                    case Keys.Right:
                        toSend = "R";
                        break;
                    case Keys.Space:
                        toSend = "S";
                        break;
                    default:
                        break;
                }
            }
        }

        private void tBoxDataOut_KeyUp(object sender, KeyEventArgs e)
        {
            toSend = "N";
        }

        public static void SendData()
        {
            while (!_continue)
            {
                Thread.Sleep(50);
            }

            while (_continue)
            {
                _serialPort.WriteLine(toSend);
                Thread.Sleep(50);
            }
        }
    }
}
