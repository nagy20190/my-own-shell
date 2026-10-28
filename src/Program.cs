class Program
{
    static void Main()
    {
        // TODO: Uncomment the code below to pass the first stage
        string isExistCommond = "exit";
        string typeCommond = "type";
        HashSet<string> commonds = [isExistCommond, typeCommond];
        while (true)
        {
            Console.Write("$ ");
            string commond = Console.ReadLine();
            if (commond.Equals(isExistCommond)) break;

            if (commond.StartsWith("echo"))
            {
                Console.WriteLine(commond[5..]);
            }
            else if(commond.StartsWith(typeCommond))
            {
                if (commonds.Contains(commond[5..]))
                {
                    Console.WriteLine($"{commond[5..]} is a shell builtin");
                }
                else
                {
                    Console.WriteLine($"{commond}: not found");
                }
            }
            else
            {
                Console.WriteLine($"{commond}: command not found");
            }
        }

    }
}
