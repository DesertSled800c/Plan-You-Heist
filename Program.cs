using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            int bankDifficulty = GetPositiveIntegerInput("Enter a value for the bank difficulty");

            List<TeamMember> team = new();
            bool creatingTeam = true;
            while (creatingTeam)
            {
                TeamMember teamMember = CreateNewTeamMember();
                if (teamMember != null)
                {
                    team.Add(teamMember);
                }
                else
                {
                    creatingTeam = false;
                }
            }

            TeamMember CreateNewTeamMember()
            {
                Console.WriteLine("");
                Console.WriteLine("CREATE A NEW TEAM MEMBER");
                Console.Write("Team member name: ");
                string name = Console.ReadLine().Trim();

                if (name == "")
                {
                    return null;
                }

                int skillLevel = GetPositiveIntegerInput($"Enter a skill level for {name}");

                double courageFactor;
                while (true)
                {
                    Console.Write($"Enter a courage factor between 0.0 to 2.0 for {name}: ");
                    string answer = Console.ReadLine();
                    bool isDouble = double.TryParse(answer, out courageFactor);
                    if (isDouble && courageFactor > 0.0 && courageFactor <= 2.0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a value between 0.0 and 2.0");
                    }
                }

                return new TeamMember(name, skillLevel, courageFactor);
            }

            Console.WriteLine("");
            Console.WriteLine($"Your heist has {team.Count} team members.");

            int numOfScenarios = GetPositiveIntegerInput(
                "Number of heist simulations to run?"
            );

            decimal successfulHeists = 0;
            decimal failedHeists = 0;

            foreach (int scenarioNum in Enumerable.Range(0, numOfScenarios))
            {
                bool successful = RunHeist(bankDifficulty, team, scenarioNum);
                if (successful)
                {
                    successfulHeists++;
                }
                else
                {
                    failedHeists++;
                }
            }

            decimal oddsOfSuccess = successfulHeists / numOfScenarios * 100;

            Console.WriteLine("LAST HEIST RESULT");
            Console.WriteLine($"Successful runs: {successfulHeists}");
            Console.WriteLine($"Failed runs: {failedHeists}");
            Console.WriteLine($"Odds of success = {oddsOfSuccess}%");

            int GetPositiveIntegerInput(string prompt)
            {
                while (true)
                {
                    Console.Write($"\n{prompt}: ");
                    string answer = Console.ReadLine();
                    int res;
                    bool isNumber = int.TryParse(answer, out res);
                    if (isNumber && res > 0)
                    {
                        return res;
                    }
                    else
                    {
                        Console.WriteLine("Enter a positive integer.");
                    }
                }
            }

            bool RunHeist(int difficultyLevel, List<TeamMember> team, int runNumber)
            {

                int luckValue = new Random().Next(-10, 10);
                difficultyLevel += luckValue;

                int sumOfSkillLevels = 0;
                foreach (TeamMember member in team)
                {
                    sumOfSkillLevels += member.SkillLevel;
                }

                Console.WriteLine("");
                Console.WriteLine($"HEIST RESULT {runNumber + 1}");
                Console.WriteLine($"Team Skill Level: {sumOfSkillLevels}");
                Console.WriteLine($"Bank Difficulty: {difficultyLevel}");

                if (sumOfSkillLevels >= difficultyLevel)
                {
                    Console.WriteLine("Dude! Thats a steal!!!!!");
                    Console.WriteLine("");

                    return true;
                }
                else
                {
                    Console.WriteLine("Ya fool, you lost it ALLLL");
                    Console.WriteLine("");

                    return false;
                }
            }
        }
    }
}