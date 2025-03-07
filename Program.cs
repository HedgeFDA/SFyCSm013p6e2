using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SFyCSm013p6e2;

class Program
{
    /// <summary>
    /// Процедура реализующая основной алгоритм работы приложения.
    /// Подсчет количества слов
    /// </summary>
    static void PerformMain()
    {
        // Путь к файлу в который будет выполнятся вставка
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "input.txt"); 

        var list = new List<String>();

        using (StreamReader stream = File.OpenText(filePath))
        {
            string? line = "";

            while ((line = stream.ReadLine()) != null)
            {
                list.Add(line);
            }
        }

        var words = new Dictionary<string, int>();

        foreach (var line in list)
        {
            string noPunctuationText = new string(line.Where(c => !char.IsPunctuation(c)).ToArray());

            String[] wordsOfLine = noPunctuationText.Split(' ');

            foreach (var word in wordsOfLine)
            {
                if (string.IsNullOrEmpty(word)) continue;

                if (words.ContainsKey(word))
                    words[word] += 1;
                else
                    words.Add(word, 1);
            }
        }

        var sortedWords = words.OrderByDescending(pair => pair.Value);
        int num = 0;

        Console.WriteLine("10 слов чаще всего встречающихся в тексте:");
        foreach (var pair in sortedWords)
        {
            num++;

            if (num > 10)
                break;

            Console.WriteLine("{0}. слово \"{1}\" - {2}", num, pair.Key, pair.Value.ToString("N0"));
        }
    }

    /// <summary>
    /// Главная точка входа приложения
    /// </summary>
    /// <param name="args">Аргументы командной строки при запуске приложения.</param>
    static void Main(string[] args)
    {
        PerformMain();
    }
}