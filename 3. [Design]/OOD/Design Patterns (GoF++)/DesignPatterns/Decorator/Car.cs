using System;

namespace Decorator
{
    public class Car
    {
        protected string BrandName { get; set; }

        public virtual void Go()
        {
            Console.WriteLine("I'm {0} and I'm on my way...", BrandName);
        }
    }
}