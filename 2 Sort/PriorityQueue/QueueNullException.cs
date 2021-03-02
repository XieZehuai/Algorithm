using System;
using System.Collections.Generic;

namespace _2_Sort.PriorityQueue
{
    public class QueueEmptyException : Exception
    {
        public QueueEmptyException() { }

        public QueueEmptyException(string message) : base(message) { }
    }
}
