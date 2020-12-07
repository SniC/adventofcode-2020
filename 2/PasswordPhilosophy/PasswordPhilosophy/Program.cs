using System;
using System.Linq;

namespace PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = new FileReader().GetLines();

            var amountOfValidPasswords = lines
                .Select(line => PasswordFactory.From(line))
                .Where(password => password.isValid())
                .Count();

            var amountOfValidTobogganPasswords = lines
                .Select(line => TobogganPasswordFactory.From(line))
                .Where(password => password.isValid())
                .Count();

            Console.WriteLine("Amount of valid passwords for the sled rental place: {0}", amountOfValidPasswords);
            Console.WriteLine("Amount of valid passwords for Toboggan: {0}", amountOfValidTobogganPasswords);
            Console.ReadLine();
        }
    }
}
