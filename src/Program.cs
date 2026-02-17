using System;
using DesignPatternChallenge.Mediators;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Mediator Pattern Chat System ===\n");

            // The Mediator
            var mediator = new ChatMediator();

            // The Users (Components)
            var alice = new AdminUser(mediator, "Alice");
            var bob = new BasicUser(mediator, "Bob");
            var carlos = new BasicUser(mediator, "Carlos");
            var diana = new BasicUser(mediator, "Diana");

            // Registration through the mediator
            Console.WriteLine("=== Users Joining the Group ===");
            mediator.RegisterUser(alice);
            mediator.RegisterUser(bob);
            mediator.RegisterUser(carlos);
            mediator.RegisterUser(diana);

            Console.WriteLine("\n=== Conversation ===");
            alice.SendMessage("Hello everyone! I'm the admin.");
            bob.SendMessage("Hi Alice! Good to have you here.");
            carlos.SendMessage("Hey there!");

            Console.WriteLine("\n=== Private Messaging ===");
            alice.SendPrivateMessage("Bob", "Bob, can you check the server logs?");
            bob.SendMessage("Sure thing, Alice.");

            Console.WriteLine("\n=== Moderation (Muting) ===");
            // Admin Alice mutes Carlos through the mediator
            alice.MuteUser("Carlos");

            Console.WriteLine("\n=== Attempting to speak while muted ===");
            carlos.SendMessage("Can I still talk?"); // Should be blocked by mediator

            Console.WriteLine("\n=== Leaving the Group ===");
            mediator.UnregisterUser(diana);
            alice.SendMessage("Diana has left the conversation.");

            //"\n=== Solving the Reflection Questions ==="
            //"1. How to decouple objects that need to communicate?"
            //"   → By introducing a Mediator that handles all communication, so components don't know about each other."

            //"2. How to centralize complex communication logic?"
            //"   → Move the logic (filters, moderation, logging) into the Mediator class."

            //"3. How to avoid direct communication between many objects?"
            //"   → Each object only communicates with the Mediator (1-to-1) instead of all other objects (M-to-N).

            //"4. How to facilitate maintenance of interactions between components?"
            //"   → Changes in interaction rules only require modifying the Mediator, without touching component classes."
        }
    }
}
