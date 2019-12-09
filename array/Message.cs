using System;
using System.Collections.Generic;
using System.Text;

namespace array
{
    public interface IMessage
    {
        void PrintMessage();
    }
    public abstract class Message: IMessage
    {
        protected string _text;
        public Message(string text)
        {
            _text = text;    
        }

        abstract public void PrintMessage();
    }

    public class SimpleMessage : Message
    {
        public SimpleMessage(string text): base(text)
        {
        }

        public override void PrintMessage()
        {
            Console.WriteLine(_text);
        }
    }

    public class AlertMessage : Message
    {
        public AlertMessage(string text): base(text)
        {

        }
        public override void PrintMessage()
        {
            Console.Beep();
            Console.WriteLine(_text);
        }
    }


    public  abstract  class DecordMessage: IMessage
    {
        protected Message _message;
        public DecordMessage(Message message)
        {
            _message = message;
        }

        public abstract void PrintMessage();
    }

    public class NormanMessage :DecordMessage
    {
        public NormanMessage(Message message): base(message)
        {
        }

        public override void PrintMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            _message.PrintMessage();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class ErrorMessage: DecordMessage
    {
        public ErrorMessage(Message message): base(message)
        {}

        public override void PrintMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _message.PrintMessage();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
