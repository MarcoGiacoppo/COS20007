namespace SwinAdventure
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name;
            string desc;
            Player player;

            Console.WriteLine("Welcome to SwinAdventure!\n");

            // PLayer Descriptions
            Console.WriteLine("Enter Player Name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter Player Description:");
            desc = Console.ReadLine();

            player = new Player(name, desc);

            // Setting items and inventory
            Item sword = new Item(new string[] { "Sword" }, "a golden sword", "This is a golden sword");
            Item knife = new Item(new string[] { "Knife" }, "a sharp knife", "This is a sharp knife");
            Item gem = new Item(new string[] { "Diamond" }, "a valuable gem", "This is an expensive item");

            Bag bag = new Bag(new string[] { "Bag" }, "big bag", "This is a big bag");

            player.Inventory.Put(sword);
            player.Inventory.Put(knife);
            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            // Setting up location
            Item skull = new Item(new string[] { "skull" }, "a skull", "This is a creepy skull");
            Location jungle = new Location("a jungle", "This is a scary jungle");
            Location tower = new Location("a tower", "This is a tilted tower");

            Path jungleSouth = new Path(new string[] { "south", "s" }, "south", "huh", tower);
            jungle.AddPath(jungleSouth);

            jungle.Inventory.Put(skull);
            player.Location = jungle;

            // Command Loop
            bool quit = false;
            string cmd;
            string[] cmdArray;
            LookCommand look = new LookCommand();
            MoveCommand move = new MoveCommand();


            while (!quit)
            {
                Console.WriteLine("\nCommand:");
                cmd = Console.ReadLine();
                cmdArray = cmd.ToLower().Split();

                if (cmd == "quit")
                {
                    quit = true;
                }
                else if (cmdArray[0] == "look")
                {
                    Console.WriteLine(look.Execute(player, cmdArray));
                }
                else
                {
                    Console.WriteLine(move.Execute(player, cmdArray));
                }
            }
        }
    }
}