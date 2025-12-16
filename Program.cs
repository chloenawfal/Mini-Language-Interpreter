using System.Reflection.Metadata.Ecma335;

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

        static int ParseExpression(string s,ref int index)
        {
            int a = ParseTerm(s, ref index);
            while (index < s.Length)
            {
                if (s[index] == '+')
                {
                    index++;
                    int b = ParseTerm(s, ref index);
                    a = a + b;
                }else if (s[index] == '-')
                {
                    index++;
                    int b = ParseTerm(s, ref index);
                    a = a - b;
                }
                else
                {
                    break;
                }
                
            }
            return a;
        }

        static int ParseTerm(string s, ref int index)
        {
            int a = ParseFactor(s, ref index);
            while (index < s.Length)
            {
                if (s[index] == '*')
                {
                    index++;
                    int b = ParseFactor(s, ref index);
                    a = a * b;
                }
                else
                {
                    break;
                }
            }
            return a;
        }

        static int ParseFactor(string s, ref int index)
        {
            if (s[index] == '(')
            {
                index++;
                int a = ParseExpression(s, ref index);
                index++;
                return a;
            }
            else
            {
                int start = index;
                while(index<s.Length && char.IsDigit(s[index]))
                {
                    index++;
                }
                string numberStr = s.Substring(start, index - start);
                return int.Parse(numberStr);
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
