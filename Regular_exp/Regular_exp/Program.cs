using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Regular_exp
{
    class Program
    {
       static void get_text_in_file(string text)
        {
            File.WriteAllText("d:\\text_inputted.txt",text);
        }
        static string get_text_from_file()
        {
            FileStream fstream = new FileStream("d:\\text_inputted.txt", FileMode.OpenOrCreate);
            char[] strinng = new char[fstream.Length];
            StreamReader read_in = new StreamReader(fstream);
            string text = read_in.ReadToEnd();
            read_in.Close();
            return text;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести новый текст?  y/n");
            char answer = ' ';
            answer = Convert.ToChar(Console.ReadLine());
            string output = null;
            string input = null;
            string data = @"\b(\d+[.,]+\d+[.,]\d+\d)";
            Regex regular = new Regex(data);
            Match match;
            switch (answer)
            {
                case 'y':
                    input = Convert.ToString(Console.ReadLine());
                    get_text_in_file(input);
                    break;
                case 'n':
                    break;
            }
            output = get_text_from_file();
            match = regular.Match(output);
            while (match.Success)
            {
                Console.WriteLine(match.Groups[1].Value);
                match = match.NextMatch();
            }
            Console.ReadLine();
        }
    }
}
