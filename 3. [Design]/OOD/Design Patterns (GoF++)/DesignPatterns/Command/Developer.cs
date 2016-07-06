using System;

namespace Command
{
    public class Developer
    {
        public void DoAllWork(string projectName)
        {
            Console.WriteLine("Developer Done all Work for project {0}", projectName);
        }
    }
}