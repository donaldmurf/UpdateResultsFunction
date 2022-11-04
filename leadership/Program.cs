using System;
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

            var allLines = File.ReadAllLines(playerFileName); //read file into lines var
            int i = -1;

            foreach (string line in allLines) //iterate though all strings in file
            {
                i++;

                //Final Self Assesment
                if (line.Contains("Final"))
                {
                    string finalStatRegex = @"^\s+-" + resultName + @"_*:\s*\d*\s?$"; //Match for Final Stats section

                    Match matchFinalStat = Regex.Match(line, finalStatRegex); //UPDATE for multiple matches
                    Match matchNum = Regex.Match(allLines[i], @"\d+"); //Match num in string

                    if (matchFinalStat.Success && matchNum.Success) //string match from file
                    {
                        if (Int32.TryParse(matchNum.Value, out int val))
                        {
                            val++; //increase leadership value by 1

                            allLines[i] = Regex.Replace(matchFinalStat.ToString(), matchNum.ToString(), val.ToString()); //(input, pattern, replacement)  (original string, found num, updated num)
                        }
                    }
                }

                //Videos Watched
                else if (line.Contains("Video"))
                {
                    //string InterviewRegex = @"\s*-[a-zA-Z]+:" + resultName + "+_+:\\s*NO";
                    string InterviewRegex = @"\s*-Video:" + resultName + "+_+:\\s*NO";
                    Match matchVideo = Regex.Match(line, InterviewRegex);
                    Match matchAnswerNO = Regex.Match(line, "NO");
                    if (matchVideo.Success && matchAnswerNO.Success)
                    {
                        allLines[i] = Regex.Replace(matchVideo.ToString(), matchAnswerNO.ToString(), "YES");
                    }
                }
                //Informational Books Read
                else if (line.Contains("Book"))
                {
                    //previously tried regex kept for making/editing template
                    // s*-Book:([A-Za-z0-9 !',+.]+)++.+
                    //s*-Book:Team Synergy+_+:\s*NO
                    //s*-Book:([CompTia A+ Certification Prep Questions])+:\s*NO
                    string BookRegex = @"s*-Book:(" + resultName + ")_+:\\s*NO";
                    Match matchBook = Regex.Match(line, BookRegex);
                    Match matchAnswerNO = Regex.Match(line, "NO");
                    if (matchBook.Success && matchAnswerNO.Success)
                    {
                        allLines[i] = Regex.Replace(matchBook.ToString(), matchAnswerNO.ToString(), "YES");
                    }
                }
                // Interview Performance STAR
                else if (line.Contains("STAR"))
                {
                }
                // Interview Performance VALUE
                else if (line.Contains("VALUE"))
                {
                }
            }
            File.WriteAllLines(playerFileName, allLines); //rewerite file with update
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

            string playerFileName = "programmer 10-30-2022 H21M11S10.txt";

            //final stats
            //a.UpdatePlayerResults("Final Leadership",playerFileName);
            //a.UpdatePlayerResults("Final Professionalism", playerFileName);
            //a.UpdatePlayerResults("Final Technology", playerFileName);
            //a.UpdatePlayerResults("Final Communication", playerFileName);
            //a.UpdatePlayerResults("Final Critical Thinking", playerFileName);

            //videos
            //a.UpdatePlayerResults("Interview Prep", playerFileName);
            //a.UpdatePlayerResults("Networking", playerFileName);
            //a.UpdatePlayerResults("Personal Branding", playerFileName);
            //a.UpdatePlayerResults("Star", playerFileName);
            //a.UpdatePlayerResults("Survive Adapt and Flourish", playerFileName);
            //a.UpdatePlayerResults("Sweet Spot", playerFileName);
            //a.UpdatePlayerResults("Value", playerFileName);

            //books
            a.UpdatePlayerResults("What to Say and How to Say It!", playerFileName);
            a.UpdatePlayerResults("Brain Teasers", playerFileName);
            a.UpdatePlayerResults("Team Synergy", playerFileName);
            a.UpdatePlayerResults("Hiring Manager's Guide to Everything", playerFileName);
            a.UpdatePlayerResults("Principles of Management", playerFileName);
            a.UpdatePlayerResults("Employment Laws", playerFileName);
            a.UpdatePlayerResults("CompTia A plus Certification Prep Questions", playerFileName);
            a.UpdatePlayerResults("Intro to Hardware", playerFileName);
            a.UpdatePlayerResults("Troubleshooting 101", playerFileName);
            a.UpdatePlayerResults("Guide to Networking", playerFileName);
            a.UpdatePlayerResults("How to Be a Better Leader", playerFileName);
            a.UpdatePlayerResults("Into to Python", playerFileName);
            a.UpdatePlayerResults("Software Engineering Principles", playerFileName);
            a.UpdatePlayerResults("Debugging 101", playerFileName);
            a.UpdatePlayerResults("Game Design", playerFileName);
            a.UpdatePlayerResults("Working in a Team", playerFileName);
            a.UpdatePlayerResults("Microswift Office for Dummies", playerFileName);
            a.UpdatePlayerResults("Principles of Engineering", playerFileName);
            a.UpdatePlayerResults("I Inc., Career Planning and Personal", playerFileName);
            a.UpdatePlayerResults("Entrepreneurship", playerFileName);
            a.UpdatePlayerResults("Tiger in the Office", playerFileName);
        }
    }
}