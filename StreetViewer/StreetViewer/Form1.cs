using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace StreetViewer
{
    public partial class StreetViewerForm : Form
    {

        private static int heading = 0;

        private static int maxHeading = 15;
        private static int startHeading = 0;
  



        private static DateTime startTime;
        private static DateTime endTime;




        private List<HeadingImage> hList = new List<HeadingImage>();



        public StreetViewerForm()
        {
            InitializeComponent();
        }

        private void StreetViewerForm_Load(object sender, EventArgs e)
        {
            txtLocation.Text = Properties.Settings.Default.LastLocation;



            toolStripStatusLabel5.Text = "waiting to load";
        }
        
        
       

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (heading > startHeading)
            {
                heading = heading -1;
            }
            else
            {
                heading = maxHeading;

            }
            ShowImage(heading);

        }



        private void btnRight_Click(object sender, EventArgs e)
        {
            if (heading < maxHeading)
            {
                heading = heading + 1;
            }
            else
            {
                heading = startHeading;
            }


            ShowImage(heading);

        }




        private void ShowImage(int heading)
        {
            pbMainImage.Image = hList[heading].FormImage;
            toolStripStatusLabel5.Text = string.Format("{0} image loaded: {1} in {2} seconds", heading, hList[heading].URL, hList[heading].downloadTime);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ShowImage(trackBar1.Value);


            heading = trackBar1.Value;
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {



            int outBuffer = 0;
            int outHeading = 0;
            int.TryParse(txtBufferCount.Text, out outBuffer);


          
            

            int.TryParse(txtHeading.Text, out outHeading);



            BackgroundStarter bs = new BackgroundStarter{

                Heading = outHeading,
                BufferSize = outBuffer,
                Location = txtLocation.Text
            };




            //string locationX = ; // "40.720032";
            //string locationY = txtLocationY.Text;// "73.988354";



            startTime = DateTime.Now;  
            backgroundWorker1.RunWorkerAsync(bs);


            //after this you have all the images loaded, may want to stagger this
            //LoadImages(outBuffer,outHeading);

 
















  

            toolStripStatusLabel5.Text = "loading...";//string.Format("image array downloaded in {0} milliseconds", Math.Round(-downloadTime.TotalMilliseconds).ToString());

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundStarter bs = (BackgroundStarter)e.Argument;

            List<HeadingImage> headingList = new List<HeadingImage>();

            //get heading and size






            //determine if they pass the meridian (360)
            int max = bs.Heading + bs.BufferSize;
            if (max > 360)
            {
                max = max - 360;

            }







            string location = bs.Location; // "40.720032";
            //string locationY = bs.Y;// "73.988354";


            Properties.Settings.Default.LastLocation = location;

            Properties.Settings.Default.Save();




            headingList.Clear();

            int index = 0;

            int totalLoaded = 0;


            while (index != max)
            {
                headingList.Add(new HeadingImage(index,location));
                totalLoaded++;
                backgroundWorker1.ReportProgress((int)(100 * totalLoaded) / bs.BufferSize);

                if (index < 360)
                {

                    index++;
                }
                else
                {
                    index = 0;

                }
            }



            e.Result = headingList;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;


            toolStripStatusLabel5.Text = string.Format("{0} of {1}", e.ProgressPercentage, txtBufferCount.Text);


        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            hList = (List<HeadingImage>)e.Result;


            trackBar1.Minimum = startHeading;
            trackBar1.Maximum = hList.Count - 1;
            trackBar1.Value = trackBar1.Maximum;//far right




            ShowImage(hList.Count-1);


            maxHeading = hList.Count - 1;


            endTime = DateTime.Now;

            TimeSpan downloadTime = startTime - endTime;

            toolStripStatusLabel5.Text = string.Format("list({0}) downloaded in {1} milliseconds", maxHeading.ToString(),Math.Round(-downloadTime.TotalSeconds));



        }



        public class BackgroundStarter
        {
            public int Heading { get; set; }
            public int BufferSize { get; set; }
            public string Location { get; set; }



        }
    }
}
