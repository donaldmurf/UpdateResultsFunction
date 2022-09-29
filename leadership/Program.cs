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
        public void UpdatePlayerResults(string resultName, string FileToUpdate)
        {
            string playerFileName = FileToUpdate;

            var lines = File.ReadAllLines(playerFileName); //read file into lines var
            int i = -1;

            foreach (string s in lines) //iterate though all strings in file
            {
                i++;

                //Final Self Assesment
                if (s.Contains("Final"))
                {
                    string finalStatRegex = @"^\s+-" + resultName + @"_*:\s*\d*\s?$"; //Match for Final Stats section

                    Match matchFinalStat = Regex.Match(s, finalStatRegex); //UPDATE for multiple matches
                    Match matchNum = Regex.Match(lines[i], @"\d+"); //Match num in string

                    if (matchFinalStat.Success && matchNum.Success) //string match from file
                    {
                        if (Int32.TryParse(matchNum.Value, out int val))
                        {
                            val++; //increase leadership value by 1

                            lines[i] = Regex.Replace(matchFinalStat.ToString(), matchNum.ToString(), val.ToString()); //(input, pattern, replacement)  (original string, found num, updated num)
                        }
                        else
                        {
                            Debug.Write("ERROR:Line " + i + " unable to convert " + matchNum.Value + " to an INT for update");
                        }
                    }
                }

                //Videos Watched
                else if (s.Contains("Video"))
                {
                    string InterviewRegex = "-[a-zA-Z]+:"+resultName+"_+: NO"; //^    -[a-zA-Z]+:Interview Prep_+: NO$

                    Match matchVideo = Regex.Match(s, InterviewRegex);
                    Match matchAnswerNO = Regex.Match(s, "NO");
                    if (matchVideo.Success && matchAnswerNO.Success)
                    {
                        lines[i] = Regex.Replace(matchVideo.ToString(), matchAnswerNO.ToString(), "YES");

                    }
                }
                //Informational Books Read
                else if (s.Contains("Book"))
                {
                }
                // Interview Performance STAR
                else if (s.Contains("STAR"))
                {
                }
                // Interview Performance VALUE
                else if (s.Contains("VALUE"))
                {
                }
            }
            File.WriteAllLines(playerFileName, lines); //rewerite file with update
        }

        private static void Main(string[] args)
        {
            Program a = new Program();
            if (!File.Exists("programmer 9-29-2022 H16M31S32.txt"))
            {
                Console.WriteLine("file not found");
            }
            if (File.Exists("programmer 9-29-2022 H16M31S32.txt"))
            {
                Console.WriteLine("file found");
            }

            string playerFileName = "programmer 9-29-2022 H16M31S32.txt";

            //final stats
            //a.UpdatePlayerResults("Final Leadership", playerFileName);
            //a.UpdatePlayerResults("Final Professionalism", playerFileName);
            //a.UpdatePlayerResults("Final Technology", playerFileName);
            //a.UpdatePlayerResults("Final Communication", playerFileName);
            //a.UpdatePlayerResults("Final Critical Thinking", playerFileName);

            //videos
            a.UpdatePlayerResults("Interview Prep", playerFileName);
        }
    }
}