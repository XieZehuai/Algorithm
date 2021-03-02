using System;
using System.Text;

namespace _3_Searching.Hash
{
    /*
     * 交易类，保存交易对象的姓名，交易的时间以及金额
     */
    public class Transaction : IComparable<Transaction>
    {
        private readonly string name;
        private readonly DateTime date;
        private readonly double amount;

        public Transaction(string name, DateTime date, double amount)
        {
            this.name = name;
            this.date = date;
            this.amount = amount;
        }

        public string Name => name;

        public DateTime Date => date;

        public double Amount => amount;

        public int CompareTo(Transaction other)
        {
            return date.CompareTo(other.date);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            
            hash = 31 * hash + name.GetHashCode();
            hash = 31 * hash + date.GetHashCode();
            hash = 31 * hash + amount.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return "姓名：" + name + "    日期：" + date.ToString("MM-dd") + "    数额：" + amount;
        }
    }
}