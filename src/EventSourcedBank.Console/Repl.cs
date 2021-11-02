using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Richiban.EventSourcedBank.Console
{
    internal class Repl
    {
        private readonly Dictionary<char, (string helpText, Action action)> _commands =
            new();

        private readonly string _promptText;

        public Repl(string promptText)
        {
            _promptText = promptText;
        }

        public (string helpText, Action action) this[char key]
        {
            init => _commands[key] = value;
        }

        public void EnterLoop()
        {
            while (true)
            {
                WriteLine("-------------------");

                if (_promptText != null)
                {
                    WriteLine(_promptText);
                }

                foreach (var (triggerKey, (helpText, action)) in _commands)
                {
                    WriteLine($"[{triggerKey}] {helpText}");
                }

                WriteLine();

                Write("[ ]");
                SetCursorPosition(CursorLeft - 2, CursorTop);

                char input;

                do
                {
                    input = ReadKey(intercept: true).KeyChar;
                } while (!_commands.ContainsKey(input));

                Write(input);
                WriteLine();

                _commands[input].action();
            }
        }
    }
}