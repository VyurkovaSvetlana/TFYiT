using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 2
            
            GetData dataProvider = new GetData();
            Lex lex = dataProvider.GetLex();
            using (StreamReader streamReader = new StreamReader("code.txt"))
            {
                int skip = 0;
                var result = lex.toRecognizeCode(streamReader.ReadToEnd(), ref skip);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadLine(); 
            
            //Задание 1
            /*
             GetData dataProvider = new GetData();
             var automat = dataProvider.GetAutomat("intAutomation.txt");
            while (true)
            {
                Console.WriteLine("Введите текст для распознавания:");
                string text = Console.ReadLine();
                Console.WriteLine("Укажите смещение:");
                if (int.TryParse(Console.ReadLine(), out var skip) && skip >= 0)
                {
                    var result = automat.toRecognize(text, skip);
                    Console.WriteLine(result);
                    if (result.Key)
                    {
                        Console.WriteLine(text.Substring(skip, result.Value));
                    }
                }
                else
                {
                    Console.WriteLine("Некоррректное смещение!");
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
            */
        }
    }
}
