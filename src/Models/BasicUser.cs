using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Models
{
    public class BasicUser : User
    {
        public BasicUser(IMediator mediator, string name) : base(mediator, name)
        {
        }

        public override void ReceiveMessage(string sender, string message)
        {
            Console.WriteLine($"  → [{Name}] Received from {sender}: {message}");
        }

        public override void ReceivePrivateMessage(string sender, string message)
        {
            Console.WriteLine($"  → [{Name}] 🔒 Private message from {sender}: {message}");
        }

        public override void ReceiveNotification(string notification)
        {
            Console.WriteLine($"  → [{Name}] ℹ️ {notification}");
        }
    }
}
