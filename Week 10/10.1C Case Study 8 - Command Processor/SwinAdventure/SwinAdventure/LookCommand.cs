using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) { }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container = null;
            string itemId = null;

            if (text.Length != 1 && text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            else
            {
                // The first word must be "look", 
                if (text[0] != "look")
                {
                    return "Error in look input";
                }
                if (text[0] == "look" && text.Length == 1)
                {
                    return p.Location.FullDescription;
                }
                // The second word must be "at"
                if (text.Length != 1 && text[1] != "at")
                {
                    return "What do you want to look at?";
                }
                // The fourth word must be "in"
                if (text.Length == 5 && text[3] != "in")
                {
                    return "What do you want to look in?";
                }

                switch (text.Length)
                {
                    case 1:
                        container = p; 
                        itemId = "location"; 
                        break;

                    case 3:
                        container = p;
                        itemId = text[2];
                        break;

                    case 5:
                        container = FetchContainer(p, text[4]);

                        if (container == null)
                        {
                            return $"I can't find the {text[4]}";
                        }
                        itemId = text[2];
                        break;
                }
                return LookAtIn(itemId, container);
            }
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }
            else
            {
                return $"I can't find the {thingId}";
            }
        }
    }
}

