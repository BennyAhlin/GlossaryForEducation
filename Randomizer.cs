using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GlossaryForEducation
{
    public class Randomizer
    {
        public static (string SwedishWord, string EnglishWord, int WordPoints) Random()
        {

            while (true)
            {
                string[] Glossarys = File.ReadAllLines("../../../EngToSwe.csv", Encoding.Latin1);
                Random Random = new Random();
                int RandomIndex = Random.Next(Glossarys.Length);
                string RandomizedGlossary = Glossarys[RandomIndex];
                string[] split = RandomizedGlossary.Split(",");
                string EnglishWord = split[0];
                string SwedishWord = split[1];
                int WordPoints = int.Parse(split[2]);

                if (WordPoints > 3) continue;

                else
                {
                    return (SwedishWord, EnglishWord, WordPoints);
                }
            }

        }

    }
}
