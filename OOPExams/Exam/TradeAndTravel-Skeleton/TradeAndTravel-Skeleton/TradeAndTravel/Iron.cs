namespace TradeAndTravel
{
    public class Iron: Item
    {
        private const int initialValue = 3;
        
        public Iron(string name, Location location)
            :base(name, Iron.initialValue, ItemType.Iron, location)
        {

        }
    }
}
