using Eindopdracht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Eindopdracht.NDFAAndDFA
{
    public class NDFA<T>
    {
        public HashSet<T> invoerSymbolen = new HashSet<T>();
        public HashSet<string> startSymbolen = new HashSet<string>();
        public HashSet<Toestand<T>> toestanden = new HashSet<Toestand<T>>();
        public HashSet<string> eindToestanden = new HashSet<string>();
        
        public bool Equals(NDFA<T> other)
        {
            if(other == null)
            {
                return false;
            }
            else if(this.invoerSymbolen == other.invoerSymbolen && this.toestanden == other.toestanden && this.startSymbolen == other.startSymbolen && this.eindToestanden == other.eindToestanden)
            {
                return true;
            }
            else
                return false;
        }

        public NDFA()
        {

        }

        public override string ToString()
        {
            string result = "Start: ";
            foreach (string s1 in startSymbolen)
                result += s1 + "\t";
            result += "\nEinde: ";
            foreach (string s2 in eindToestanden)
                result += s2 + "\t";
            result += "\n";
            foreach (Toestand<T> t in toestanden)
            {
                result += t.ToString() + "\n";
            }
            return result;
        }

        public DFA<T> ToDFA()
        {
            DFA<T> newDFA = new DFA<T>();
            Dictionary<Tuple<string, T>, SortedSet<string>> table = CreateTable();
            foreach (KeyValuePair<Tuple<string, T>, SortedSet<string>> k in table)
            {
                Toestand<T> newt = new Toestand<T>(k.Key.Item1, new Tuple<string, T>("", k.Key.Item2));
                foreach (string p in k.Value)
                {
                    string naam = "";
                    SortedSet<char> d = new SortedSet<char>((newt.volgendeToestand.Item1 + p).ToCharArray());
                    foreach (char y in d)
                        naam += y;
                    newt.volgendeToestand = new Tuple<string, T>(naam, newt.volgendeToestand.Item2);
                }
                newDFA.toestanden.Add(newt);
            }
            //overbodige toestanden weghalen
            for(int v = newDFA.toestanden.Count-1; v >= 0; v--)
            {
                var x = startSymbolen.FirstOrDefault(p => p == newDFA.toestanden.ElementAt(v).naam);
                if (x == null)
                {
                    var t = newDFA.toestanden.FirstOrDefault(f => f.volgendeToestand.Item1 == newDFA.toestanden.ElementAt(v).naam && f.naam != newDFA.toestanden.ElementAt(v).naam);
                    if (t == default(Toestand<T>))
                        newDFA.toestanden.Remove(newDFA.toestanden.ElementAt(v));
                }
            }
            //eindtoestanden bepalen
            foreach (var g in newDFA.toestanden)
            {
                foreach (char c in g.naam.ToCharArray())
                {
                    if (eindToestanden.Contains(new string(c,1)))
                        newDFA.eindToestanden.Add(g.naam);
                }
            }
            //begintoestanden bepalen
            newDFA.startSymbolen = startSymbolen;
            newDFA.invoerSymbolen = invoerSymbolen;
            return newDFA;
        }

        /*
         * returns: per naam van de toestand met actie een set met namen van toestanden waar je heen kan
         */
        public Dictionary<Tuple<string, T>, SortedSet<string>> CreateTable()
        {
            Dictionary<Tuple<string, T>, SortedSet<string>> toestandenEnWaarJeHeenKan = new Dictionary<Tuple<string, T>, SortedSet<string>>();
            //maak een lege tabel met toestanden in de rijen in acties in de rijen
            foreach (var s in toestanden.Where(r => startSymbolen.Contains(r.naam)))
            {
                foreach (T t in invoerSymbolen)
                    if (!toestandenEnWaarJeHeenKan.ContainsKey(new Tuple<string,T>(s.naam, t)))
                        toestandenEnWaarJeHeenKan.Add(new Tuple<string, T>(s.naam, t), new SortedSet<string>());
            }
            //vul de tabel EN START VANUIT DE BEGINTOESTANDEN
            foreach (Toestand<T> t in toestanden.Where(r=> startSymbolen.Contains(r.naam)))
            {
                var a = new Tuple<string, T>(t.naam, t.volgendeToestand.Item2);
                toestandenEnWaarJeHeenKan[a].UnionWith(t.volgendeToestand.Item1.ToCharArray().Select(c => c.ToString()).ToList());
            }
            //vul de tabel aan met nieuwe waardes!
            for (int i = 0; i < toestandenEnWaarJeHeenKan.Count; i++)
            {
                Tuple<string, T> input = toestandenEnWaarJeHeenKan.Keys.ElementAt(i);
                foreach (char state in input.Item1.ToCharArray())
                {
                    var v = new HashSet<Toestand<T>>();
                    v.UnionWith(toestanden.Where(v1 => v1.naam == state.ToString() && v1.volgendeToestand.Item2.Equals(input.Item2)));
                    var v3 = v.Where(t1 => t1.volgendeToestand.Item2.Equals(input.Item2));
                    foreach (Toestand<T> t2 in v3)
                        toestandenEnWaarJeHeenKan[input].Add(t2.volgendeToestand.Item1);
                }
                //zonodig nieuwe toestandtoevoegen
                string newstate = "";
                foreach (var c in toestandenEnWaarJeHeenKan[input])
                    newstate += c;
                if (!toestandenEnWaarJeHeenKan.ContainsKey(new Tuple<string, T>(newstate, input.Item2)))
                    foreach(T t in invoerSymbolen)
                        toestandenEnWaarJeHeenKan.Add(new Tuple<string, T>(newstate, t), new SortedSet<string>());
            }
            return toestandenEnWaarJeHeenKan;
        }

        public Grammatica<T> ToReguliereGrammatica()
        {
            try
            {

                Grammatica<T> gr = new Grammatica<T>(startSymbolen.ElementAt(0), new HashSet<ProductieRegel<T>>());
                foreach (Toestand<T> t in toestanden)
                {
                    if (!gr.productieRegels.ContainsKey(t.naam))
                        gr.productieRegels.Add(t.naam, new HashSet<ProductieRegel<T>>());
                    gr.productieRegels[t.naam].Add(new ProductieRegel<T>(t.naam, t.volgendeToestand.Item2, t.volgendeToestand.Item1));
                }
                return gr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }   
}
