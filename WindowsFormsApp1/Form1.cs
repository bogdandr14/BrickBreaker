using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
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

            serialPort1.Open();
        }

        private void tBoxDataOutButton(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && serialPort1.IsOpen)
            {
                serialPort1.Write("L");
            }
            if (e.KeyCode == Keys.Right && serialPort1.IsOpen)
            {
                serialPort1.Write("R");
            }
        }
    }
}
