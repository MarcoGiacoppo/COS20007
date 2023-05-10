namespace SwinAdventure
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name;
            string desc;
            Player player;

            Console.WriteLine("Welcome to SwinAdventure!");

            Console.WriteLine("\nEnter Player Name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter Player Description:");
            desc = Console.ReadLine();

            player = new Player(name, desc);

            Item sword = new Item(new string[] { "Sword" }, "a golden sword", "This is a golden sword");
            Item knife = new Item(new string[] { "Knife" }, "a sharp knife", "This is a sharp knife");
            Item gem = new Item(new string[] { "Diamond" }, "a valuable gem", "This is an expensive item");

            Bag bag = new Bag(new string[] { "Bag" }, "big bag", "This is a big bag");

            player.Inventory.Put(sword);
            player.Inventory.Put(knife);
            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            bool quit = false;
            string cmd;
            LookCommand look = new LookCommand();

            while (!quit)
            {
                Console.WriteLine("\nEnter a Command:");
                cmd = Console.ReadLine();

                if (cmd == "quit")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine(look.Execute(player, cmd.Split()));
                }
            }
        }
    }
}