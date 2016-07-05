using System;

namespace Bridge
{
    public class DotNetFullStackDevelopementTeam : IFullStackDevelopementTeam
    {
        public void CodeBackEndWithUnitTests()
        {
            Console.WriteLine("Coding Back End with unit test with C#");
        }

        public void CodeFrontWithGreatUx()
        {
            Console.WriteLine("Coding Front End with great UX with React, VS and other FE things");
        }

        public void EstablishBackEndCi()
        {
            Console.WriteLine("Getting up TFS");
        }

        public void EstablishFrontEndCi()
        {
            Console.WriteLine("Getting up Gulp with TeamCity");
        }

        public void DrinkBeer()
        {
            Console.WriteLine("Drink Dark Beer");
        }
    }
}