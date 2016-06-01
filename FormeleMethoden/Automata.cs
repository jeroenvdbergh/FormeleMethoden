using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeleMethoden
{
    class Automata
    {
        private List<string> symbols = new List<string>();
        private List<string> startStates = new List<string>();
        private List<string> finalStates = new List<string>();
        private List<Transition> transitions = new List<Transition>();

        public Automata()
        {
            Console.WriteLine("Initialize your Automata, if you need help type help");

            Main();
        }

        public Automata(List<string> alphabet)
        {
            this.symbols = alphabet;
        }

        public void Main()
        {
            switch (Console.ReadLine())
            {
                case "print":
                    PrintCollection();
                    break;
                case "help":
                    Help();
                    break;
                case "init":
                    Init();
                    break;

                default:
                    Console.WriteLine("Command not recognized");
                    break;
            }
            Console.ReadLine();
            Main();
        }

        public void Init()
        {
            Console.WriteLine("Initializing collection");
            Console.WriteLine("Fill in the alpabetic letters one by one followed by an enter, if you're done type 'end'");
            SetAlphabet();
            Console.WriteLine("Alphabet is now set");
            Main();


        }

        public void SetAlphabet()
        {            
            //Check if string is null or empty
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {                   
                    break;
                }

                symbols.Add(input);
            }
        }

        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }

        public void PrintCollection()
        {
            foreach (string x in symbols)
            {
                Console.WriteLine(x);
            }
        }

        public void Help()
        {

        }

        public void DefineAsStartState(string t)
        {
            startStates.Add(t);
        }

        public void DefineAsFinalState(string t)
        {
            finalStates.Add(t);
        }
    }
}
