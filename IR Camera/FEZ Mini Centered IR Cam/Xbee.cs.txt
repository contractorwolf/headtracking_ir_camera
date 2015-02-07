using System;
using Microsoft.SPOT;
using System.IO.Ports;
using System.Text;

class Xbee
{
    public static int write_count = 0;

    public static byte[] tx_data;//array for sending data
    //public static byte[] rx_data = new byte[10];//array for receiving data, not used here

    public static SerialPort UART = null;//defines serial port

    //constructor
    public Xbee()
    {
        UART = new SerialPort("COM2", 57600);//initialize serial port
        UART.Open();//open serial port
    }

    //public methods

    public bool Send(string message)//sends string values
    {
        //sent successful flag
        bool success = false;

        try
        {
            //clear the serial data 
            UART.Flush();

            //get the bytes of the message to be sent 
            tx_data = Encoding.UTF8.GetBytes(message);

            //send the bytes
            UART.Write(tx_data, 0, tx_data.Length);

            //set the output flag as successful
            success = true;
        }
        catch (Exception ex)
        {
            //if there is an error, sent it to the debug window (if you are connecting from visual studio)
            Debug.Print("ERROR: " + message + "/r" + ex.Message);
        }

        //record how many strings you have sent
        write_count++;

        //return flag
        return success;
    }

    public bool SendByteValues(int x, int y)//sends a byte pair (needed for headtracking)
    {
        bool success = false;

        try
        {
            //clear data
            UART.Flush();

            //gets a byte array to send
            tx_data = new byte[] { (byte)x, (byte)y };

            //sends byte array
            UART.Write(tx_data, 0, tx_data.Length);

            //flag as successful
            success = true;
        }
        catch (Exception ex)
        {
            //output errors to visual studio debug window
            Debug.Print("ERROR: " + ex.Message);

        }

        //record how many byte pairs you have sent
        write_count++;

        //return success flag
        return success;
    }

}
