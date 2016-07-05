namespace Bridge
{
    public interface ISoftwareCompany
    {
        void CodeBackEnd();
        void CodeFrontEnd();
        void DrinkBeer();
        void CodeProject();
        void NegotioateContract();
        IFullStackDevelopementTeam DevelopementTeam { get; set; }
    }
}