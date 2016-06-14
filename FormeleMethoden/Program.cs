using Eindopdracht.ReguliereExpressie;
using Eindopdracht.NDFAAndDFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eindopdracht
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI());

            Console.ReadLine();
        }

        static public NDFA<char> voorbeeldNDFA()
        {
            NDFA<char> ndfa = new NDFA<char>();
            ndfa.invoerSymbolen = new HashSet<char>("ab".ToCharArray());

            Toestand<char> t1 = new Toestand<char>("0", new Tuple<string, char>("1", 'a'));
            Toestand<char> t2 = new Toestand<char>("1", new Tuple<string, char>("0", 'b'));
            Toestand<char> t3 = new Toestand<char>("0", new Tuple<string, char>("0", 'b'));
            Toestand<char> t4 = new Toestand<char>("0", new Tuple<string, char>("2", 'a'));
            Toestand<char> t5 = new Toestand<char>("2", new Tuple<string, char>("1", 'b'));
            Toestand<char> t6 = new Toestand<char>("2", new Tuple<string, char>("0", 'b'));

            ndfa.toestanden.Add(t1);
            ndfa.toestanden.Add(t2);
            ndfa.toestanden.Add(t3);
            ndfa.toestanden.Add(t4);
            ndfa.toestanden.Add(t5);
            ndfa.toestanden.Add(t6);

            ndfa.startSymbolen.Add("0");
            ndfa.eindToestanden.Add("1");
            return ndfa;
        }

        static public DFA<char> minimaliserenDFA()
        {
            DFA<char> dfa = new DFA<char>();

            dfa.invoerSymbolen = new HashSet<char>("ab".ToCharArray());

            Toestand<char> t1 = new Toestand<char>("0", new Tuple<string, char>("0", 'a'));
            Toestand<char> t2 = new Toestand<char>("0", new Tuple<string, char>("1", 'b'));
            Toestand<char> t3 = new Toestand<char>("1", new Tuple<string, char>("2", 'a'));
            Toestand<char> t4 = new Toestand<char>("1", new Tuple<string, char>("1", 'b'));
            Toestand<char> t5 = new Toestand<char>("2", new Tuple<string, char>("0", 'a'));
            Toestand<char> t6 = new Toestand<char>("2", new Tuple<string, char>("3", 'b'));
            Toestand<char> t7 = new Toestand<char>("3", new Tuple<string, char>("4", 'a'));
            Toestand<char> t8 = new Toestand<char>("3", new Tuple<string, char>("2", 'b'));
            Toestand<char> t9 = new Toestand<char>("4", new Tuple<string, char>("5", 'a'));
            Toestand<char> t10 = new Toestand<char>("4", new Tuple<string, char>("3", 'b'));
            Toestand<char> t11 = new Toestand<char>("5", new Tuple<string, char>("0", 'a'));
            Toestand<char> t12 = new Toestand<char>("5", new Tuple<string, char>("3", 'b'));

            dfa.toestanden.Add(t1);
            dfa.toestanden.Add(t2);
            dfa.toestanden.Add(t3);
            dfa.toestanden.Add(t4);
            dfa.toestanden.Add(t5);
            dfa.toestanden.Add(t6);
            dfa.toestanden.Add(t7);
            dfa.toestanden.Add(t8);
            dfa.toestanden.Add(t9);
            dfa.toestanden.Add(t10);
            dfa.toestanden.Add(t11);
            dfa.toestanden.Add(t12);
            dfa.startSymbolen.Add("0");
            dfa.eindToestanden.Add("4");

            return dfa.Minimalize();
        }

        static public DFA<char> voorbeelDFA()
        {
            DFA<char> dfa = new DFA<char>();
            dfa.invoerSymbolen = new HashSet<char>("ab".ToCharArray());
            Toestand<char> t1 = new Toestand<char>("0", new Tuple<string, char>("0", 'a'));
            Toestand<char> t2 = new Toestand<char>("0", new Tuple<string, char>("1", 'b'));
            Toestand<char> t3 = new Toestand<char>("1", new Tuple<string, char>("2", 'a'));
            Toestand<char> t4 = new Toestand<char>("1", new Tuple<string, char>("1", 'b'));
            Toestand<char> t5 = new Toestand<char>("2", new Tuple<string, char>("0", 'a'));
            Toestand<char> t6 = new Toestand<char>("2", new Tuple<string, char>("3", 'b'));
            Toestand<char> t7 = new Toestand<char>("3", new Tuple<string, char>("4", 'a'));
            Toestand<char> t8 = new Toestand<char>("3", new Tuple<string, char>("2", 'b'));
            Toestand<char> t9 = new Toestand<char>("4", new Tuple<string, char>("5", 'a'));
            Toestand<char> t10 = new Toestand<char>("4", new Tuple<string, char>("3", 'b'));
            Toestand<char> t11 = new Toestand<char>("5", new Tuple<string, char>("0", 'a'));
            Toestand<char> t12 = new Toestand<char>("5", new Tuple<string, char>("3", 'b'));
            dfa.toestanden.Add(t1);
            dfa.toestanden.Add(t2);
            dfa.toestanden.Add(t3);
            dfa.toestanden.Add(t4);
            dfa.toestanden.Add(t5);
            dfa.toestanden.Add(t6);
            dfa.toestanden.Add(t7);
            dfa.toestanden.Add(t8);
            dfa.toestanden.Add(t9);
            dfa.toestanden.Add(t10);
            dfa.toestanden.Add(t11);
            dfa.toestanden.Add(t12);
            dfa.startSymbolen.Add("0");
            dfa.eindToestanden.Add("1");
            return dfa;
        }

        static public Expressie voorbeeldExpressie()
        {
            return new Expressie("(ab(ab)*)*");
        }

        static public Grammatica<char> voorbeeldGrammatica()
        {
            Grammatica<char> gr = null;
            ProductieRegel<char> p1 = new ProductieRegel<char>("A", 'a', "B");
            ProductieRegel<char> p2 = new ProductieRegel<char>("A", 'b', "A");
            ProductieRegel<char> p3 = new ProductieRegel<char>("B", 'a', "B");
            ProductieRegel<char> p4 = new ProductieRegel<char>("B", 'b', "A");
            ProductieRegel<char> p5 = new ProductieRegel<char>("A", '$', "C");
            ProductieRegel<char> p6 = new ProductieRegel<char>("C", 'a', "B");
            ProductieRegel<char> p7 = new ProductieRegel<char>("C", 'b', "A");
            HashSet<ProductieRegel<char>> productieregels = new HashSet<ProductieRegel<char>>();
            productieregels.Add(p2);
            productieregels.Add(p1);
            productieregels.Add(p5);
            productieregels.Add(p3);
            productieregels.Add(p4);
            productieregels.Add(p6);
            productieregels.Add(p7);
            gr = new Grammatica<char>("A", productieregels);
            return gr;
        }

        static public Automata<String> getExampleSlide8Lesson2()
        {
            char[] alphabet = { 'a', 'b' };
            Automata<String> m = new Automata<String>(alphabet);

            m.addTransition(new Transition<String>("0", 'a', "1"));
            m.addTransition(new Transition<String>("0", 'b', "4"));

            m.addTransition(new Transition<String>("1", 'a', "4"));
            m.addTransition(new Transition<String>("1", 'b', "2"));

            m.addTransition(new Transition<String>("2", 'a', "3"));
            m.addTransition(new Transition<String>("2", 'b', "4"));

            m.addTransition(new Transition<String>("3", 'a', "1"));
            m.addTransition(new Transition<String>("3", 'b', "2"));

            // the error state, loops for a and b:
            m.addTransition(new Transition<String>("4", 'a'));
            m.addTransition(new Transition<String>("4", 'b'));

            // only on start state in a dfa:
            m.defineAsStartState("0");

            // two final states:
            m.defineAsFinalState("2");
            m.defineAsFinalState("3");

            return m;
        }
    }
}
