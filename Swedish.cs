using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlossaryForEducation;

public class Swedish
{
    public static void PlaySE()
    {

        bool PlayGame = true;
        while (PlayGame)
        {

            string[] Glossarys = File.ReadAllLines("../../../ENGtoSE.csv");
            string EnglishWord = string.Empty;
            string SwedishWord = string.Empty;
            string RandomizedGlossary = string.Empty;
            string splitRandomGlossary = string.Empty;

            foreach (string glossary in Glossarys)
            {

                if (glossary.Length > 10)
                {

                    Random Random = new Random();
                    int RandomIndex = Random.Next(Glossarys.Length);
                    RandomizedGlossary = Glossarys[RandomIndex];
                }

                string[] split = RandomizedGlossary.Split(",");
                EnglishWord = split[0];
                SwedishWord = split[1];


            }



            Console.WriteLine();
            Console.WriteLine("Randomized word is: " + RandomizedGlossary);
            Console.WriteLine();
            Console.WriteLine($"English word:{EnglishWord} and Swedish word {SwedishWord}");



















            Console.ReadKey();
        }






















    }

}
