namespace Flyweight
{
    public class Goblin : Unit
    {
        public Goblin()
        {
            Name = "Goblin";
            Health = 8;
            Picture = Program.UnitImagesFactory.CreateImage<Goblin>();
            //Picture = Image.FromFile(@"C:\Users\Evgen\Documents\GitHub\APro\3. [Design]\OOD\Design Patterns (GoF++)\DesignPatterns\Flyweight\Goblin.jpg");
        }
    }
}