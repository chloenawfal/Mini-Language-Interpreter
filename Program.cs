namespace Mini_Language_Interpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your expression : ");
            string s = "" + Console.ReadLine();

            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("You didn't enter an expression.");
            }else if (Letters(s))
            {
                Console.WriteLine("You entered a letter, can't give you the result.");
            }
            else
            {
                //int result = Evaluate(s)
                //Console.WriteLine($"The result is : {result}");
            }
        }

        static bool Letters(string s)
        {
            s = s.ToLower();
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i]>='a'&& s[i] <= 'z')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
