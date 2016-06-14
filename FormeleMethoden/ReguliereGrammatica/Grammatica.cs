using Eindopdracht;
using Eindopdracht.NDFAAndDFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eindopdracht
{
    public class Grammatica<T>
    {
        public Dictionary<string, HashSet<ProductieRegel<T>>> productieRegels = new Dictionary<string, HashSet<ProductieRegel<T>>>();
        public HashSet<T> alfabet = new HashSet<T>();
        private string startSymbool;

        public Grammatica(string startSymbool, HashSet<ProductieRegel<T>> regels)
        {
            this.startSymbool = startSymbool;
            foreach (ProductieRegel<T> t in regels)
            {
                if (!productieRegels.ContainsKey(t.linkerkant))
                {
                    var a = new HashSet<ProductieRegel<T>>();
                    a.Add(t);
                    productieRegels.Add(t.linkerkant, a);
                }
                else
                    productieRegels[t.linkerkant].Add(t);
                alfabet.Add(t.x);
            }
        }


        public bool Equals(Grammatica<T> other)
        {
            if (other == null)
            {
                return false;
            }
            else if (this.ToString() == other.ToString() && this.startSymbool == other.startSymbool && this.productieRegels == other.productieRegels && this.alfabet == other.alfabet)
            {
                return true;
            }
            else
                return false;
        }

        public override string ToString()
        {
            String beschrijving = "";
            foreach (KeyValuePair<string, HashSet<ProductieRegel<T>>> pair in productieRegels)
            {
                beschrijving += pair.Key + " --> ";
                foreach (ProductieRegel<T> t in pair.Value)
                    beschrijving += t.x + t.rechterkant + "|";
                beschrijving = beschrijving.Substring(0, beschrijving.Length - 1) + "\n";
            }
            return beschrijving;
        }

        public NDFA<T> TransformToNDFA()
        {
            NDFA<T> ndfa = new NDFA<T>();
            ndfa.invoerSymbolen = alfabet;
            foreach (KeyValuePair<string, HashSet<ProductieRegel<T>>> toestandEnOvergangen in productieRegels)
            {
                foreach (ProductieRegel<T> t in toestandEnOvergangen.Value)
                {
                    Toestand<T> toestand = new Toestand<T>(toestandEnOvergangen.Key, new Tuple<string, T>(t.rechterkant, t.x));
                    ndfa.toestanden.Add(toestand);
                }
            }
            return ndfa;
        }

        public bool equals(Grammatica<T> other)
        {
            return false;
        }
    }
}