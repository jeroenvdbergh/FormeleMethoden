using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeleMethoden
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("type 'example' to run the test program or type 'manual' to start the manual configuration");

            string input = Console.ReadLine();

            switch (input)
            {
                case "example":
                    Example();
                    break;

                case "manual":
                    new Automata();
                    break;
            }        
        }

        public static void Example()
        {
            List<string> alphabet = new List<string> { "a", "b" };
            Automata m = new Automata(alphabet);

            m.AddTransition(new Transition("q0", 'a', "q1"));
            m.AddTransition(new Transition("q0", 'b', "q4"));

            m.AddTransition(new Transition("q1", 'a', "q4"));
            m.AddTransition(new Transition("q1", 'b', "q2"));

            m.AddTransition(new Transition("q2", 'a', "q3"));
            m.AddTransition(new Transition("q2", 'b', "q4"));

            m.AddTransition(new Transition("q3", 'a', "q1"));
            m.AddTransition(new Transition("q3", 'b', "q2"));

            // the error state, loops for a and b:
            //m.addTransition(new Transition<String>("q4", 'a'));
            //m.addTransition(new Transition<String>("q4", 'b'));

            // only on start state in a dfa:
            m.DefineAsStartState("q0");

            // two final states:
            m.DefineAsFinalState("q2");
            m.DefineAsFinalState("q3");
        }
            
    }
}
