using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Drawing.Imaging;

namespace WinForm_Xbee_Receiver
{
    public partial class Form1 : Form
    {

        public static SerialPort XBEE = null;
        public static byte[] rx_data;


        public static int bytesToRead = 0;
        public static int read_count = 0;
        public static int count = 0;

        public static double freq = 0;


        private static int dotSize = 20;


        public static DateTime timeDiff;

        public static TimeSpan span;

        private static StringBuilder message;
        private static StringBuilder errorMessage;


        private static int totalWidth = 1024;
        private static int totalHeight = 768;


        private int totalCount = 0;
        private int missCount = 0;


        private static int currentX = 0;
        private static int currentY = 0;

        private static int lastX = 0;
        private static int lastY = 0;

        private static int secondLastX = 0;
        private static int secondLastY = 0;




        private static int totalMissedByteLength = 0;





        //private Bitmap b = new Bitmap(256, 192, PixelFormat.Format24bppRgb);
        private Bitmap b = new Bitmap(totalWidth, totalHeight, PixelFormat.Format24bppRgb);

        private Graphics g;


        private StringBuilder point = new StringBuilder();



        public Form1()
        {
            InitializeComponent();

            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            message = new StringBuilder();
            errorMessage = new StringBuilder();



            XBEE = new SerialPort("COM20", 57600);
            XBEE.Open();
            XBEE.DataReceived += new SerialDataReceivedEventHandler(XBEE_DataReceived);

            timeDiff = DateTime.Now;

            //g.Clear(Color.Black);
            //bottom right point
            //g.DrawEllipse(new Pen(Color.Orange), 253, 188, 1, 1);

        }

        private void XBEE_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {                
            totalCount++;
            
            try
            {
                rx_data = new byte[XBEE.BytesToRead];
                
                // read the data
                read_count = XBEE.Read(rx_data, 0, rx_data.Length);

                bytesToRead = rx_data.Length;

                if (bytesToRead > 1)
                {//greater than 1
                    if (bytesToRead % 2 == 0)
                    {//greater than 1 and even (2, 4, 6...)
                        currentX = (int)rx_data[0];
                        currentY = (int)rx_data[1];


                        message.Clear();

                        message.Append(currentX.ToString());
                        message.Append(",");
                        message.Append(currentY.ToString());
                        
                        message.Append(":");
                        message.Append(bytesToRead.ToString());


                        this.Invoke(new EventHandler(WriteData));

                    }
                    else
                    {//greater than 1 and odd (3, 5, 7...)



                    }

                }
                else
                {
                    //skip, just one number showing
                    message.Clear();

                    if(rx_data.Length>0){
                        message.Append(((int)rx_data[0]).ToString());
                    }

                    totalMissedByteLength = totalMissedByteLength + rx_data.Length;

                    missCount++;
                    this.Invoke(new EventHandler(WriteMiss)); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void WriteMiss(object sender, EventArgs e)
        {
           // lbReadings.Items.Add(message.ToString());

            int percent = (int)((missCount * 100) / totalCount);


            errorMessage.Clear();


            errorMessage.Append(" bytes received: ");
            errorMessage.Append(bytesToRead.ToString());
            errorMessage.Append(" [avg: ");
            errorMessage.Append((int)totalMissedByteLength/missCount);
            errorMessage.Append("] ");

            errorMessage.Append(missCount.ToString());
            errorMessage.Append("/");
            errorMessage.Append(totalCount.ToString());
            errorMessage.Append(" [");
            errorMessage.Append(percent.ToString());
            errorMessage.Append(" percent lost] ");





            toolStripStatusLabel1.Text =  errorMessage.ToString();
       
        
        }

        private void WriteData(object sender, EventArgs e)
        {
                g.Clear(Color.Black);


                int xPoint = (totalWidth / 2) + ((90 - currentX) * 5);
                int yPoint = (totalHeight / 2) - ((90 - currentY) * 5);

            //avg last 2 readings to smooth data
                xPoint = (xPoint + lastX + secondLastX) / 3;
                yPoint = (yPoint + lastY + secondLastY) / 3;

                //xPoint = (xPoint + lastX) / 2;
                //yPoint = (yPoint + lastY) / 2;



                DrawPinPointAtColor(xPoint, yPoint, Color.Yellow);
                g.DrawEllipse(new Pen(Color.Green, 10), (xPoint - 5), yPoint - 5, 10, 10);

                g.DrawLine(new Pen(Color.Red, 2), totalWidth / 2, totalHeight / 2, xPoint, yPoint);


                //lbReadings.Items.Add(message.ToString());
                txtLastMessage.Text = message.ToString();
                lbReadings.Items.Add(message.ToString());


                //*******************************************
                //draw blue x
                DrawPinPointAtColor(totalWidth / 2, totalHeight / 2, Color.Blue);

                //draw blue center dot
                g.DrawEllipse(new Pen(Color.Blue, 10), (totalWidth / 2) - 10, (totalHeight / 2) - 10, dotSize, dotSize);
            ////*******************************************





                span = DateTime.Now - timeDiff;

                freq = span.TotalMilliseconds;

                timeDiff = DateTime.Now;

                txtFrequency.Text = Convert.ToInt32(freq).ToString();






                txtMessageCount.Text = totalCount.ToString();
                txtTimeStamp.Text = DateTime.Now.ToString();



                pbIR.Image = b;

                secondLastX = lastX;
                secondLastY = lastY;

                lastX = xPoint;
                lastY = yPoint;


        }



      


        private void DrawPinPointAt(int x, int y)
        {

            g.DrawLine(new Pen(Color.Blue, 1), x, 0, x, totalHeight);
            g.DrawLine(new Pen(Color.Blue, 1), 0, y, totalWidth, y);

        }

        private void DrawPinPointAtColor(int x, int y, Color lineColor)
        {

            g.DrawLine(new Pen(lineColor, 1), x, 0, x, totalHeight);
            g.DrawLine(new Pen(lineColor, 1), 0, y, totalWidth, y);

        }

        private void btnShowReadings_Click(object sender, EventArgs e)
        {
            if (lbReadings.Visible == true)
            {
                lbReadings.Visible = false;

                btnShowReadings.Text = "show";
            }
            else
            {
                lbReadings.Visible = true;

                btnShowReadings.Text = "hide";

            }
        }

        private void btnClearReadings_Click(object sender, EventArgs e)
        {
            lbReadings.Items.Clear();
        }


    }
}
