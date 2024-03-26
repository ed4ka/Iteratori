namespace Zadacha5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split();

                switch (commandArgs[0])
                {
                    case "Push":
                        string[] elementsToAdd = commandArgs[1].Split(',');
                        foreach (string element in elementsToAdd)
                        {
                            stack.Push(int.Parse(element));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            Console.WriteLine(stack.Pop());
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }

            // Първо обхождане на стека - в обратен ред
            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }

            // Второ обхождане на стека - в обратен ред
            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}