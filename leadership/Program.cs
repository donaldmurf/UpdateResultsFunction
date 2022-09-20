using System;
using System.IO;
using System.Text.RegularExpressions;

namespace leadership
{
    internal class Program
    {
        public void UpdateSkillinFile(string statName)
        {
            if (!File.Exists("Donnie 9-19-2022 H16M11S32.txt"))
            {
                Console.WriteLine("file not found");
            }
            if (File.Exists("Donnie 9-19-2022 H16M11S32.txt"))
            {
                Console.WriteLine("file found");
            }

            //read in text file
            string playerFileName = "Donnie 9-19-2022 H16M11S32.txt";

            var lines = File.ReadAllLines(playerFileName); //read file into lines var
            int i = -1;
            
            foreach (string s in lines) //iterate though all strings in file
            {
                i++;
                string statRegex = @"^\s+-" + statName + @"_*:\s*\d*\s?$"; //statRegex will match stat line based off of statName
                Match matchString = Regex.Match(s, statRegex);
                Match matchNum = Regex.Match(lines[i], @"\d+");

                if (matchString.Success) //string match from file
                {
                    Console.WriteLine("String match found at line " + lines[i]);
                    if (matchNum.Success)// number match from string
                    {
                        if (Int32.TryParse(matchNum.Value, out int val)) //number can cast to int
                        {
                            val++; //increase leadership value by 1

                            lines[i] = $"\t-{statName}_______________________:{val}";
                            File.WriteAllLines(playerFileName, lines); //rewerite file with update
                        }
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            Program a = new Program();
            a.UpdateSkillinFile("Final Professionalism");
            
        }
    }
}