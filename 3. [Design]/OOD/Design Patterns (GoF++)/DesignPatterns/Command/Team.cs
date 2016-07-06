using System;
using System.Collections.Generic;

namespace Command
{
    public class Team
    {
        private readonly string _teamName;
        public Team(string teamName)
        {
            _teamName = teamName;
        }

        public void CompleteProject(List<string> requirements)
        {
            foreach (var requirement in requirements)
            {
                Console.WriteLine("{1} : User Story {0} has been completed", requirement, _teamName);
            }
        }
    }
}