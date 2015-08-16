namespace TradeAndTravel
{
    public class Wood: Item
    {
        private const int initialValue = 2;
        
        public Wood(string name, Location location)
            :base(name, Wood.initialValue, ItemType.Wood, location)
        {

        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value -= 1;
            }
        }
    }
}
