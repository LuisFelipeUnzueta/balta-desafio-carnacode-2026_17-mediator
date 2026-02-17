using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Models
{
    public class AdminUser : User
    {
        public AdminUser(IMediator mediator, string name) : base(mediator, name)
        {
        }

        public override void ReceiveMessage(string sender, string message)
        {
            Console.WriteLine($"  → [Admin: {Name}] Received from {sender}: {message}");
        }

        public override void ReceivePrivateMessage(string sender, string message)
        {
            Console.WriteLine($"  → [Admin: {Name}] 🔒 Private message from {sender}: {message}");
        }

        public override void ReceiveNotification(string notification)
        {
            Console.WriteLine($"  → [Admin: {Name}] ℹ️ {notification}");
        }

        public void MuteUser(string targetName)
        {
            Console.WriteLine($"[Admin: {Name}] Requested muting of {targetName}");
            _mediator.MuteUser(Name, targetName);
        }
    }
}
