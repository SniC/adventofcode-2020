namespace HandyHaversacks
{
    public class BagContent
    {
        public BagContent(int amount, Bag bag)
        {
            this.Amount = amount;
            this.Bag = bag;
        }

        public int Amount { get; set; }
        public Bag Bag { get; set; }
    }
}