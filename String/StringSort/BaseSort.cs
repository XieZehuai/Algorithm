using System.Collections.Generic;

namespace _5_String.StringSort
{
    public class BaseSort
    {
        public void Sort(List<(int, string)> students, int R)
        {
            int[] count = new int[R + 1];
            foreach (var student in students)
            {
                count[student.Item1 + 1]++;
            }

            for (int r = 0; r < R; r++)
            {
                count[r + 1] += count[r];
            }

            (int, string)[] aux = new (int, string)[students.Count];
            foreach (var student in students)
            {
                aux[count[student.Item1]] = student;
                count[student.Item1]++;
            }

            for (int i = 0; i < aux.Length; i++)
            {
                students[i] = aux[i];
            }
        }
    }
}
