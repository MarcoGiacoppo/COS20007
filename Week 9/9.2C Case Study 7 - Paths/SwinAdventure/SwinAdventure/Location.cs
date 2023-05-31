using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        //local variables
        private Inventory _inventory;
        private List<Path> _paths;

        //constructor
        public Location(string name, string desc) : base(new string[] { "house", "here" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        //methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public Path findPath(string path)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(path))
                {
                    return p;
                }
            }
            return null;
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        //properties
        public string PathList
{
    get
    {
        if (_paths.Count == 0)
        {
            return "There are no exits.";
        }

        if (_paths.Count == 1)
        {
            return "There is an exit " + _paths[0].Name + ".";
        }

        StringBuilder list = new StringBuilder("There are exits to ");
        foreach (Path path in _paths)
        {
            if (path != _paths.First())
            {
                list.Append(", ");
            }

            if (path == _paths.Last())
            {
                list.Append("and ");
            }

            list.Append(path.Name);
        }

        list.Append(".");

        return list.ToString();
    }
}


        public override string FullDescription
        {
            get
            {
                return $"You are in {Name}\n{Description}\n{PathList}\nHere you can see:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}