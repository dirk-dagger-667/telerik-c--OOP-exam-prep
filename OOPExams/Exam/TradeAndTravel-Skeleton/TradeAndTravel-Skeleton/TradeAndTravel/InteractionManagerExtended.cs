using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class InteractionManagerExtended : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            base.HandlePersonCommand(commandWords, actor);

            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    break;
            }
        }
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            if (itemTypeString == "armor")
            {
                base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }

            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    break;
            }

            return item;
        }
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            if (personTypeString != "merchant")
            {
                return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

            Person person = null;
            person = new Merchant(personNameString, personLocation);

            return person;
        }
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            if (locationTypeString == "town")
            {
                return base.CreateLocation(locationTypeString, locationName);
            }

            Location location = null;

            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    break;
            }

            return location;
        }
        public void HandleGatherInteraction(Person person, string newItemName)
        {
            if (person.Location.LocationType == LocationType.Forest)
            {
                if (person.ListInventory().Exists(x => x.ItemType == ItemType.Weapon))
                {
                    this.AddToPerson(person, new Wood(newItemName, null));
                }
            }
            else if (person.Location.LocationType == LocationType.Mine)
            {
                if (person.ListInventory().Exists(x => x.ItemType == ItemType.Armor))
                {
                    this.AddToPerson(person, new Iron(newItemName, null));
                }
            }
        }
        public void HandleCraftInteraction(Person person, string itemType, string newItemName)
        {
            if (itemType == "weapon")
            {
                if (person.ListInventory().Exists(x => x.ItemType == ItemType.Iron) && person.ListInventory().Exists(x => x.ItemType == ItemType.Wood))
                {
                    this.AddToPerson(person, new Weapon(newItemName, null));
                }
            }
            else if (itemType == "armor")
            {
                if (person.ListInventory().Exists(x => x.ItemType == ItemType.Iron))
                {
                    this.AddToPerson(person, new Armor(newItemName, null));
                }
            }
        }
    }
}
