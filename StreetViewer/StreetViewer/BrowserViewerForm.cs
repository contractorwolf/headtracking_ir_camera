using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StreetViewer.Properties;
using System.IO.Ports;
using System.Diagnostics;

namespace StreetViewer
{
    public partial class BrowserViewerForm : Form
    {

        //***************************************************
        //FROM XbeeTriangleReceiver




        private StringBuilder point = new StringBuilder();
        private static StringBuilder message = new StringBuilder();
        private static StringBuilder errorMessage = new StringBuilder();
        public static DateTime timeDiff;
        public static TimeSpan span;

        public static SerialPort XBEE = null;

        public static byte[] rx_data;


        public static int bytesToRead = 0;
        public static int read_count = 0;
        public static int count = 0;
        public static double freq = 0;

        private int totalCount = 0;
        private int missCount = 0;
        private static int totalMissedByteLength = 0;





        private static int currentX = 0;
        private static int currentY = 0;
        private static int lastX = 0;
        private static int lastY = 0;
        private static int secondLastX = 0;
        private static int secondLastY = 0;







        //FROM XbeeTriangleReceiver
        //***************************************************



        public BrowserViewerForm()
        {
            InitializeComponent();
        }

        private void BrowserViewerForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "application started: " + DateTime.Now.ToString();


            txtLocation.Text = Settings.Default.LastLocation;


            txtHeading.Text = Settings.Default.LastHeading;


            LoadLocation(txtLocation.Text);

            XBEE = new SerialPort("COM20", 57600);
            XBEE.Open();
            XBEE.DataReceived += new SerialDataReceivedEventHandler(XBEE_DataReceived);

            timeDiff = DateTime.Now;

            txtHeading.Focus();


            panel1.Parent = wbMainBrowser;

        }


        private void LoadLocation(string loc)
        {


            wbMainBrowser.DocumentText = "<!DOCTYPE html>" +
            "<html>" +
            "  <head>" +
            "    <meta charset='utf-8'>" +
                //"    <title>Street View controls</title>" +
            "    <style>html, body {  height: 100%;  margin: 0;  padding: 0;}#map-canvas, #map_canvas {  height: 100%;}@media print {  html, body { height: auto;  }  #map-canvas, #map_canvas { height: 650px;}} #panel {  position: absolute;  top: 5px;  left: 50%;  margin-left: -180px;  z-index: 5;  background-color: #fff;  padding: 5px;  border: 1px solid #999;}</style>" +
            "    <script src='https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false'></script>" +
            "    <script>" +

            "        var panorama;" +


            "        function initialize() {" +
            "          var fenway = new google.maps.LatLng(" + loc + ");" +
                //"          // Note: constructed panorama objects have visible: true" +
                //"          // set by default." +
            "          var panoOptions = {" +
            "            position: fenway," +
            "            addressControlOptions: { }," +
            "            linksControl: false," +
            "            panControl: false," +
            "            zoomControlOptions: {}," +
            "            enableCloseButton: false" +
            "          };" +
            "          panorama = new google.maps.StreetViewPanorama(document.getElementById('map-canvas'), panoOptions);" +

            "          panorama.setPov({ heading: 180, pitch: 0 });" +


            "        }" +
            "        function SetHeadingAndPitch(_heading,_pitch) {" +
            "          panorama.setPov({ heading: _heading, pitch: _pitch });" +
            "        }" +


            "        google.maps.event.addDomListener(window, 'load', initialize);" +
            "    </script>" +
            "  </head>" +
            "  <body><div id='map-canvas'></div></body>" +
            "</html>";


        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            LoadLocation(txtLocation.Text);
            toolStripStatusLabel1.Text = "location changed to: " + txtLocation.Text;

            Settings.Default.LastLocation = txtLocation.Text;
            Settings.Default.LastHeading = txtHeading.Text;

            Settings.Default.Save();
            

        }

