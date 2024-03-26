namespace Zadacha7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            CommandInterpreter commandInterpreter = new CommandInterpreter();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                commandInterpreter.ExecuteCommand(commandArgs);
            }
        }
    }
}