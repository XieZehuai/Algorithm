using _2_Sort;

namespace _5_String.StringSort
{
    public class Quick3StringSort : ISorter<string>
    {
        public string Name => "三向字符串快速排序";

        public void Sort(string[] data)
        {
            Sort(data, 0, data.Length - 1, 0);
        }

        public void Sort(string[] data, int low, int high)
        {
            Sort(data, low, high, 0);
        }

        private void Sort(string[] data, int low, int high, int d)
        {
            if (high <= low) return;

            int lt = low;
            int gt = high;
            int v = CharAt(data[low], d);
            int i = low + 1;

            while (i <= gt)
            {
                int t = CharAt(data[i], d);

                if (t < v) Swap(data, lt++, i++);
                else if (t > v) Swap(data, i, gt--);
                else i++;
            }

            Sort(data, low, lt - 1, d);
            if (v >= 0)
            {
                Sort(data, lt, gt, d + 1);
            }
            Sort(data, gt + 1, high, d);
        }

        private int CharAt(string str, int index)
        {
            if (index < str.Length)
            {
                return str[index] - 'a';
            }
            else
            {
                return -1;
            }
        }

        private void Swap(string[] data, int a, int b)
        {
            string temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }
    }
}
