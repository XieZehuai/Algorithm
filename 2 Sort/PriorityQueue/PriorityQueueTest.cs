using System;

namespace _2_Sort.PriorityQueue
{
    public class PriorityQueueTest
    {
        #region 用于测试用的具有优先级的类
        public class Person : IComparable<Person>
        {
            public int age;
            public string name;

            public Person(int age, string name)
            {
                this.age = age;
                this.name = name;
            }

            public int CompareTo(Person other)
            {
                return age - other.age;
            }

            public override string ToString()
            {
                return age + " " + name;
            }
        }
        #endregion

        public static void Test()
        {
            IPriorityQueue<Person> pq = new HeapPriorityQueue<Person>(3);

            while (true)
            {
                Console.WriteLine("1：插入元素  2：获取最大值  3：删除最大值  4：打印所有元素  其他：结束");
                int t = int.Parse(Console.ReadLine());

                if (t == 1)
                {
                    Console.WriteLine("请输入年龄以及姓名：");
                    string[] inputs = Console.ReadLine().Split(' ');
                    int age = int.Parse(inputs[0]);
                    pq.Insert(new Person(age, inputs[1]));
                }
                else if (t == 2)
                {
                    if (pq.IsEmpty)
                    {
                        Console.WriteLine("队列为空，无法获取最大值");
                    }
                    else
                    {
                        Console.WriteLine("最大值为：" + pq.Max().ToString());
                    }
                }
                else if (t == 3)
                {
                    if (pq.IsEmpty)
                    {
                        Console.WriteLine("队列为空，无法删除最大值");
                    }
                    else
                    {
                        Console.WriteLine("删除最大值成功，最大值为：" + pq.DeleteMax().ToString());
                    }
                }
                else if (t == 4)
                {
                    if (pq.IsEmpty)
                    {
                        Console.WriteLine("队列为空!");
                    }
                    else
                    {
                        pq.Print();
                    }
                }
                else if (t == 5)
                {
                    Console.WriteLine("容量为：" + pq.Capacity);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
