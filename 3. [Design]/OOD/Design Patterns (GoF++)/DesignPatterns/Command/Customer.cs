using System.Collections.Generic;

namespace Command
{
    public class Customer
    {
        private List<ICommand> Commands = new List<ICommand>();
        public void Add(ICommand command)
        {
            Commands.Add(command);
        }

        public void SignContract()
        {
            foreach (var command in Commands)
            {
                command.Execute();
            }
        }
    }
}