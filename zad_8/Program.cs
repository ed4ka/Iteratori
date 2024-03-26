namespace Zadacha8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                int number = int.Parse(input[1]);

                if (command == "Add")
                {
                    linkedList.AddLast(number);
                }
                else if (command == "Remove")
                {
                    linkedList.Remove(number);
                }

                Console.WriteLine(linkedList.Count);
                PrintLinkedList(linkedList);
            }
        }

        static void PrintLinkedList(LinkedList<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
    }
