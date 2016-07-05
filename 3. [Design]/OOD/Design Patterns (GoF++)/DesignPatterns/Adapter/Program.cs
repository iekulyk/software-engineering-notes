using System;

namespace Adapter
{
    class Program
    {
        static void Main()
        {
            var newConverter = new NewCharacterConverter();
            CharacterConverterConsumer.SetCharacterConverter(newConverter);

            var legacyConverter = new LegacyCharacterConverter();
            var adapter = new Adapter(legacyConverter);
            CharacterConverterConsumer.SetCharacterConverter(adapter);

            Console.ReadLine();
        }
    }
}
