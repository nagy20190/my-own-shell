class Program
{
    static void Main()
    {
        // TODO: Uncomment the code below to pass the first stage
        string isExist = "exit";
        while(true)
        {
            Console.Write("$ ");
            string commond = Console.ReadLine();
            if (commond.Equals(isExist)) break;

            if (commond.StartsWith("echo"))
            {
                Console.WriteLine(commond[5..]);
            }
            else
            {
                Console.WriteLine($"{commond}: command not found");
            }

        }

    }
}
