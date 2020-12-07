using System.Linq;

namespace PasswordPhilosophy
{
    internal class Password
    {
        private readonly int minimalAmountOfCharacter;
        private readonly int maxAmountOfCharacter;
        private readonly char character;
        private readonly string password;

        internal Password(
            int minOccurrencesOfCharacter,
            int maxOccurrencesOfCharacter,
            char character,
            string password)
        {
            this.minimalAmountOfCharacter = minOccurrencesOfCharacter;
            this.maxAmountOfCharacter = maxOccurrencesOfCharacter;
            this.character = character;
            this.password = password;
        }

        private int occurrencesOfCharacter => this.password.Count(x => x == this.character);

        internal bool isValid() => 
            this.occurrencesOfCharacter <= maxAmountOfCharacter 
            && this.occurrencesOfCharacter >= minimalAmountOfCharacter;
    }
}