        private void btnChangeHeading_Click(object sender, EventArgs e)
        {

            int newHeading = 0;

            int.TryParse(txtHeading.Text, out newHeading);
            wbMainBrowser.Document.InvokeScript("SetHeadingAndPitch", new object[] { newHeading,0 });

            Settings.Default.LastHeading = txtHeading.Text;

            Settings.Default.Save();
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

                    if (rx_data.Length > 0)
                    {
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
            Debug.WriteLine("miss @ " + DateTime.Now);

        }


        private void WriteData(object sender, EventArgs e)
        {
            int xPoint = currentX;
            int yPoint = currentY;

            ////avg last 3 readings to smooth data
            xPoint = (xPoint + lastX + secondLastX) / 3;
            yPoint = (yPoint + lastY + secondLastY) / 3;


            txtLastMessage.Text = message.ToString();







            int modifiedX = 180 - xPoint;





            try
            {
                modifiedX = Ensure360(modifiedX, Convert.ToInt32(txtHeading.Text));
            }
            catch (Exception ex)
            {
                Debug.Print("txtHeading does not contain a number");
                modifiedX = Ensure360(modifiedX, 0);
            }

            wbMainBrowser.Document.InvokeScript("SetHeadingAndPitch", new object[] { modifiedX, (int)(90 - yPoint) });


            span = DateTime.Now - timeDiff;

            freq = span.TotalMilliseconds;

            timeDiff = DateTime.Now;



            toolStripStatusLabel1.Text = string.Format("{0} milliseconds", Math.Round(freq).ToString());


            secondLastX = lastX;
            secondLastY = lastY;

            ///just changed this from lastX = pointX, because that was averaging too much, 
            ///the most recent reading what being effected by the last 2 too much
            ///may need to go back if this doesnt work as expected
            lastX = xPoint;
            lastY = yPoint;



            panel1.Refresh();
            panel2.Refresh();




        }


        private int Ensure360(int angle, int amount)
        {

            angle = angle + amount;

            if (angle > 360)
            {
                angle = angle - 360;

            }

            if (angle < 0)
            {
                angle = angle + 360;
            }


            return(angle);
        }

        private void btnIncreaseHeading_Click(object sender, EventArgs e)
        {
            IncreaseHeading();

        }

        private void btnDecreaseHeading_Click(object sender, EventArgs e)
        {
            DecreaseHeading();
        }

        private void txtHeading_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                DecreaseHeading();
    
            }else if(e.KeyCode == Keys.Right){
                IncreaseHeading();

            }
        }


        private void DecreaseHeading()
        {
            int heading = Convert.ToInt32(txtHeading.Text);

            if (heading > 0)
            {
                heading = heading - 5;
            }
            else
            {
                heading = 360;
            }

            txtHeading.Text = heading.ToString();

        }


        private void IncreaseHeading()
        {
            int heading = Convert.ToInt32(txtHeading.Text);

            if (heading < 360)
            {
                heading = heading + 5;
            }
            else
            {
                heading = 0;
            }

            txtHeading.Text = heading.ToString();

        }

        private void BrowserViewerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                DecreaseHeading();

            }
            else if (e.KeyCode == Keys.Right)
            {
                IncreaseHeading();

            }
        }


        private void DrawHead(Graphics g, int angle)
        {


            int offset = 5;



            int width = panel1.Width - offset;// 50;
            int height = panel1.Height - offset;//50;
            int radius = (width - offset) / 2;

            Point center = new Point((width / 2) + (offset/2), (height / 2) + (offset/2));


            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.White);

            g.FillEllipse(myBrush, 0, 0, width, height);



            //angle = RotateAngle(angle, -90);
            Point endpoint = FindEndpointOnCircle(center, radius - 5, angle);


            Pen blackPen = new Pen(Brushes.Black);
            blackPen.Width = 8.0F;
            blackPen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
            blackPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;





            g.DrawLine(blackPen, center, endpoint);



            string drawString = "head";
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 32;
            float y = 55;
            g.DrawString(drawString, drawFont, drawBrush, x, y);


        }



        private void DrawBody(Graphics g, int angle)
        {


            int offset = 5;



            int width = panel2.Width - offset;// 50;
            int height = panel2.Height - offset;//50;
            int radius = (width - offset) / 2;

            Point center = new Point((width / 2) + (offset/2), (height / 2) + (offset/2));


            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.White);

            g.FillEllipse(myBrush, 0, 0, width, height);



            //angle = RotateAngle(angle, -90);
            Point endpoint = FindEndpointOnCircle(center, radius - 5, 360- angle);


            Pen blackPen = new Pen(Brushes.Black);
            blackPen.Width = 8.0F;
            blackPen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
            blackPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;





            g.DrawLine(blackPen, center, endpoint);


            string drawString = "body";
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 32;
            float y = 55;
            g.DrawString(drawString, drawFont, drawBrush, x, y);


        }



        private int RotateAngle(int angle, int amount)
        {
            angle = angle + amount;

            if (angle > 360) { angle = angle - 360; }
            else if (angle < 0) { angle = angle + 360; }

            return (angle);
        }

        private Point FindEndpointOnCircle(Point origin, int radius, int angle)
        {
            double x = origin.X + (radius * Math.Cos(angle * Math.PI / 180F));
            double y = origin.Y - (radius * Math.Sin(angle * Math.PI / 180F));

            return new Point((int)x, (int)y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {



            int angle = lastX;// + 90;// -90;



            DrawHead(e.Graphics, angle);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {



            int angle = Convert.ToInt32(txtHeading.Text); ;// + 90;// -90;



            DrawBody(e.Graphics, angle);
        }


    }
}
