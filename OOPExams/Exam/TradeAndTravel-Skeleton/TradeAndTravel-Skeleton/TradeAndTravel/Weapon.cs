namespace TradeAndTravel
{
    using System.Collections.Generic;
    public class Weapon: Item
    {
        const int GeneralWeaponValue = 10;

        public Weapon(string name, Location location)
            :base(name, Weapon.GeneralWeaponValue, ItemType.Weapon, location)
        {

        }
        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron, ItemType.Wood };
        }
    }
}
