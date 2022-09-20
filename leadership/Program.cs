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
        public void UpdatePlayerResults(string statName, string FileToUpdate )
        {
            string playerFileName = FileToUpdate;
            

            var lines = File.ReadAllLines(playerFileName); //read file into lines var
            int i = -1;

            foreach (string s in lines) //iterate though all strings in file
            {
                i++;
                string finalStatRegex = @"^\s+-" + statName + @"_*:\s*\d*\s?$"; //Match for Final Stats section

                Match matchString = Regex.Match(s, finalStatRegex);
                Match matchNum = Regex.Match(lines[i], @"\d+");

                if (matchString.Success) //string match from file
                {
                    Debug.Write("String match line: " + i +" | ");
                    
                    if (matchNum.Success)// number match from string
                    {
                        Debug.Write("Found NUM "+ matchNum + " | ");
                        if (Int32.TryParse(matchNum.Value, out int val)) //number can cast to int
                        {
                            val++; //increase leadership value by 1
                            Debug.Write("Updated to NUM "+val+"\n");
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
            if (!File.Exists("Donnie 9-19-2022 H16M11S32.txt"))
            {
                Console.WriteLine("file not found");
            }
            if (File.Exists("Donnie 9-19-2022 H16M11S32.txt"))
            {
                Console.WriteLine("file found");
               
            }
            string playerFileName = "Donnie 9-19-2022 H16M11S32.txt";
            a.UpdatePlayerResults("Final Leadership", playerFileName);
            a.UpdatePlayerResults("Final Professionalism", playerFileName);
            a.UpdatePlayerResults("Final Technology", playerFileName);
            a.UpdatePlayerResults("Final Communication", playerFileName);
            a.UpdatePlayerResults("Final Critical Thinking",playerFileName);
        }
    }
}