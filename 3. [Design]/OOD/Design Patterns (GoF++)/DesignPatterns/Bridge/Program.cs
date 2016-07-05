using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodeJsTeam = new NodeJsFullStackDevelopementTeam();
            var dotNetTeam = new DotNetFullStackDevelopementTeam();

            var softwareCompany = new SoftwareCompany();

            softwareCompany.NegotioateContract();
            softwareCompany.DevelopementTeam = nodeJsTeam;
            softwareCompany.CodeProject();
            softwareCompany.DrinkBeer();

            softwareCompany.NegotioateContract();
            softwareCompany.DevelopementTeam = dotNetTeam;
            softwareCompany.CodeProject();
            softwareCompany.DrinkBeer();

            Console.ReadLine();
        }
    }
}
