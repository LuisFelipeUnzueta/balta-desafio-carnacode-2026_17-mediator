namespace DesignPatternChallenge.Interfaces
{
    /// <summary>
    /// The Mediator interface declares a method used by components to notify the
    /// mediator about various events. The Mediator may react to these events and
    /// pass the execution to other components.
    /// </summary>
    public interface IMediator
    {
        void SendMessage(string sender, string message);
        void SendPrivateMessage(string sender, string receiver, string message);
        void Notify(string message);
        void MuteUser(string admin, string target);
        void RegisterUser(IUser user);
        void UnregisterUser(IUser user);
    }
}
