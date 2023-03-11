using System;

namespace message
{
    public class Message
        {
            private readonly string _text;
            
            public Message(string text)
        {
            _text = text;
        }
            public void Print()
        {
            Console.WriteLine(_text);
        }
        }
}
