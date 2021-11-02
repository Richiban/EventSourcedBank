using System;
using System.Linq;
using Richiban.EventSourcedBank.Console;
using static System.Console;

new BankTitleScreen
{
    Heading = "Welcome to the EventSourcedBank console app!" 
}.Display();

var repl = new Repl("What would you like to do?")
{
    ['r'] = ("Receive", () => WriteLine("You pressed receive")),
    ['s'] = ("Send", () => WriteLine("You pressed send")),
    ['q'] = ("Quit", () => Environment.Exit(0))
};

repl.EnterLoop();