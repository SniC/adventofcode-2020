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

            var bag = FindBag("shiny", "gold", bags);
            Console.WriteLine(result.Count());

            var amount = CalculateAmountOfBagsRequiredRecursively(bags, bag);
            Console.WriteLine("Amount of bags required {0}", amount);

            Console.ReadLine();
        }

        static Bag FindBag(string material, string color, List<Bag> bags)
        {
            return bags.FirstOrDefault(x => x.Material == material && x.Color == color);
        }

        static int CalculateAmountOfBagsRequiredRecursively(List<Bag> bags, Bag bag)
        {
            int count = 0;

            bag.BagContent.ForEach(x =>
            {
                count += x.Amount;
                var foundBag = FindBag(x.Bag.Material, x.Bag.Color, bags);
                count += CalculateAmountOfBagsRequiredRecursively(bags, foundBag) * x.Amount;
            });

            return count;
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
