class Program
{
    
    public static string isExist = "exit";
    public static string type = "type";
    public static string echo = "echo";
    public static HashSet<string> builtinCommands = [isExist, type, echo];
    public static string[] binaryPaths =
   Environment.GetEnvironmentVariable("PATH")?.Split(':') ?? [];

    public static void Echo(string command)
    {
        string printWords = command[5..]; // slice all words after index 5, after echo
        Console.WriteLine(printWords);
    }

    public static void Type(string command)
    {
        if (command.StartsWith(type) && builtinCommands.Any(command[5..].Contains))
        {
            Console.WriteLine($"{command[5..]} is a shell builtin");
        }
        else if (command.StartsWith(type))
        {
            var args = command[5..];
            bool isCommoandFound = false;

            foreach (string binaryPath in binaryPaths)
            {
                string fullPath = Path.Combine(binaryPath, args);
                if (File.Exists(fullPath) &&
                    File.GetUnixFileMode(fullPath).HasFlag(UnixFileMode.GroupExecute |
                                                            UnixFileMode.UserExecute |
                                                            UnixFileMode.OtherExecute))
                {
                    isCommoandFound = true;
                    Console.WriteLine($"{args} is {fullPath}");
                }
            }
            if (!isCommoandFound)
            {
                Console.WriteLine($"{args}: not found");
            }
        }
    }

    static void Main()
    {
        // TODO: Uncomment the code below to pass the first stage
       
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
                    Echo(command);
                }
                else if (command.StartsWith(type))
                {
                    Type(command);
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
