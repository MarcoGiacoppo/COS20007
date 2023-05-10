using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
	public class Inventory
	{
		private List<Item> _items;

		//constructor
		public Inventory()
		{
			_items = new List<Item>();
		}

		//methods
		public bool HasItem(string id)
		{
			foreach (Item item in _items)
			{
				return item.AreYou(id);
			}
			return false;
		}

		//add item
		public void Put(Item itm)
		{
			_items.Add(itm);
		}

		//removing and returning
		public Item Take(string id)
		{
			Item itm = this.Fetch(id);

			if (itm != null)
			{
				_items.Remove(itm);
			}
			return itm;
		}

		//returns the 'item' with the specified id
		public Item Fetch(string id)
		{
			foreach (Item itm in _items)
			{
				if (itm.AreYou(id))
				{
					return itm;
				}
			}
			return null;
		}

		public string ItemList
		{
			get
			{
				string itemList = "";

				foreach (Item itm in _items)
				{
					itemList += $"{itm.ShortDescription}\n";
				}
				return itemList;
			}
		}
	}
}

