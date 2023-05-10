namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            string moveTo;
            string[] moveIds = new string[] { "move", "go", "head", "leave" };

            if (text.Length >= 3)
            {
                return "I don't know how to move like that";
            }
            else if (!moveIds.Contains(text[0]))
            {
                return "Error in move input";
            }
            else if (text.Length == 1)
            {
                return "Where do you want to move?";
            }
            else
            {

                moveTo = text[1];

                if (p.Locate(moveTo) is Path path)
                {
                    p.Move(path);

                    return $"You went {path.Name}\nYou have arrived in {path.Destination.Name}";
                }
                else
                {
                    return "Error in direction!";
                }
            }


        }
    }
}