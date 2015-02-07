using System;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using GHIElectronics.NETMF.FEZ;

namespace FEZ_Mini_Centered_IR_Cam
{
    public class Program
    {
        public static void Main()
        {
            //turn off gc
            Debug.EnableGCMessages(false);


            

            // Blink board LED
            //bool ledState = false;

            double orientationX = 0;
            double orientationY = 0;

            DateTime startTime;
            DateTime endTime;

            int delay = 0;//to slow it down for testing


            //led indicator to tell if the cam sees 3 IR dots
            //OutputPort led = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, ledState);


            OutputPort pinPowerLED = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di2, true);
            OutputPort pinPowerGND = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di3, false);

            OutputPort pinCaptureLED = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di4, false);
            OutputPort pinCaptureGND = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di5, false);


            //wiicam instance
            WiimoteCamera cam = new WiimoteCamera();


            IRDot ir1 = new IRDot();
            IRDot ir2 = new IRDot();
            IRDot ir3 = new IRDot();


            //IRAnalysis dotReader = new IRAnalysis();
            DotEvaluator dotEval = new DotEvaluator();


            Xbee xbee = new Xbee();
            xbee.Send("\r\r***IRCamera Restarted***");

            Thread.Sleep(3000);

            int index = 0;
            while (true)
            {

                startTime = DateTime.Now;


                cam.readData();

                ir1.LoadIRDot(cam.Blob1.x, cam.Blob1.y, cam.Blob1.size);
                ir2.LoadIRDot(cam.Blob2.x, cam.Blob2.y, cam.Blob2.size);
                ir3.LoadIRDot(cam.Blob3.x, cam.Blob3.y, cam.Blob3.size);

                //dotReader.LoadDots(ir1, ir2, ir3);
                dotEval.LoadDots(ir1, ir2, ir3);

                if (dotEval.valid)
                {
                    //orientationX = dotReader.servoX;
                    //orientationY = dotReader.servoY;
                    orientationX = dotEval.servoX;
                    orientationY = dotEval.servoY;






                    // xbee.Send(headAngle.ToString());
                    xbee.SendByteValues((int)orientationX, (int)orientationY);

                    
                    //Debug.Print("sent byte values: " + orientationX.ToString() + ", " + orientationY.ToString() + " " + index.ToString());

                    pinCaptureLED.Write(true);
                }
                else
                {
                    Debug.Print("invalid: " + index.ToString());

                    pinCaptureLED.Write(false);

                }

                Thread.Sleep(delay);

                endTime = DateTime.Now;

                Debug.Print((startTime - endTime).Milliseconds.ToString());
                index++;
            }
        }

    }
}
