namespace PasswordPhilosophy
{
    internal static class PasswordFactory
    {
        internal static Password From(string passwordString)
        {
            var parts = passwordString.Split(' ');
            var password = parts[2];
            var character = parts[1][0];
            var occurrencesPart = parts[0].Split('-');
            var minOccurrencesOfCharacter = int.Parse(occurrencesPart[0]);
            var maxOccurrencesOfCharacter = int.Parse(occurrencesPart[1]);

            return new Password(
                minOccurrencesOfCharacter,
                maxOccurrencesOfCharacter,
                character,
                password);
        }
    }
}
