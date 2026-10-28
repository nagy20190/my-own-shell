class Program
{
    static void Main()
    {
        // TODO: Uncomment the code below to pass the first stage
        string isExist = "exit";
        string type = "type";
        string echo = "echo";
        HashSet<string> commands = [isExist, type, echo];
        while (true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine()!;

            if (commands.Any(command.Contains))
            {
                if (command.Equals(isExist)) break;

                if (command.StartsWith("echo"))
                {
                    Console.WriteLine(command[5..]);
                }
                else if (command.StartsWith(type) && commands.Any(command[5..].Contains))
                {
                   Console.WriteLine($"{command[5..]} is a shell builtin");                  
                }
                else
                {
                    Console.WriteLine($"{command[5..]}: not found");
                }
            }
            else
            {
                Console.WriteLine($"{command}: command not found");
            }
        }

    }
}
