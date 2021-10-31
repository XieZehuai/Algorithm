using System.IO;

namespace _5_String.DataCompression
{
    public class BinaryOutput
    {
        private BinaryReader reader;
        private long position;

        public BinaryOutput(Stream stream)
        {
            reader = new BinaryReader(stream);
            position = 0;
        }

        public bool ReadBool()
        {
            SetPosition();
            bool value = reader.ReadBoolean();
            position += 1;
            return value;
        }

        public char ReadChar()
        {
            SetPosition();
            char value = reader.ReadChar();
            position += 2;
            return value;
        }

        public byte ReadByte()
        {
            SetPosition();
            byte value = reader.ReadByte();
            position += 1;
            return value;
        }

        public sbyte ReadSbyte()
        {
            SetPosition();
            sbyte value = reader.ReadSByte();
            position += 1;
            return value;
        }

        public short ReadShort()
        {
            SetPosition();
            short value = reader.ReadInt16();
            position += 2;
            return value;
        }

        public ushort ReadUShort()
        {
            SetPosition();
            ushort value = reader.ReadUInt16();
            position += 2;
            return value;
        }

        public int ReadBits(int r)
        {
            SetPosition();
            int value = 0;
            for (int i = 0; i < r; i++)
            {
                if (ReadBool())
                {
                    value += 1 << i;
                }
            }
            position += r;
            return value;
        }

        public int ReadInt()
        {
            SetPosition();
            int value = reader.ReadInt32();
            position += 4;
            return value;
        }

        public uint ReadUInt()
        {
            SetPosition();
            uint value = reader.ReadUInt32();
            position += 4;
            return value;
        }

        public long ReadLong()
        {
            SetPosition();
            long value = reader.ReadInt64();
            position += 8;
            return value;
        }

        public ulong ReadULong()
        {
            SetPosition();
            ulong value = reader.ReadUInt64();
            position += 8;
            return value;
        }

        private void SetPosition()
        {
            reader.BaseStream.Seek(position, SeekOrigin.Begin);
        }
    }
}
