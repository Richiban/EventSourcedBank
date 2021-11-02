using System;
using static System.Console;

namespace Richiban.EventSourcedBank.Console
{
    class BankTitleScreen
    {
        private string _titleText = @"
__________                __    
\______   \_____    ____ |  | __
 |    |  _/\__  \  /    \|  |/ /
 |    |   \ / __ \|   |  \    < 
 |______  /(____  /___|  /__|_ \
        \/      \/     \/     \/
";

        public string Heading { get; init; }

        public void Display()
        {
            WriteLine("---------------");
            WriteLine(_titleText);
            if (Heading != null) WriteLine(Heading);
            WriteLine();
        }
    }
}