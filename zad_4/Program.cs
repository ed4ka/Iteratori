namespace Zadacha4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commandArgs = Console.ReadLine().Split();
            List<string> elements = new List<string>();

            for (int i = 1; i < commandArgs.Length; i++)
            {
                elements.Add(commandArgs[i]);
            }

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                        case "PrintAll":
                            listyIterator.PrintAll();
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}