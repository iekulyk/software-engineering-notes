using System;

namespace Adapter
{
    public class CharacterConverterConsumer
    {
        public static void SetCharacterConverter(INewCharacterConverter characterConverter)
        {
            Console.WriteLine(characterConverter.ConvertToStringCode('b')); // for example purposes
        }
    }
}