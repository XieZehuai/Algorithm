using System.IO;

namespace _5_String.DataCompression
{
    public class BinaryInput : MemoryStream
    {
        private BinaryWriter writer;
        private long position;

        public BinaryInput()
        {
            writer = new BinaryWriter(this);
            position = 0;
        }

        public void Write(bool value)
        {
            SetPosition();
            writer.Write(value);
            position += 1;
        }

        public void Write(char value)
        {
            SetPosition();
            writer.Write(value);
            position += 2;
        }

        public void Write(sbyte value)
        {
            SetPosition();
            writer.Write(value);
            position += 1;
        }

        public void Write(byte value)
        {
            SetPosition();
            writer.Write(value);
            position += 1;
        }

        public void Write(short value)
        {
            SetPosition();
            writer.Write(value);
            position += 2;
        }

        public void Write(ushort value)
        {
            SetPosition();
            writer.Write(value);
            position += 2;
        }

        public void Write(int value, int r)
        {
            SetPosition();
            for (int i = 0; i < r; i++)
            {
                writer.Write((value & (1 << i)) != 0);
            }
            position += r;
        }

        public void Write(int value)
        {
            SetPosition();
            writer.Write(value);
            position += 4;
        }

        public void Write(uint value)
        {
            SetPosition();
            writer.Write(value);
            position += 4;
        }

        public void Write(long value)
        {
            SetPosition();
            writer.Write(value);
            position += 8;
        }

        public void Write(ulong value)
        {
            SetPosition();
            writer.Write(value);
            position += 8;
        }

        public override void Close()
        {
            writer.Dispose();
            base.Close();
        }

        private void SetPosition()
        {
            Seek(position, SeekOrigin.Begin);
        }
    }
}
