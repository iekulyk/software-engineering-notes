namespace Adapter
{
    public class Adapter : INewCharacterConverter
    {
        private readonly LegacyCharacterConverter _adaptee;

        public Adapter(LegacyCharacterConverter adaptee)
        {
            _adaptee = adaptee;
        }

        public string ConvertToStringCode(char letter)
        {
            return _adaptee.ConvertToCode(letter).ToString();
        }
    }
}
