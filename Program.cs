using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<String> g = new Graph<String>();
            g.AddNode("A");
            g.AddNode("B");
            g.AddNode("C");
            g.AddNode("D");
            g.AddNode("E");

            g.AddEdge("A", "B",3);
            g.AddEdge("A", "C",5);
            g.AddEdge("C", "D",10);
            g.AddEdge("B","E",7);
            g.RemoveNode("B");

            g.PrintGraph();
            //Console.ReadLine();
        }
    }

    class Node<T>
    {
        public T name;
        public Dictionary<T, int> adjacents;
        public Node(T value)
        {
            this.name = value;
            this.adjacents = new Dictionary<T, int>();
        }
        public void AddAdjacent(T name,int weight)
        {
            if (!adjacents.ContainsKey(name))
            {
                adjacents.Add(name, weight);
            }
        }
        public void RemoveAdjacent(T name)
        {
            if (adjacents.ContainsKey(name))
            {
                adjacents.Remove(name);
            }
        }
    }

    class Graph<T>
    {
        Dictionary<T, Node<T>> allNode = new Dictionary<T, Node<T>>();
        public void AddNode(T name)
        {
            if(!allNode.ContainsKey(name))
            {
                allNode.Add(name , new Node<T> (name));
            }
        }
        public void AddEdge(T start,T end,int weight)
        {
            if(allNode.ContainsKey(start) && allNode.ContainsKey(end)) 
            {
                allNode[start].AddAdjacent(end, weight);
                allNode[end].AddAdjacent(start, weight);
            }
        }
        public void PrintGraph()
        {
            string allST = "";
            foreach(T key in allNode.Keys)
            {
                allST += "Node "+ allNode[key].name + " with Adjacent : ";
                foreach (T name in allNode[key].adjacents.Keys)
                {
                    allST += name + "(" + allNode[key].adjacents[name] + ") ";
                }
                allST += "\n";
            }
            Console.WriteLine(allST);
        }
        public void RemoveNode(T name)
        {
            if(allNode.ContainsKey(name))
            {
                allNode.Remove(name);
                foreach(T tmp in allNode.Keys)
                {
                    allNode[tmp].RemoveAdjacent(name);
                }
            }
        }
        public void RemoveEdge(T start,T end)
        {
            if(allNode.ContainsKey(start) && allNode.ContainsKey(end)) 
            {
                allNode[start].RemoveAdjacent(end);
                allNode[end].RemoveAdjacent(start);          
            }
        }
    }
}