using System.Collections.Generic;

namespace Command
{
    public class ProjectManagerCommand : ICommand
    {
        protected Team Team { get; set; }
        public List<string> Requirements { get; set; }

        public ProjectManagerCommand(Team team, List<string> requirements)
        {
            Team = team;
            Requirements = requirements;
        }

        public void Execute()
        {
            Team.CompleteProject(Requirements);
        }
    }
}