using System;
using System.Collections.Generic;

namespace Heist
{
    public class TeamMember
    {
        public string Name { get; }
        public int SkillLevel { get; }
        public double CourageFactor { get; }
        public TeamMember(string name, int skill, double courage)
        {
            Name = name;
            SkillLevel = skill;
            CourageFactor = courage;
        }

        public void TeamMemberStats()
        {
            Console.WriteLine("");
            Console.WriteLine(Name);
            Console.WriteLine($"Your skill level is {SkillLevel}");
            Console.WriteLine($"Your courage Factor is {CourageFactor}");
        }
    }
}