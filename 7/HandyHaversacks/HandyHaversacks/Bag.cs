using System.Collections.Generic;

namespace HandyHaversacks
{
    public class Bag
    {
        public Bag(string material, string color, List<BagContent> bagContent = null)
        {
            this.Material = material;
            this.Color = color;
            this.BagContent = bagContent;
        }

        public string Material { get; }
        public string Color { get; }
        public List<BagContent> BagContent { get; }
    }
}
