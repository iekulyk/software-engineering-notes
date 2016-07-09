using System;
using System.Collections.Generic;
using System.Drawing;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {

            var units = new List<Unit>();

            for (int i = 0; i < 150; i++)
            {
                units.Add(new Goblin());
            }

            for (int i = 0; i < 450; i++)
            {
                units.Add(new Dragon());
            }

            Console.ReadLine();
        }

        public class UnitImagesFactory
        {
            public static Dictionary<Type, Image> Images = new Dictionary<Type, Image>();

            public static Image CreateImage<T>() where T : Unit
            {
                if (!Images.ContainsKey(typeof(T)))
                {
                    Images.Add(typeof(T), Image.FromFile(@"C:\Users\Evgen\Documents\GitHub\APro\3. [Design]\OOD\Design Patterns (GoF++)\DesignPatterns\Flyweight\" + typeof(T).Name + ".jpg"));
                }
                return Images[typeof(T)];
            }
        }
    }
}
