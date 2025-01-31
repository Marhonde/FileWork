namespace FileWork1;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

class Program : Python
{
    private static bool _run = true;

    private static int _task;

    private static string? _path, _secondPath, _text, _line;
    
    public static void Main(string[] args)
    {
        while (_run)
        {
            _task = int.Parse(input("Задание: "));

            switch (_task)
            {
                case 1:
                    _path = @"C:\Users\Semen\RiderProjects\FileWork1\FileWork1\Tasks\Task1.txt";
                    
                    using (var sr = File.OpenText(_path))
                    {
                        var line = sr.ReadLine() ?? string.Empty;
                        
                        var words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        print($"Количество слов в строке: {words.Length}");
                    }
                    break;
                case 2:
                    _path = @"C:\Users\Semen\RiderProjects\FileWork1\FileWork1\Tasks\Task2.txt";

                    var correctedText = "";

                    while (true)
                    {
                        _text = input("Введите предложение для проверки скобок: ");

                        if (string.IsNullOrEmpty(_text))
                        {
                            print("Строка не должна быть пустой");
                            continue;
                        }
                        
                        break;
                    }

                    try
                    {
                        File.WriteAllText(_path, _text);
                        _line = File.ReadAllText(_path);
                        
                        var stack = new Stack<int>();
                        var result = "";

                        for (var i = 0; i < _line.Length; i++)
                        {
                            switch (_line[i])
                            {
                                case '(':
                                    stack.Push(i);
                                    result += '(';
                                    break;
                                case ')':
                                    if (stack.Count > 0)
                                    {
                                        stack.Pop();
                                        result += ')';
                                    }
                                    else
                                        result += "";
                                    
                                    break;
                                default:
                                    result += _line[i];
                                    break;
                            }
                        }

                        while (stack.Count > 0)
                        {
                            stack.Pop();
                            result += ')';
                        }
                        
                        correctedText = result;
                        
                        File.WriteAllText(_path, correctedText);
                        print($"Исправленное предложение: {correctedText}");
                    }
                    catch (FileNotFoundException e)
                    {
                        print(e.Message);
                    }
                    catch (IOException e)
                    {
                        print(e.Message);
                    }
                    break;
                case 3:
                    _path = @"C:\Users\Semen\RiderProjects\FileWork1\FileWork1\Tasks\Task3.txt";
                    _secondPath = @"C:\Users\Semen\RiderProjects\FileWork1\FileWork1\Tasks\Task31.txt";

                    _text = input("Введите строку: ");
                    try
                    {
                        File.WriteAllText(_path, _text);
                        
                        _line = ReverseStringBuilder(File.ReadAllText(_path));
                        print($"Перевернутая строка: {_line}");
                        
                        File.WriteAllText(_secondPath, _line);
                    }
                    catch (FileNotFoundException e)
                    {
                        print(e.Message);
                    }
                    catch (IOException e)
                    {
                        print(e.Message);
                    }
                    
                    
                    break;
                case 4:
                    _path = @"C:\Users\Semen\RiderProjects\FileWork1\FileWork1\Tasks\Task3.txt";
                    _secondPath = @"C:\Users\Semen\RiderProjects\FileWork1\FileWork1\Tasks\Task31.txt";

                    _text = input("Введите текст: ");
                    
                    correctedText = "";

                    try
                    {
                        File.WriteAllText(_path, _text);

                        _line = Change(File.ReadAllText(_path));

                        print($"Измененный текст: {_line}");
                        File.WriteAllText(_secondPath, _line);
                    }
                    catch (FileNotFoundException e)
                    {
                        print(e.Message);
                    }
                    catch (IOException e)
                    {
                        print(e.Message);
                    }
                    
                    break;
                case 0:
                    _run = false;
                    break;
                default:
                    print("Ошибка");
                    break;
            }
        }
    }

    private static string ReverseStringBuilder(string text)
    {
        var strArr = text.Split(' ');
        var newStr = "";

        foreach (var word in strArr)
        {
            for (int i = word.Length; i != 0; i--)
            {
                newStr += word[i - 1];
            }
            
            newStr += " ";
        }
        return newStr;
    }

    private static string Change(string text)
    {
        var firstOpen = text.IndexOf('(');
        var firstClose = text.IndexOf(')');
        
        if (firstOpen < 0 && firstClose < 0)
            return text;
        if (firstOpen < 0 && firstClose >= 0)
            throw new ArgumentException("В выражении есть открывающая скобка, но нет закрывающей");
        if (firstClose < 0)
            throw new ArgumentException("В выражении есть закрывающая скобка, но нет открывающей");
        if (firstOpen > firstClose)
            throw new ArgumentException("В выражении закрывающая скобка раньше открывающей");
        
        var lastOpen = text.LastIndexOf('(', firstClose);
        
        if (firstOpen != lastOpen)
            throw new ArgumentException("В выражении есть вложенные скобки");
        
        text = text.Substring(0, firstOpen) + text.Substring(firstClose + 1);

        return Change(text);
    }
}