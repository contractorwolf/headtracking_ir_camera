using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;

namespace StreetViewer
{
    public class HeadingImage
    {

        public Image FormImage { get; set; }
        public string URL { get; set; }
        public TimeSpan downloadTime { get; set; }



        const string url = "http://maps.googleapis.com/maps/api/streetview";
        const string apiKey = "AIzaSyBYW8xSd4dCNkMsxC4Xc3cFXgQG83RN12w";
        const string isSensor = "false";
        const string imageSize = "640x640";



        //private static string locationX = "40.720032";
        //private static string locationY = "73.988354";


        private static int heading = 0;
        private static string pitch = "0";


        private DateTime startTime;
        private DateTime endTime;






        public HeadingImage(int _heading, string location)
        {
            URL = string.Format("{0}?size={1}&location={2}&sensor={3}&key={4}&heading={5}&pitch={6}", url, imageSize, location, isSensor, apiKey, _heading.ToString(), pitch);

            StartDownload();

        }

        public void StartDownload()
        {

            startTime = DateTime.Now;

            WebRequest img = WebRequest.Create(URL);

            //this takes all the time
            WebResponse resImg = img.GetResponse();

            FormImage = Image.FromStream(resImg.GetResponseStream());

            endTime = DateTime.Now;

            downloadTime = startTime - endTime;

            //PicImage.Load(string.Format("{0}?size={1}&location={2},%20-{3}&sensor={4}&key={5}&heading={6}&pitch={7}", url, imageSize, locationX, locationY, isSensor, apiKey, heading.ToString(), pitch));
        }



    }

}
