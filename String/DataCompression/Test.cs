using System;

namespace _5_String.DataCompression
{
    internal static class Test
    {
        public static void Invoke()
        {
            BinaryInput input = new BinaryInput();
            BinaryOutput output = new BinaryOutput(input);

            byte a = 0b_1000_0000;
            Console.WriteLine(a);
            input.Write(a, 8);

            Console.WriteLine(output.ReadBits(8));
        }
    }
}
