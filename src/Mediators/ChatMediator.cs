using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Mediators
{
    /// <summary>
    /// Concrete Mediators implement cooperative behavior by coordinating several
    /// components.
    /// </summary>
    public class ChatMediator : IMediator
    {
        private readonly List<IUser> _users = new();

        public void RegisterUser(IUser user)
        {
            if (!_users.Contains(user))
            {
                _users.Add(user);
                Notify($"{user.Name} joined the group");
            }
        }

        public void UnregisterUser(IUser user)
        {
            if (_users.Contains(user))
            {
                _users.Remove(user);
                Notify($"{user.Name} left the group");
            }
        }

        public void SendMessage(string senderName, string message)
        {
            var sender = _users.FirstOrDefault(u => u.Name == senderName);
            if (sender == null) return;

            if (sender.IsMuted)
            {
                Console.WriteLine($"[{senderName}] ❌ You are muted and cannot send messages.");
                return;
            }

            Console.WriteLine($"[{senderName}] Sent: {message}");

            // Centralized logic for message distribution
            foreach (var user in _users)
            {
                // Don't send the message to the sender
                if (user.Name != senderName && !user.IsMuted)
                {
                    user.ReceiveMessage(senderName, message);
                }
            }
        }

        public void SendPrivateMessage(string senderName, string receiverName, string message)
        {
            var sender = _users.FirstOrDefault(u => u.Name == senderName);
            if (sender == null) return;

            if (sender.IsMuted)
            {
                Console.WriteLine($"[{senderName}] ❌ You are muted and cannot send private messages.");
                return;
            }

            var receiver = _users.FirstOrDefault(u => u.Name == receiverName);
            if (receiver != null)
            {
                Console.WriteLine($"[{senderName}] Sent private message to {receiverName}");
                receiver.ReceivePrivateMessage(senderName, message);
            }
            else
            {
                Console.WriteLine($"[{senderName}] ❌ Receiver {receiverName} not found.");
            }
        }

        public void Notify(string message)
        {
            foreach (var user in _users)
            {
                user.ReceiveNotification(message);
            }
        }

        public void MuteUser(string adminName, string targetName)
        {
            // Here we could check if adminName actually has admin permissions
            // In this simple implementation, we assume the caller is an admin
            
            var target = _users.FirstOrDefault(u => u.Name == targetName);
            if (target != null)
            {
                target.IsMuted = true;
                Notify($"{targetName} was muted by {adminName}");
            }
        }
    }
}
