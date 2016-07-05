using System;

namespace Bridge
{
    public class NodeJsFullStackDevelopementTeam : IFullStackDevelopementTeam
    {
        public void CodeBackEndWithUnitTests()
        {
            Console.WriteLine("Coding Back End with unit test with Node.JS and mocha");
        }

        public void CodeFrontWithGreatUx()
        {
            Console.WriteLine("Coding Front End with great UX with React, VS and other FE things");
        }

        public void EstablishBackEndCi()
        {
            Console.WriteLine("Getting up TeamCity");
        }

        public void EstablishFrontEndCi()
        {
            Console.WriteLine("Getting up Gulp with TeamCity");
        }

        public void DrinkBeer()
        {
            Console.WriteLine("Drink light Beer");
        }
    }
}