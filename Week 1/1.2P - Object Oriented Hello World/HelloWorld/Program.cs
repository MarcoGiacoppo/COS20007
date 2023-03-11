using System;
using message;

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Message myMessage = new Message("Hello World - From Message Object");
            myMessage.Print();

            Message[] messages = new Message[5];
            messages[0] = new Message("Welcome back!");
            messages[1] = new Message("What a lovely name");
            messages[2] = new Message("Great name!");
            messages[3] = new Message("Oh hi!");
            messages[4] = new Message("That is a silly name");

            Console.WriteLine("Enter name:");
            String name = Console.ReadLine();

            if (name.ToLower() == "marco")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "mario")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "michael")
            {
                messages[2].Print();
            }
            else if (name.ToLower() == "kimmy")
            {
                messages[3].Print();
            }
            else
                messages[4].Print();
        }
    }
}