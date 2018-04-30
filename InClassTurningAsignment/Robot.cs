using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace InClassTurningAsignment
{
    public class Robot
    {

        private const byte LEFT_FORWARD = 0x01;
        private const byte LEFT_BACKWARD = 0x02;
        private const byte RIGHT_FORWARD = 0x03;
        private const byte RIGHT_BACKWARD = 0x04;
        //buffer=  {0x01, left, right};

        private Command lastCommand = Command.Stop;
        private SerialPort serial;
        private bool useOverrideCommands = true;
        private Form1 UI;

        private float speed = 1f;

        public Robot(Form1 UI, SerialPort serial)
        {
            this.UI = UI;
            this.serial = serial;
        }

        public Command getLastCommand()
        {
            return lastCommand;
        }

        public void setSpeed(float speed)
        {
            this.speed = speed;
        }

        public void defaultSpeed()
        {
            this.speed = 1;
        }

        public void setOverrideStatus(bool status)
        {
            if (status != useOverrideCommands)
            {
                useOverrideCommands = status;

                if (lastCommand != Command.Stop)
                {
                    sendCommand(Command.Stop);
                }
            }
        }

        public void sendOverrideCommand(Command cmd)
        {
            if (useOverrideCommands)
            {
                sendCommand(cmd);
            }
        }

        public void sendVisionCommand(Command cmd)
        {
            if (!useOverrideCommands)
            {
                sendCommand(cmd);
            }
        }

        private void sendCommand(Command command)
        {
            if (serial.IsOpen)
            {
                if (command != lastCommand)
                {
                    try
                    {
                        serial.Write(getCommand(command), 0, 4);
                        lastCommand = command;
                    }catch(TimeoutException e)
                    {
                        Console.WriteLine("Timeout. Disconnecting.");
                        close();
                    }
                }
            }
        }

        private static byte getSpeedByte(float speed)
        {
            if (speed > 1)
                speed = 1;
            if (speed < 0)
                speed = 0;
            byte spd = (byte)(255 * speed);
            if (spd < 5)
                spd = 0;

            return spd;
        }

        private byte[] getCommand(Command command)
        {
            byte[] buffer = new byte[4];
            buffer[0] = LEFT_FORWARD;
            buffer[1] = 0;
            buffer[2] = RIGHT_FORWARD;
            buffer[3] = 0; //Default to stopping.

            switch (command)
            {
                case Command.Left:
                    buffer[3] = getSpeedByte(speed);
                    return buffer;
                case Command.Right:
                    buffer[1] = getSpeedByte(speed);
                    return buffer;
                case Command.Forward:
                    buffer[1] = buffer[3] = getSpeedByte(speed); //Lol I forgot this was a thing!
                    return buffer;
                case Command.SpinLeft:
                    buffer[0] = LEFT_BACKWARD;
                    buffer[1] = buffer[3] = getSpeedByte(speed);
                    return buffer;
                case Command.SpinRight:
                    buffer[2] = RIGHT_BACKWARD;
                    buffer[1] = buffer[3] = getSpeedByte(speed);
                    return buffer;
                default:
                    return buffer; //Defaults to stop.
            }
        }

        public String[] getAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        public bool open(String portName)
        {
            if (serial.IsOpen)
            {
                close();
            }

            serial.PortName = portName;
            try
            {
                serial.Open();
                invokeConnected(true);
                sendCommand(Command.Stop);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not connect.");
                return false;
            }
        }

        public bool isOpen()
        {
            return serial.IsOpen;
        }

        public void close()
        {
            invokeConnected(false);
            serial.Close();
        }

        private void invokeConnected(bool state)
        {
            UI.Invoke(new Action(() => UI.setConnectedBox(state)));
        }

        public enum Command
        {
            Left,
            Forward,
            Right,
            SpinLeft,
            SpinRight,
            Stop
        }

    }
}
