using System;
using System.Text;
using GHIElectronics.NETMF.System;
using Microsoft.SPOT;


class DotEvaluator
{
    //public accessors
    public double scaledDeltaX { get; set; }
    public double scaledDeltaY { get; set; }

    public double servoX { get; set; }
    public double servoY { get; set; }


    public bool valid { get; set; }

    //private
    //private IRDot topIR;//from ir cam
    //private IRDot bottomIR;//from ir cam
    //private IRDot backIR;//from ir cam
    //private IRDot centerIR;//evaluated



    private IRDot leftIR;//from ir cam
    private IRDot rightIR;//from ir cam
    private IRDot frontIR;//from ir cam
    private IRDot centerIR;//evaluated





    private double angleX;
    private double angleY;
    private double triangleWidth;





    //constructor
    public DotEvaluator()
    {

    }


    public void LoadDots(IRDot ir1, IRDot ir2, IRDot ir3)
    {
        GetSensors(ir1, ir2, ir3);

        if (this.valid)
        {
            GetCenter();
            GetAngles();
            GetTriangleWidth();
            GetScaledValues();
            GetServoValues();
        }
    }



    private void GetScaledValues()
    {//calculates the scaled values (based on triangle height)
        //this.scaledDeltaX = Math.Round(1000 * (angleX / triangleHeight));
        //this.scaledDeltaY = Math.Round(1000 * (angleY / triangleHeight));

        //when it errors here that means the camera has slipped
        //check the camera connection to the board
        //********************************************
        this.scaledDeltaX = angleX / triangleWidth;
        this.scaledDeltaY = angleY / triangleWidth;
        //********************************************


    }


    private void GetServoValues()
    {//calculates the servo values (based on scaled values)

        this.servoX = (int)System.Math.Round(90 + (340 * scaledDeltaX));
        this.servoY = (int)System.Math.Round(90 - (400 * scaledDeltaY));

    }





    private void GetTriangleWidth()
    {//calculates the height of the visible triangle (for scaling purposes)

        triangleWidth = MathEx.Sqrt(System.Math.Pow(leftIR.xPos - rightIR.xPos, 2) + System.Math.Pow(leftIR.yPos - rightIR.yPos, 2));





    }

    private void GetAngles()
    {//calculates the 
        //angleX = ((topIR.xPos + bottomIR.xPos) / 2) - backIR.xPos;
        //angleY = ((topIR.yPos + bottomIR.yPos) / 2) - backIR.yPos;
        //replace with this:
        angleX = centerIR.xPos - frontIR.xPos;
        angleY = centerIR.yPos - frontIR.yPos;
    }


    private void GetCenter()
    {//calculates the center position by taking the 
        //halfway point between the top and bottom positions
        int midX = leftIR.xPos - ((leftIR.xPos - rightIR.xPos) / 2);
        int midY = leftIR.yPos - ((leftIR.yPos - rightIR.yPos) / 2);

        centerIR = new IRDot(midX, midY);
    }


    private void GetViewpoint()
    {//gets the direction you are looking
        //not yet implemented
        //target of head direction
        //DrawDot(Color.DarkOrange, (int)Math.Round(3500 * scaledDeltaX) + centerX, (int)Math.Round(3000 * scaledDeltaY) + centerY);

        //centerIR = new IRDot(midX, midY);
    }





    private void GetSensors(IRDot ir1, IRDot ir2, IRDot ir3)
    {//figures out the top, bottom, and back ir's by comparing their y values
        //test to make sure there are 3 dots first

        if (ir1.dotSize < 15 && ir2.dotSize < 15 && ir3.dotSize < 15)
        {//dotSize of 15 means that the IRDot is not seen by the sensor
            //3 dots must be seen for this to be a valid reading
            this.valid = true;

            if (ir1.xPos < ir2.xPos)
            {// 1 < 2
                // 1,2,3 or 1,3,2 or 3,1,2

                if (ir2.xPos < ir3.xPos)
                {// 2 < 3
                    // 1,2,3
                    leftIR = ir1;
                    frontIR = ir2;
                    rightIR = ir3;

                }
                else
                {// 2 > 3
                    // 1,3,2 or 3,1,2
                    if (ir1.xPos < ir3.xPos)
                    {// 1 < 3
                        // 1,3,2
                        leftIR = ir1;
                        frontIR = ir3;
                        rightIR = ir2;
                    }
                    else
                    {// 1 > 3

                        // 3,1,2
                        leftIR = ir3;
                        frontIR = ir1;
                        rightIR = ir2;

                    }
                }
            }
            else
            {// 2 > 1
                // 2,1,3 or 3,2,1 or 2,3,1


                if (ir1.xPos < ir3.xPos)
                {// 1 < 3 and 2 > 1

                    //NEEDS ADDITONAL IF

                    // 2,1,3
                    leftIR = ir2;
                    frontIR = ir1;
                    rightIR = ir3;

                }
                else
                {// 1 > 3
                    // 3,2,1 or 2,3,1
                    if (ir2.xPos < ir3.xPos)
                    {// 2 < 3
                        //  2,3,1
                        leftIR = ir2;
                        frontIR = ir3;
                        rightIR = ir1;

                    }
                    else
                    {// 2 > 3
                        //  3,2,1
                        leftIR = ir3;
                        frontIR = ir2;
                        rightIR = ir1;

                    }
                }
            }








            //********************************************************


            //if (ir1.yPos > ir2.yPos)
            //{// 1 > 2
            //    if (ir2.yPos > ir3.yPos)
            //    {// 2 > 3
            //        // 1,2,3
            //        topIR = ir1;
            //        backIR = ir2;
            //        bottomIR = ir3;

            //    }
            //    else
            //    {// 2 < 3
            //        // 1,3,2 or 3,1,2
            //        if (ir1.yPos > ir3.yPos)
            //        {// 1 > 3
            //            // 1,3,2
            //            topIR = ir1;
            //            backIR = ir3;
            //            bottomIR = ir2;

            //        }
            //        else
            //        {// 1 < 3
            //            // 3,1,2
            //            topIR = ir3;
            //            backIR = ir1;
            //            bottomIR = ir2;

            //        }
            //    }
            //}
            //else
            //{// 2 > 1
            //    if (ir1.yPos > ir3.yPos)
            //    {// 1 > 3
            //        // 2,1,3
            //        topIR = ir2;
            //        backIR = ir1;
            //        bottomIR = ir3;

            //    }
            //    else
            //    {// 1 < 3
            //        // 2,3,1 or 3,2,1
            //        if (ir2.yPos > ir3.yPos)
            //        {// 2 > 3
            //            //  2,3,1
            //            topIR = ir2;
            //            backIR = ir3;
            //            bottomIR = ir1;

            //        }
            //        else
            //        {// 2 < 3
            //            //  3,2,1
            //            topIR = ir3;
            //            backIR = ir2;
            //            bottomIR = ir1;

            //        }
            //    }
            //}

            //********************************************************





        }
        else
        {
            this.valid = false;





            //Debug.Print(ir1.dotSize.ToString() + ":" + ir2.dotSize.ToString() + ":" + ir3.dotSize.ToString());
        }
    }
}


