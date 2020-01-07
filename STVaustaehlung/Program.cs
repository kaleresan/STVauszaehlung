using System;
using System.Collections.Generic;
using System.Linq;

namespace STVaustaehlung
{
    internal class Program
    {
        private static List<Option> Options = new List<Option>();
        private static List<Vote> Votes = new List<Vote>();

        private static void Main(string[] args)
        {
            GetOptions();
            GetVotes();

            Console.WriteLine();

            CountVotes();
            Console.WriteLine(Options.First().Name + " gewinnt");

            Console.ReadKey();
        }

        private static void GetOptions()
        {
            Console.WriteLine("Bitte Trage alle wählbaren Optionen getrennt durch ein \",\" ein");
            string input = Console.ReadLine();
            string[] inputs = input.Split(',');
            for (int i = 0; i < inputs.Length; i++)
            {
                Options.Add(new Option(inputs[i], i));
            }
            Console.Clear();
        }

        private static void GetVotes()
        {
            string optionsstring = "";
            foreach (var option in Options)
            {
                optionsstring += "#" + option.ID + " " + option.Name + " | ";
            }
            Console.WriteLine(optionsstring);
            Console.WriteLine("Bitte gib nun für jede Stimme die Nummern der Optionen an, getrennt durch Kommas. (Bsp.: 2,3,1,4)");
            Console.WriteLine("Drucke Enter nach jeder Stimme, Wenn alle eingetragen sind, Schreibe \"ENDE\" und drücke Enter");
            Console.WriteLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("ENDE")) break;
                string[] inputs = input.Split(',');
                int n = -1;
                bool isNumeric = true;
                List<Option> vote = new List<Option>();

                for (int i = 0; i < inputs.Length; i++)
                {
                    isNumeric = int.TryParse(inputs[i], out n);
                    if (isNumeric && n > -1 && n < Options.Count)
                    {
                        vote.Add(Options[n]);
                    }
                    else
                    {
                        Console.WriteLine("ERROR at \"" + inputs[i] + "\", please try again");
                        break;
                    }
                }
                if (isNumeric && n > -1 && n < Options.Count)
                {
                    Votes.Add(new Vote(vote));
                    Console.Clear();
                    Console.WriteLine(optionsstring);
                    Console.WriteLine("Bitte gib nun für jede Stimme die Nummern der Optionen an, getrennt durch Kommas. (Bsp.: 2,3,1,4)");
                    Console.WriteLine("Drucke Enter nach jeder Stimme, Wenn alle eingetragen sind, Schreibe \"ENDE\" und drücke Enter");
                    Console.WriteLine();
                    foreach (var vote1 in Votes)
                    {
                        string output = "";
                        foreach (var option in vote1.Votes)
                        {
                            output += option.Name + ", ";
                        }
                        Console.WriteLine(output);
                    }
                }
            }
        }

        private static void CountVotes()
        {
            foreach (var item in Options)
            {
                item.Votes = 0;
            }

            foreach (Vote vote in Votes)
            {
                Options.Where(c => c.ID == vote.Votes.First().ID).First().Votes++;
            }

            Option looser = Options.First(); ;
            int looseramount = Int32.MaxValue;
            foreach (Option option1 in Options)
            {
                Console.WriteLine(option1.Name + ": " + option1.Votes);
                if (looseramount > option1.Votes)
                {
                    looseramount = option1.Votes;
                    looser = option1;
                }
            }
            foreach (var item in Votes)
            {
                item.Votes.Remove(looser);
            }
            Options.Remove(looser);
            Console.WriteLine(looser.Name + " hat die wenigsten Stimmen");
            Console.WriteLine();

            if(Options.Count > 1)
            {
                CountVotes();
            }

        }
    }
}