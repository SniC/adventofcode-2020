using System;
using System.Collections.Generic;
using System.Linq;

namespace HandyHaversacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = new FileReader().GetLines();

            var bags = lines.Select(line =>
            {
                return CreateFromLine(line);
            }).ToList();

            var result = FindBagsThatFit(bags, new Bag("shiny", "gold"));

            Console.WriteLine(result.Count());
            Console.ReadLine();
        }

        static List<Bag> FindBagsThatFit(List<Bag> bags, Bag bag, List<Bag> foundBags = null)
        {
            if (foundBags == null)
            {
                foundBags = new List<Bag>();
            }

            foreach (var index in bags)
            {
                if (index.BagContent.Any(
                    x => x.Bag.Material == bag.Material
                    && x.Bag.Color == bag.Color))
                {
                    foundBags.Add(index);
                    FindBagsThatFit(bags, index, foundBags);
                }
            }

            return foundBags.Distinct().ToList();
        }

        static Bag CreateFromLine(string line)
        {
            var bagString = line.Split("contain")[0].Trim();
            var contentString = line.Split("contain")[1].Trim();

            var color = bagString.Split(" ")[1].Trim();
            var contentBagStrings = contentString.Split(",").Select(x => x.Trim());

            return new Bag(
                material: GetMaterial(bagString),
                color: GetColor(bagString),
                bagContent: GetBagContent(contentBagStrings.ToArray()));
        }

        static string GetMaterial(string bagString) {
            return bagString.Split(" ")[0].Trim();
        }

        static string GetColor(string bagString)
        {
            return bagString.Split(" ")[1].Trim();
        }

        static List<BagContent> GetBagContent(string[] contentBagStrings)
        {
            return contentBagStrings
                .Where(x => x != "no other bags.")
                .Select(x =>
            {
                var amount = int.Parse(x.Split(" ")[0].Trim());
                var material = x.Split(" ")[1].Trim();
                var color = x.Split(" ")[2].Trim();
                return new BagContent(amount, new Bag(material, color));
            }).ToList();
        }
    }
}
