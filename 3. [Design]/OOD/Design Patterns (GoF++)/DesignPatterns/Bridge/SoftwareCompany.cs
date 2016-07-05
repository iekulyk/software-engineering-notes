using System;

namespace Bridge
{
    class SoftwareCompany : ISoftwareCompany
    {
        public void CodeBackEnd()
        {
            DevelopementTeam.CodeBackEndWithUnitTests();
            DevelopementTeam.EstablishBackEndCi();
        }

        public void CodeFrontEnd()
        {
            DevelopementTeam.CodeFrontWithGreatUx();
            DevelopementTeam.EstablishFrontEndCi();
        }

        public void DrinkBeer()
        {
            Console.WriteLine("Company celebration of finished project");
        }

        public void CodeProject()
        {
            CodeBackEnd();
            CodeFrontEnd();
            DevelopementTeam.DrinkBeer();
        }

        public void NegotioateContract()
        {
            Console.WriteLine("Negotiating things done for highest payment");
        }

        public IFullStackDevelopementTeam DevelopementTeam { get; set; }
    }
}