using System;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1)
            {
                return "Where do you want to move?";
            }
            else if (text.Length > 2)
            {
                return "Error in move input";
            }
            else
            {
                string direction = text[1].ToLower();

                Path path = p.Location.findPath(direction);
                if (path != null)
                {
                    p.Move(path);
                    return $"You went {path.Name}\nYou have arrived in {path.Destination.Name}";
                }

                return "Error in direction!";
            }
        }
    }
}
