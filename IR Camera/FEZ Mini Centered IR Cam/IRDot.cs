using System;
using Microsoft.SPOT;


class IRDot
{

    public int xPos { get; set; }
    public int yPos { get; set; }
    public int dotSize { get; set; }



    //constructors
    public IRDot()
    {

    }

    public IRDot(int x, int y)
    {
        this.xPos = x;
        this.yPos = y;
        this.dotSize = 1;
    }


    public IRDot(int x, int y, int size)
    {
        this.xPos = x;
        this.yPos = y;
        this.dotSize = size;
    }



    public void LoadIRDot(int x, int y, int size)
    {
        this.xPos = x;
        this.yPos = y;
        this.dotSize = size;
    }




}

