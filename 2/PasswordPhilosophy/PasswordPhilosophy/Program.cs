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

            Console.WriteLine(amountOfValidPasswords);
            Console.ReadLine();
        }
    }
}
