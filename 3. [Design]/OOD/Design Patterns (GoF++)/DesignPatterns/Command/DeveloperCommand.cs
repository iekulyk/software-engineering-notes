namespace Command
{
    public class DeveloperCommand : ICommand
    {
        protected Developer Developer { get; set; }
        public string ProjectName { get; set; }

        public DeveloperCommand(Developer developer, string projectName)
        {
            Developer = developer;
            ProjectName = projectName;
        }

        public void Execute()
        {
            Developer.DoAllWork(ProjectName);
        }
    }
}