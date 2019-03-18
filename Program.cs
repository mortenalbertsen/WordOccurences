using System;
using System.Collections.Generic;
using System.IO;

namespace WordOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read in file
            var fileName = args[1];
            Console.WriteLine("Filename: " + fileName);
            var reader = new StreamReader(fileName);

            String nextLine = reader.ReadLine();
            var wordOccurences = new Dictionary<String, int>();
            while (nextLine != null)
            {
                // Split line
                var wordsInLine = nextLine.Trim().Split(' ');
                foreach (var word in wordsInLine)
                {
                    if (string.IsNullOrEmpty(word))
                    {
                        continue;
                    }
                    int possibleValue;
                    Console.WriteLine("Viewing: \"" + word + "\"");
                    var lowerCasedWord = word.ToLower();
                    if (wordOccurences.TryGetValue(lowerCasedWord, out possibleValue))
                    {
                        wordOccurences[lowerCasedWord] = possibleValue + 1;
                    }
                    else
                    {
                        wordOccurences[lowerCasedWord] = 1;
                    }
                }
                nextLine = reader.ReadLine();
            }

            // Close stream
            reader.Close();

            // Print results
            foreach (KeyValuePair<string, int> entry in wordOccurences)
            {
                Console.WriteLine(entry.Value + ": " + entry.Key);
            }


        }
    }
}
