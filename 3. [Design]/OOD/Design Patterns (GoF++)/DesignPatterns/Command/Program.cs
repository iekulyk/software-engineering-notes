using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {

            //Client
            var customer = new Customer();
            //Receiver
            var team = new Team("GreatTeam");

            var requirements = new List<string> { "Fancy SPA", "Good Scalability" };
            ICommand commandManager = new ProjectManagerCommand(team, requirements);

            var developer = new Developer();
            ICommand commandDeveloper = new DeveloperCommand(developer, "I");

            customer.Add(commandManager);
            customer.Add(commandDeveloper);

            customer.SignContract();

            Console.ReadLine();
        }
    }
}
