namespace Flyweight
{
    public class Dragon : Unit
    {
        public Dragon()
        {
            Name = "Goblin";
            Health = 8;
            Picture = Program.UnitImagesFactory.CreateImage<Dragon>();
            //Picture = Image.FromFile(@"C:\Users\Evgen\Documents\GitHub\APro\3. [Design]\OOD\Design Patterns (GoF++)\DesignPatterns\Flyweight\Goblin.jpg");
        }
    }
}