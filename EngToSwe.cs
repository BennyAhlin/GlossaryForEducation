using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GlossaryForEducation;


public class EngToSwe
{
    public static void Play()
    {

        string SwedishWord;
        string EnglishWord;
        string Underlines = string.Empty;
        int WordPoints;
        int HintIndex = -1;
        bool PlayGame = true;


        while (PlayGame)
        {

            (string swedishWord, string englishWord, int wordPoints) = Randomizer.Random();
            SwedishWord = swedishWord;
            EnglishWord = englishWord;
            WordPoints = wordPoints;

            for (int i = 0; i < SwedishWord.Length; i++)
            {
                Underlines += "_";
            }

            bool changeUnderline = false;
            bool Guessing = true;
            while (Guessing)
            {
                if (changeUnderline && HintIndex < SwedishWord.Length)
                {
                    for (int i = HintIndex; i == HintIndex; i++)
                    {

                        while (HintIndex == i)
                        {
                            Underlines = Underlines.Remove(i, 1).Insert(i, SwedishWord[i].ToString());
                            break;
                        }
                    }
                }
                else if (changeUnderline && HintIndex == SwedishWord.Length)
                {
                    Console.WriteLine("GAME OVER!");
                    Console.WriteLine("The word was :" + SwedishWord);
                    PlayGame = false;
                    break;
                }


                Console.WriteLine();
                Console.WriteLine("English word is: " + EnglishWord);
                Console.WriteLine("Swedish word is: " + Underlines);

                Console.WriteLine();
                string? userInput = Console.ReadLine();

                if (userInput == SwedishWord.ToLower())
                {
                    Console.WriteLine("Correct! The Swedish word was : " + SwedishWord);
                    WordPoints++;
                    Thread.Sleep(2000);
                    string[] Glossarys = File.ReadAllLines("../../../EngToSwe.csv", Encoding.UTF8);
                    for (int i = 0; i < Glossarys.Length; i++)
                    {
                        string[] split = Glossarys[i].Split(',');

                        if (split.Length >= 2 && split[1] == userInput)
                        {
                            if (split.Length >= 3)
                            {
                                split[2] = WordPoints.ToString();

                                Glossarys[i] = string.Join(",", split);
                            }
                        }
                    }
                    File.WriteAllLines("../../../EngToSwe.csv", Glossarys, Encoding.UTF8);
                    SwedishWord = string.Empty;
                    EnglishWord = string.Empty;
                    Underlines = string.Empty;
                    WordPoints = 0;
                    HintIndex = -1;
                    Console.Clear();
                    break;
                }
                else
                {
                    HintIndex += 1;
                    changeUnderline = true;
                    Console.WriteLine("Sorry, not correct! Here comes a hint!");
                    Thread.Sleep(2000);
                }
            }

        }


    }

}
