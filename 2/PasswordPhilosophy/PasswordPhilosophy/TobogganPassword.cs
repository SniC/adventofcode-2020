namespace PasswordPhilosophy
{
    internal class TobogganPassword
    {
        private readonly int firstPositionOfCharacter;
        private readonly int secondPositionOfCharacter;
        private readonly char character;
        private readonly string password;

        internal TobogganPassword(
            int firstPositionOfCharacter,
            int secondPositionOfCharacter,
            char character,
            string password)
        {
            this.firstPositionOfCharacter = firstPositionOfCharacter;
            this.secondPositionOfCharacter = secondPositionOfCharacter;
            this.character = character;
            this.password = password;
        }

        internal bool isValid()
        {
            bool firstMatch = this.password[firstPositionOfCharacter - 1] == this.character;
            bool secondMatch = this.password[secondPositionOfCharacter - 1] == this.character;

            return firstMatch != secondMatch;
        }
    }
}
