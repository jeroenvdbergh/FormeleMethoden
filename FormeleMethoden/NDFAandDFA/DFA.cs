using Eindopdracht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFAAndDFA
{
    public class DFA<T> : NDFA<T>
    {
        //Lege constructor
        public DFA()
        {

        }

        public DFA<T> Ontkenning()
        {
            DFA<T> dfa = new DFA<T>();
            dfa.invoerSymbolen = invoerSymbolen;
            HashSet<string> eind = new HashSet<string>();
            foreach(Toestand<T> t in toestanden){
                if(!eindToestanden.Contains(t.naam)){
                    eind.Add(t.naam);
                }
            }
            dfa.eindToestanden = eind;
            dfa.toestanden = toestanden;
            dfa.startSymbolen = startSymbolen;
            return dfa;
        }

        public NDFA<T> Reverse()
        {
            NDFA<T> reversed = new NDFA<T>();
            reversed.invoerSymbolen = invoerSymbolen;//hetzelfde
            reversed.startSymbolen = eindToestanden;
            reversed.eindToestanden = startSymbolen;
            reversed.toestanden = toestanden;
            foreach(Toestand<T> t in reversed.toestanden)
                t.Reverse();
            return reversed ;
        }

        public bool Equals(DFA<T> other)
        {
            if (other == null)
            {
                return false;
            }
            else if (this.eindToestanden == other.eindToestanden && this.invoerSymbolen == other.invoerSymbolen && this.startSymbolen == other.startSymbolen && this.toestanden == other.toestanden)
            {
                return true;
            }
            else
                return false;
        }

        /*public bool equals(Object other)
        {
            if (other == null)
            {
                return false;
            }
            else if (other.GetType() == typeof(Transition<T>))
            {
                return this.fromState.Equals(((Transition<T>)other).fromState) && this.toState.Equals(((Transition<T>)other).toState) && this.symbol == (((Transition<T>)other).symbol);
            }
            else return false;
        }*/

        //Minimalize
        public DFA<T> Minimalize()
        {
            //toDFA (reverse (toDFA (reverse (dfa)))
            //Console.WriteLine("normaal");
            //Console.WriteLine(ToString() + "\n");
            var a = Reverse();
            //Console.WriteLine("reverse1");
            //Console.WriteLine(a.ToString() + "\n" );
            var b = a.ToDFA();
            //Console.WriteLine("dfa1");
            //Console.WriteLine(b.ToString() + "\n");
            var c = b.Reverse();
            //Console.WriteLine("reverse2");
            //Console.WriteLine(c.ToString() + "\n");
            //Console.WriteLine("dfa2");
            var d = c.ToDFA();
            return d;
        }
        //ToReguliereGrammatica
        //Equals
        //And
        //Or
        //Not        
    }

}
