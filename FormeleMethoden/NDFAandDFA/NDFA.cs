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
        public HashSet<T> _invoerSymbolen = new HashSet<T>();
        public HashSet<string> _startSymbolen = new HashSet<string>();
        public HashSet<Toestand<T>> _toestanden = new HashSet<Toestand<T>>();
        public HashSet<string> _eindToestanden = new HashSet<string>();
        
        public bool Equals(NDFA<T> other)
        {
            if(other == null)
            {
                return false;
            }
            else if(this._invoerSymbolen == other._invoerSymbolen && this._toestanden == other._toestanden && this._startSymbolen == other._startSymbolen && this._eindToestanden == other._eindToestanden)
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
            foreach (string s1 in _startSymbolen)
                result += s1 + "\t";
            result += "\nEinde: ";
            foreach (string s2 in _eindToestanden)
                result += s2 + "\t";
            result += "\n";
            foreach (Toestand<T> t in _toestanden)
            {
                result += t.ToString() + "\n";
            }
            return result;
        }

        public HashSet<string> GetToestanden()
        {
            HashSet<string> toestanden = new HashSet<string>();
            foreach (Toestand<T> t in _toestanden)
                toestanden.Add(t._name);
            return toestanden;
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
                    SortedSet<char> d = new SortedSet<char>((newt._volgendeToestand.Item1 + p).ToCharArray());
                    foreach (char y in d)
                        naam += y;
                    newt._volgendeToestand = new Tuple<string, T>(naam, newt._volgendeToestand.Item2);
                }
                newDFA._toestanden.Add(newt);
            }
            //overbodige toestanden weghalen
            for(int v = newDFA._toestanden.Count-1; v >= 0; v--)
            {
                var x = _startSymbolen.FirstOrDefault(p => p == newDFA._toestanden.ElementAt(v)._name);
                if (x == null)
                {
                    var t = newDFA._toestanden.FirstOrDefault(f => f._volgendeToestand.Item1 == newDFA._toestanden.ElementAt(v)._name && f._name != newDFA._toestanden.ElementAt(v)._name);
                    if (t == default(Toestand<T>))
                        newDFA._toestanden.Remove(newDFA._toestanden.ElementAt(v));
                }
            }
            //eindtoestanden bepalen
            foreach (var g in newDFA._toestanden)
            {
                foreach (char c in g._name.ToCharArray())
                {
                    if (_eindToestanden.Contains(new string(c,1)))
                        newDFA._eindToestanden.Add(g._name);
                }
            }
            //begintoestanden bepalen
            newDFA._startSymbolen = _startSymbolen;
            newDFA._invoerSymbolen = _invoerSymbolen;
            return newDFA;
        }

        /*
         * returns: per naam van de toestand met actie een set met namen van toestanden waar je heen kan
         */
        public Dictionary<Tuple<string, T>, SortedSet<string>> CreateTable()
        {
            Dictionary<Tuple<string, T>, SortedSet<string>> toestandenEnWaarJeHeenKan = new Dictionary<Tuple<string, T>, SortedSet<string>>();
            //maak een lege tabel met toestanden in de rijen in acties in de rijen
            foreach (var s in _toestanden.Where(r => _startSymbolen.Contains(r._name)))
            {
                foreach (T t in _invoerSymbolen)
                    if (!toestandenEnWaarJeHeenKan.ContainsKey(new Tuple<string,T>(s._name, t)))
                        toestandenEnWaarJeHeenKan.Add(new Tuple<string, T>(s._name, t), new SortedSet<string>());
            }
            //vul de tabel EN START VANUIT DE BEGINTOESTANDEN
            foreach (Toestand<T> t in _toestanden.Where(r=> _startSymbolen.Contains(r._name)))
            {
                var a = new Tuple<string, T>(t._name, t._volgendeToestand.Item2);
                toestandenEnWaarJeHeenKan[a].UnionWith(t._volgendeToestand.Item1.ToCharArray().Select(c => c.ToString()).ToList());
            }
            //vul de tabel aan met nieuwe waardes!
            for (int i = 0; i < toestandenEnWaarJeHeenKan.Count; i++)
            {
                Tuple<string, T> input = toestandenEnWaarJeHeenKan.Keys.ElementAt(i);
                foreach (char state in input.Item1.ToCharArray())
                {
                    var v = new HashSet<Toestand<T>>();
                    v.UnionWith(_toestanden.Where(v1 => v1._name == state.ToString() && v1._volgendeToestand.Item2.Equals(input.Item2)));
                    var v3 = v.Where(t1 => t1._volgendeToestand.Item2.Equals(input.Item2));
                    foreach (Toestand<T> t2 in v3)
                        toestandenEnWaarJeHeenKan[input].Add(t2._volgendeToestand.Item1);
                }
                //zonodig nieuwe toestandtoevoegen
                string newstate = "";
                foreach (var c in toestandenEnWaarJeHeenKan[input])
                    newstate += c;
                if (!toestandenEnWaarJeHeenKan.ContainsKey(new Tuple<string, T>(newstate, input.Item2)))
                    foreach(T t in _invoerSymbolen)
                        toestandenEnWaarJeHeenKan.Add(new Tuple<string, T>(newstate, t), new SortedSet<string>());
            }
            return toestandenEnWaarJeHeenKan;
        }

        public Grammatica<T> ToReguliereGrammatica()
        {
            try
            {
                Grammatica<T> gr = new Grammatica<T>(_startSymbolen.ElementAt(0), new HashSet<ProductieRegel<T>>());
                foreach (Toestand<T> t in _toestanden)
                {
                    if (!gr._sortedRules.ContainsKey(t._name))
                        gr._sortedRules.Add(t._name, new HashSet<ProductieRegel<T>>());
                    gr._sortedRules[t._name].Add(new ProductieRegel<T>(t._name, t._volgendeToestand.Item2, t._volgendeToestand.Item1));
                }
                return gr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }   
}
