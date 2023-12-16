using System;
using System.Collections.Generic;

class KruskalAlgorithm
{
    class Edge : IComparable<Edge>
    {
        public int src, dest, weight;

        public int CompareTo(Edge compareEdge)
        {
            return this.weight - compareEdge.weight;
        }
    }

    int V, E;
    Edge[] edges;

    KruskalAlgorithm(int v, int e)
    {
        V = v;
        E = e;
        edges = new Edge[E];
        for (int i = 0; i < e; ++i)
            edges[i] = new Edge();
    }

    int Find(int[] parent, int i)
    {
        if (parent[i] == -1)
            return i;
        return Find(parent, parent[i]);
    }

    void Union(int[] parent, int x, int y)
    {
        int xset = Find(parent, x);
        int yset = Find(parent, y);
        parent[xset] = yset;
    }

    void KruskalMST()
    {
        Edge[] result = new Edge[V];
        int i = 0;
        int e = 0;

        Array.Sort(edges);

        int[] parent = new int[V];

        for (int j = 0; j < V; ++j)
            parent[j] = -1;

        while (e < V - 1)
        {
            Edge next_edge = edges[i++];

            int x = Find(parent, next_edge.src);
            int y = Find(parent, next_edge.dest);

            if (x != y)
            {
                result[e++] = next_edge;
                Union(parent, x, y);
            }
        }

        Console.WriteLine("Following are the edges in " +
                          "the constructed MST");
        for (i = 0; i < e; ++i)
            Console.WriteLine(result[i].src + " -- " +
                              result[i].dest + " == " + result[i].weight);
    }

    public static void Main()
    {
        int V = 4;
        int E = 5;
        KruskalAlgorithm graph = new KruskalAlgorithm(V, E);

        graph.edges[0].src = 0;
        graph.edges[0].dest = 1;
        graph.edges[0].weight = 10;

        graph.edges[1].src = 0;
        graph.edges[1].dest = 2;
        graph.edges[1].weight = 6;

        graph.edges[2].src = 0;
        graph.edges[2].dest = 3;
        graph.edges[2].weight = 5;

        graph.edges[3].src = 1;
        graph.edges[3].dest = 3;
        graph.edges[3].weight = 15;

        graph.edges[4].src = 2;
        graph.edges[4].dest = 3;
        graph.edges[4].weight = 4;

        graph.KruskalMST();
    }
}
