using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace StreetViewer
{
    class HeadingBuffer
    {

        private string url = "http://maps.googleapis.com/maps/api/streetview";
        private static string imageSize = "640x640";
        private static string locationX = "40.720032";
        private static string locationY = "73.988354";
        private static string isSensor = "false";
        private static string apiKey = "AIzaSyBYW8xSd4dCNkMsxC4Xc3cFXgQG83RN12w";
        private static int heading = 0;
        private static string pitch = "0";




        public PictureBox PicImage{get;set;}

        private bool ImageLoadCalled { get; set; }


        public HeadingBuffer(int _heading)
        {

            heading = _heading;

            ImageLoadCalled = false;


            PicImage = new PictureBox();
            PicImage.Load(string.Format("{0}?size={1}&location={2},%20-{3}&sensor={4}&key={5}&heading={6}&pitch={7}", url, imageSize, locationX, locationY, isSensor, apiKey, heading.ToString(), pitch));
            //http://maps.googleapis.com/maps/api/streetview?size=640x640&location=40.720032,%20-73.988354&sensor=false&key=AIzaSyBYW8xSd4dCNkMsxC4Xc3cFXgQG83RN12w&heading=0&pitch=0

        }



    }
}
