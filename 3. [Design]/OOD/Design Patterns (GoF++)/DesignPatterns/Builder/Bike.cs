namespace Builder
{
    public class Bike
    {
        public string Ganty { get; set; }
        public string Rim { get; set; }
        public string Tires { get; set; }
        public string Derailleur { get; set; }
        public string Breaks { get; set; }

        public override string ToString()
        {
            return $"{Ganty}, {Rim}, {Tires}, {Derailleur}, {Breaks}";
        }
    }
}