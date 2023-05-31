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
			return _items.Any(item => item.AreYou(id));
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

