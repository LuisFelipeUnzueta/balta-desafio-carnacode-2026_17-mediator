using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Models
{
    /// <summary>
    /// The Base Component provides the basic functionality of storing a
    /// mediator's instance inside component objects.
    /// </summary>
    public abstract class User : IUser
    {
        protected IMediator _mediator;

        public string Name { get; }
        public bool IsMuted { get; set; }

        protected User(IMediator mediator, string name)
        {
            _mediator = mediator;
            Name = name;
            IsMuted = false;
        }

        public abstract void ReceiveMessage(string sender, string message);
        public abstract void ReceivePrivateMessage(string sender, string message);
        public abstract void ReceiveNotification(string notification);

        public void SendMessage(string message)
        {
            _mediator.SendMessage(Name, message);
        }

        public void SendPrivateMessage(string receiver, string message)
        {
            _mediator.SendPrivateMessage(Name, receiver, message);
        }
    }
}
