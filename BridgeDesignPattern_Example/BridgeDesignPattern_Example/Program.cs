using System;

namespace BridgeDesignPattern_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMassage send = new SendWithAPI(new SendEmail());
            send.SendMessage();
        }
    }
    // bridge
    public interface ISendMassage
    {
        public string SendMessage(string type);
    }
    public class SendSMS : ISendMassage
    {
        public string SendMessage(string type)
        {
            return "A SMS Massage with " + type;
        }
    }
    public class SendEmail : ISendMassage
    {
        public string SendMessage(string type)
        {
            return "A Email Massage with " + type;
        }
    }

    // Abstraction class
    public abstract class SendMassage 
    {
        public readonly ISendMassage _sendMassage;
        public SendMassage(ISendMassage sendMassage)
        {
            _sendMassage = sendMassage;
        }
        public abstract void SendMessage();
    }
    public class SendWithAPI : SendMassage
    { 
        public SendWithAPI(ISendMassage sendMassage) : base (sendMassage)
        {}
        public override void SendMessage()
        {
          Console.WriteLine(_sendMassage.SendMessage("Api"));
        }
    }

    public class SendWithWebService : SendMassage
    {
        public SendWithWebService(ISendMassage sendMassage) : base(sendMassage)
        { }
        public override void SendMessage()
        {
            Console.WriteLine(_sendMassage.SendMessage("WebService"));
        }
    }
}
