﻿using System;
using System.Collections.Generic;
using _2_Sort.PriorityQueue;

namespace _4_Graph.MinimumSpanningTree
{
    public class LazyPrim : MST
    {
        private bool[] marked;
        private Queue<Edge> mst;
        private PriorityQueue<Edge> priorityQueue;
        private float weight;

        public LazyPrim(EdgeWeightedGraph graph) : base(graph)
        {
            marked = new bool[graph.VertexCount];
            mst = new Queue<Edge>();
            priorityQueue = new HeapPriorityQueue<Edge>(graph.EdgeCount);

            Visit(0);
            while (!priorityQueue.IsEmpty)
            {
                Edge edge = priorityQueue.DeleteMax();
                if (marked[edge.V] && marked[edge.W])
                {
                    continue;
                }

                mst.Enqueue(edge);
                if (!marked[edge.V]) Visit(edge.V);
                if (!marked[edge.W]) Visit(edge.W);
            }

            foreach (var edge in mst)
            {
                weight += edge.Weight;
            }
        }

        private void Visit(int vertex)
        {
            marked[vertex] = true;
            foreach (var edge in graph.Adjacents(vertex))
            {
                if (!marked[edge.Other(vertex)])
                {
                    priorityQueue.Insert(edge);
                }
            }
        }

        public override float Weight => weight;

        public override IEnumerable<Edge> Edges()
        {
            return mst;
        }
    }
}
