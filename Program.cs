using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.IO;
using System.Text.RegularExpressions;

namespace Agruments_of_Command_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number;
            string dot = ".";
            int lengthOfArgs = args.Length;   // количество аргументов
            Regex regex = new Regex(@"(-){0,1}(\d){1,}([\.\,](\d){1,}){0,}", RegexOptions.IgnoreCase);  //создаем объект класса Regex и прописываем регулярное выражение
            Regex commaToDot = new Regex(@"\,"); // новый регекс для совпадения

            //пример
            //program.exe 1234gdfg123 asd123 45 => 1234 123 123 45 
            int counter = 0;
                foreach (var arg in args) //первый цикл ищет первый аргумент
                {
                string tmp = Regex.Replace(arg, ",",".");
                    MatchCollection matchCollection = regex.Matches(tmp);                                                 //перечисляемая коллекция ( совпадения ) 
                    foreach (var item in matchCollection) // этот цикл ищет совпадения в аргументе
                    {
                        counter++;
                    try
                    {
                        number = Double.Parse(item.ToString());
                        Console.WriteLine("Совпадение  {0} имеет совпадение номер {1} ", item, counter);
                    }
                    catch (Exception e00)
                    {

                        Console.WriteLine(e00.Message); //пробрасываем исключение
                        Console.WriteLine($"{item} не удалось преобразовать в double");

                    }

                }
                }   
               
               // Console.WriteLine(number);
            

            //foreach (var arg in args) { 
            //    try
            //{
            //    number = int.Parse(arg) * 2; // парсим аргумент командной строки и кастим в int
            //    Console.WriteLine(number);

            //}
            //catch (Exception)
            //{

            //    Console.WriteLine($"Exception{arg}");
            //}
            //finally { Console.WriteLine("Done in any case"); }
            Console.ReadLine();
        }
    }
}
