
namespace BrickBreakerGame
{
    partial class BrickBreakerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrickBreakerForm));
            this.picPaddle = new System.Windows.Forms.PictureBox();
            this.picBall = new System.Windows.Forms.PictureBox();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblStart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).BeginInit();
            this.SuspendLayout();
            // 
            // picPaddle
            // 
            this.picPaddle.BackColor = System.Drawing.Color.Transparent;
            this.picPaddle.Image = ((System.Drawing.Image)(resources.GetObject("picPaddle.Image")));
            this.picPaddle.Location = new System.Drawing.Point(440, 520);
            this.picPaddle.Name = "picPaddle";
            this.picPaddle.Size = new System.Drawing.Size(120, 20);
            this.picPaddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPaddle.TabIndex = 0;
            this.picPaddle.TabStop = false;
            // 
            // picBall
            // 
            this.picBall.BackColor = System.Drawing.Color.Transparent;
            this.picBall.Image = ((System.Drawing.Image)(resources.GetObject("picBall.Image")));
            this.picBall.Location = new System.Drawing.Point(488, 400);
            this.picBall.Name = "picBall";
            this.picBall.Size = new System.Drawing.Size(24, 24);
            this.picBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBall.TabIndex = 1;
            this.picBall.TabStop = false;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.Color.Transparent;
            this.lblGameOver.Font = new System.Drawing.Font("Cambria", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.Color.Firebrick;
            this.lblGameOver.Location = new System.Drawing.Point(325, 240);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(353, 75);
            this.lblGameOver.TabIndex = 2;
            this.lblGameOver.Text = "Game Over";
            this.lblGameOver.UseMnemonic = false;
            this.lblGameOver.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "element_blue_rectangle.png");
            this.imageList1.Images.SetKeyName(1, "element_green_rectangle.png");
            this.imageList1.Images.SetKeyName(2, "element_grey_rectangle.png");
            this.imageList1.Images.SetKeyName(3, "element_purple_rectangle.png");
            this.imageList1.Images.SetKeyName(4, "element_red_rectangle.png");
            this.imageList1.Images.SetKeyName(5, "element_yellow_rectangle.png");
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.Orange;
            this.lblStart.Location = new System.Drawing.Point(275, 190);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(452, 57);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Press space to start";
            this.lblStart.UseMnemonic = false;
            // 
            // BrickBreakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.picBall);
            this.Controls.Add(this.picPaddle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(492, 520);
            this.MaximizeBox = false;
            this.Name = "BrickBreakerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brick Breaker";
            this.Load += new System.EventHandler(this.BrickBreakerForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BrickBreakerForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrickBreakerForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BrickBreakerForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPaddle;
        private System.Windows.Forms.PictureBox picBall;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblStart;
    }
}

