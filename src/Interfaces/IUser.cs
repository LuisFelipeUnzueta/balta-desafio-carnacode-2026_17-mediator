namespace DesignPatternChallenge.Interfaces
{
    /// <summary>
    /// The Component interface declares a method for receiving notifications from
    /// the mediator.
    /// </summary>
    public interface IUser
    {
        string Name { get; }
        bool IsMuted { get; set; }
        void ReceiveMessage(string sender, string message);
        void ReceivePrivateMessage(string sender, string message);
        void ReceiveNotification(string notification);
        void SendMessage(string message);
        void SendPrivateMessage(string receiver, string message);
    }
}
