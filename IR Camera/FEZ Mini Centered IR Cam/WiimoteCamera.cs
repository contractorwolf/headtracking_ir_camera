using System;
using Microsoft.SPOT;

using Microsoft.SPOT.Hardware;

using GHIElectronics.NETMF.Hardware;

using GHIElectronics.NETMF.FEZ;
using System.Threading;

class WiimoteCamera : IDisposable
{
    private const byte ADDR_SENSOR = 0xB0 >> 1;

    // structure with data from the camera

    public class Blob
    {

        public int x;

        public int y;

        public int size;

        public override String ToString()
        {

            return "X: " + x + " - Y: " + y + " - S: " + size;

        }

    }

    private Blob _blob1;

    private Blob _blob2;

    private Blob _blob3;

    private Blob _blob4;

    private I2CDevice _camera = new I2CDevice(new I2CDevice.Configuration(ADDR_SENSOR, 400));

    private byte[] _dataBuff = new byte[13];

    public WiimoteCamera()
    {

        // INIT the camera sensor

        //i2c(new byte[] { 0x30, 0x01 }, true, 10);

        //i2c(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x90 }, true, 10); // sensitivity part 1

        //i2c(new byte[] { 0x07, 0x00, 0x41 }, true, 10); // sensitivity part 2

        //i2c(new byte[] { 0x1A, 0x40, 0x00 }, true, 10); // sensitivity part 3

        //i2c(new byte[] { 0x33, 0x03 }, true, 10); // sets the mode of Output Format : Short (1) - 9bytes, Medium(3) - 4x3 bytes or Long(5) - 2x8 bytes    http://wiki.wiimoteproject.com/IR_Sensor

        //i2c(new byte[] { 0x30, 0x08 }, true, 10);

        //// SIMILAR to

        i2c(new byte[] { 0x30, 0x01 }, true, 10);

        i2c(new byte[] { 0x30, 0x08 }, true, 10);

        i2c(new byte[] { 0x06, 0x90 }, true, 10);

        i2c(new byte[] { 0x08, 0xC0 }, true, 10);

        i2c(new byte[] { 0x1A, 0x40 }, true, 10);

        i2c(new byte[] { 0x33, 0x03 }, true, 10);

        i2c(new byte[] { 0x30, 0x08 }, true, 10);

        Thread.Sleep(100);

    }

    public void readData()
    {

        i2c(new byte[] { 0x36 }, true, 1);

        i2c(_dataBuff, false, 1);

        // have no idea why the 1st BLOB start at 1 not 0....

        _blob1 = extractBlob(1);

        _blob2 = extractBlob(4);

        _blob3 = extractBlob(7);

        _blob4 = extractBlob(10);

    }

    private Blob extractBlob(byte offset)
    {

        Blob result = new Blob();

        result.x = _dataBuff[offset];

        result.y = _dataBuff[offset + 1];

        int extra = _dataBuff[offset + 2];

        result.x += (extra & 0x30) << 4;

        result.y += (extra & 0xC0) << 2;

        result.size = (extra & 0x0F);

        // VALID size < 15 if (result.size >= 15) return null;

        return result;

    }

    private void i2c(byte[] buff, bool write, int delay)
    {

        try
        {

            if (write)  // WRITE
            {

                _camera.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateWriteTransaction(buff) }, 1); // 1ms timeout

            }

            else // READ
            {

                _camera.Execute(new I2CDevice.I2CTransaction[] { I2CDevice.CreateReadTransaction(buff) }, 1); // 1ms timeout

            }

        }

        catch (System.ArgumentException e)
        {

            throw new Exception("Can't communicate with the I2C bus. Probably the: " + ADDR_SENSOR + " address is wrong ?", e);

        }

        Thread.Sleep(delay);

    }

    public void Dispose()
    {

        _camera.Dispose();

    }

    public Blob Blob1
    {

        get
        {

            return _blob1;

        }

    }

    public Blob Blob2
    {

        get
        {

            return _blob2;

        }

    }

    public Blob Blob3
    {

        get
        {

            return _blob3;

        }

    }

    public Blob Blob4
    {

        get
        {

            return _blob4;

        }

    }



}

