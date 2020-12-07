namespace PasswordPhilosophy
{
    internal static class TobogganPasswordFactory
    {
        internal static TobogganPassword From(string passwordString)
        {
            var parts = passwordString.Split(' ');
            var password = parts[2];
            var character = parts[1][0];
            var occurrencesPart = parts[0].Split('-');
            var firstPositionOfCharacter = int.Parse(occurrencesPart[0]);
            var secondPositionOfCharacter = int.Parse(occurrencesPart[1]);

            return new TobogganPassword(
                firstPositionOfCharacter,
                secondPositionOfCharacter,
                character,
                password);
        }
    }
}
