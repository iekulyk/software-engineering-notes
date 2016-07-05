namespace Adapter
{
    class NewCharacterConverter : INewCharacterConverter
    {
        public string ConvertToStringCode(char letter)
        {
            return ((int)char.ToUpper(letter)).ToString();
        }
    }
}