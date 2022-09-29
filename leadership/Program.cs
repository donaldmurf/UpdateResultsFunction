using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace leadership
{
    internal class Program
    {
        //This function takes in the name of the result to be updated and the name of the file to update.
        //This function is designed to be called when an event happens in game that would inicate some form of progression.
        //Examples:
        //      The players Technology skill increases -> UpdatePlayerResults ("Final Technology", playerFileName)
        //      or UpdatePlayerResults ("Final Technology", "mytext.txt")
        //NOTE: playerFileName should be used as the second parameter because that is the variable as the current session player
        public void UpdatePlayerResults(string statName, string FileToUpdate)
        {
            string playerFileName = FileToUpdate;

            var lines = File.ReadAllLines(playerFileName); //read file into lines var
            int i = -1;

            foreach (string s in lines) //iterate though all strings in file
            {
                i++;
                string finalStatRegex = @"^\s+-" + statName + @"_*:\s*\d*\s?$"; //Match for Final Stats section
                string VideoRegex = @"^\s+-" + statName + @"_*:\s*\s?$";

                Match matchString = Regex.Match(s, finalStatRegex); //UPDATE for multiple matches
                Match matchNum = Regex.Match(lines[i], @"\d+"); //Match num in string

                if (matchString.Success) //string match from file
                {
                    Debug.Write("String match line: " + i + " | ");

                    if (matchNum.Success)// number match from string
                    {
                        if (Int32.TryParse(matchNum.Value, out int val))
                        {
                            Debug.Write("Found NUM " + matchNum + " | ");

                            val++; //increase leadership value by 1

                            lines[i] = Regex.Replace(matchString.ToString(), matchNum.ToString(), val.ToString()); //(input, pattern, replacement)  (original string, found num, updated num)

                            Debug.Write("Updated to NUM " + val + "\n");

                        }
                        else
                        {
                            Debug.Write("ERROR:Line " + i + " unable to convert " + matchNum.Value + " to an INT for update");
                        }
                    }
                }

            }
            File.WriteAllLines(playerFileName, lines); //rewerite file with update

        }

        private static void Main(string[] args)
        {
            Program a = new Program();
            if (!File.Exists("Testerr 9-29-2022 H12M32S17.txt"))
            {
                Console.WriteLine("file not found");
            }
            if (File.Exists("Testerr 9-29-2022 H12M32S17.txt"))
            {
                Console.WriteLine("file found");
            }

            string playerFileName = "Testerr 9-29-2022 H12M32S17.txt";
            
            //final stats
            a.UpdatePlayerResults("Final Leadership", playerFileName);
           // a.UpdatePlayerResults("Final Professionalism", playerFileName);
            //a.UpdatePlayerResults("Final Technology", playerFileName);
            //a.UpdatePlayerResults("Final Communication", playerFileName);
            //a.UpdatePlayerResults("Final Critical Thinking", playerFileName);

            //videos
        }
    }
}