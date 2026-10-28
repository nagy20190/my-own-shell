class Program
{
    static void Main()
    {
        // TODO: Uncomment the code below to pass the first stage
        string isExist = "exit";
        string type = "type";
        string echo = "echo";
        HashSet<string> builtinCommands = [isExist, type, echo];
        string[] binaryPaths =
       Environment.GetEnvironmentVariable("PATH")?.Split(':') ?? [];

        while (true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine()!;
            var isCommondValid = builtinCommands.Any(command.Contains);
            if (isCommondValid)
            {
                if (command.Equals(isExist)) break;

                if (command.StartsWith(echo))
                {
                    string printWords = command[5..]; // slice all words after index 5, after echo
                    Console.WriteLine(printWords);
                }
                else if (command.StartsWith(type) && builtinCommands.Any(command[5..].Contains))
                {
                   Console.WriteLine($"{command[5..]} is a shell builtin");                  
                }
                else if(command.StartsWith(type))
                {
                    var args = command[5..];
                    
                    foreach (string binaryPath in binaryPaths)
                    {
                        string fullPath = Path.Combine(binaryPath, args);
                        if (File.Exists(fullPath) &&
                            File.GetUnixFileMode(fullPath).HasFlag(UnixFileMode.GroupExecute |
                                                                    UnixFileMode.UserExecute |
                                                                    UnixFileMode.OtherExecute))
                        {
                            Console.WriteLine($"{args} is {fullPath}");
                            return;
                        }
                    }
                    Console.WriteLine($"{args}: not found");
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
