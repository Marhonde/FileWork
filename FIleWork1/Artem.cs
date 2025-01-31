namespace FileWork1;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
 
public class Program1
{
    static void Master()
    {
 
        // Console.WriteLine("=====Работа файлами=====");
        // Console.WriteLine("Задание 2.");
        // string filePath = "/home/student/RiderProjects/zadanie2.txt";
        // Console.Write("Введите предложение для подсчета слов: ");
        // string text = Console.ReadLine();
        // int wordCount = 0;
        // try
        // {
        //     File.WriteAllText(filePath, text);
        // }
        // catch (IOException e)
        // {
        //     Console.WriteLine($"Ошибка записи в файл: {e.Message}");
        //     return;
        // }
        // try
        // {
        //     string fileText = File.ReadAllText(filePath);
        //     string[] words = fileText.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        //     wordCount = words.Length;
        //
        // }
        // catch (FileNotFoundException e)
        // {
        //     Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
        //     return;
        // }
        // catch (IOException e)
        // {
        //     Console.WriteLine($"Ошибка чтения файла: {e.Message}");
        //     return;
        // }
        // Console.WriteLine($"Количество слов в файле: {wordCount}");
 
 
 
        // Console.WriteLine("Задание 5.");
        // string filePath = "/home/student/RiderProjects/zadanie5.txt";
        // string text;
        // string correctedText = "";
        // string correctedFilePath = "/home/student/RiderProjects/zadanie5.txt";
        // while (true)
        // {
        //     Console.Write("Введите предложение для проверки скобок: ");
        //     text = Console.ReadLine();
        //     if (string.IsNullOrEmpty(text))
        //     {
        //         Console.WriteLine("Строка не должна быть пустой!");
        //         continue;
        //     }
        //     break;
        // }
        //
        // try
        // {
        //     File.WriteAllText(filePath, text);
        //     string fileText = File.ReadAllText(filePath);
        //     Stack<int> bracketStack = new Stack<int>();
        //     string result = "";
        //
        //     for (int i = 0; i < fileText.Length; i++)
        //     {
        //         if (fileText[i] == '(')
        //         {
        //             bracketStack.Push(i);
        //             result += '(';
        //         }
        //         else if (fileText[i] == ')')
        //         {
        //             if (bracketStack.Count > 0)
        //             {
        //                 bracketStack.Pop();
        //                 result += ')';
        //             }
        //             else
        //                 result += "";
        //         }
        //         else
        //         {
        //             result += fileText[i];
        //         }
        //     }
        //     while (bracketStack.Count > 0)
        //     {
        //         bracketStack.Pop();
        //         result += ')';
        //     }
        //     correctedText = result;
        //     File.WriteAllText(correctedFilePath, correctedText);
        //     Console.WriteLine($"Исправленное предложение: {correctedText}");
        // }
        // catch (FileNotFoundException e)
        // {
        //     Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
        //     return;
        // }
        // catch (IOException e)
        // {
        //     Console.WriteLine($"Ошибка работы с файлом: {e.Message}");
        //     return;
        // }
 
 
 
        // Console.WriteLine("Задание 10.");
        // string filePath = "/home/student/RiderProjects/zadanie10.txt";
        // Console.Write("Введите текст: ");
        // string text = Console.ReadLine();
        // try {
        //     File.WriteAllText(filePath, text);
        //     Console.WriteLine($"Текст с перевернутыми словами: {ReverseStringBuilder(File.ReadAllText(filePath))}");
        //     string newText = ReverseStringBuilder(File.ReadAllText(filePath));
        //     File.WriteAllText(filePath, newText);
        // }
        // catch (FileNotFoundException e)
        // {
        //     Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
        //     return;
        // }
        // catch (IOException e)
        // {
        //     Console.WriteLine($"Ошибка работы с файлом: {e.Message}");
        //     return;
        // }
        //
        // static string ReverseStringBuilder(string text)
        // {
        //     string[] strArray = text.Split(' ');
        //     string newStr="";
        //     foreach(var s in strArray)
        //     {
        //         for(var i = s.Length; i != 0; i--)
        //         {
        //             newStr += s[i-1];
        //         }
        //         newStr += " ";
        //     }
        //     return newStr;
        // }
 
 
 
 
        Console.WriteLine("Задание 13.");
        string filePath = "/home/student/RiderProjects/zadanie13.txt";
        Console.Write("Введите текст: ");
        string text = Console.ReadLine();
        string correctedText = "";
        string correctedFilePath = "/home/student/RiderProjects/zadanie13.txt";
        try {
            File.WriteAllText(filePath, text);
            Console.WriteLine(Change(text));
            string newText = Change(File.ReadAllText(filePath));
            File.WriteAllText(filePath, newText);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка работы с файлом: {e.Message}");
            return;
        }
 
        static string Change(string s)
        {
            int firstOpen = s.IndexOf('(');
            int firstClose = s.IndexOf(')'); 
            if (firstOpen < 0 && firstClose < 0) 
                return s;
            if (firstOpen < 0 && firstClose >= 0)
                throw new ArgumentException("В выражении есть открывающая скобка, но нет закрывающей");
            if (firstClose < 0)
                throw new ArgumentException("В выражении есть закрывающая скобка, но нет открывающей");
            if (firstOpen > firstClose)
                throw new ArgumentException("В выражении закрывающая скобка раньше открывающей");
            int lastOpen = s.LastIndexOf('(', firstClose); 
            if (firstOpen != lastOpen)
                throw new ArgumentException("В выражении есть вложенные скобки");
            s = s.Substring(0, firstOpen) + s.Substring(firstClose + 1); 
            return Change(s); 
        }
 
 
 
 
        /*Console.WriteLine("Задание 20.");
        string filePath = "/home/student/RiderProjects/zadanie20.txt";
        Console.Write("Введите числа: ");
        string text = Console.ReadLine();
        string correctedText = "";
        string correctedFilePath = "/home/student/RiderProjects/zadanie20.txt";
        try
        {
            File.WriteAllText(filePath, text);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка работы с файлом: {e.Message}");
            return;
        }
 
        List<int> numbers = ReadNumbersFromFile(filePath);
        double average = CalculateAverage(numbers);
        try
        {
            File.WriteAllText(filePath, average.ToString());
            Console.WriteLine($"Среднее арифметическое: {average}.");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка работы с файлом: {e.Message}");
            return;
        }*/
 
 
        /*static List<int> ReadNumbersFromFile(string filePath)
        {
            List<int> numbers = new List<int>();
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string part in parts)
                {
                    if(int.TryParse(part, out int number))
                        numbers.Add(number);
                }
            }
            return numbers;
        }
        static double CalculateAverage(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return 0;
            var positiveNumbers = numbers.Where(n => n > 0).ToList();
            if (positiveNumbers.Count == 0)
                return 0;
            return positiveNumbers.Average();
        }
 
 
 
        Console.WriteLine("Задание 21.");
        string filePath = "/home/student/RiderProjects/zadanie21.txt";
        Console.Write("Введите числа: ");
        string text = Console.ReadLine();
        string correctedText = "";
        string correctedFilePath = "/home/student/RiderProjects/zadanie21.txt";
        try
        {
            File.WriteAllText(filePath, text);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка работы с файлом: {e.Message}");
            return;
        }
        List<int> numbers = ReadNumbersFromFile(filePath);
        int difference = CalculateDifference(numbers);
        try
        {
            File.WriteAllText(filePath, difference.ToString());
            Console.WriteLine($"Разность максимального и минимального числа: {difference}.");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Ошибка: Файл '{filePath}' не найден: {e.Message}");
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка работы с файлом: {e.Message}");
            return;
        }
        static int CalculateDifference(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return 0;
            int min = numbers.Min();
            int max = numbers.Max();
            return max - min;
        }*/
 
    }
}