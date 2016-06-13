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
        public Dictionary<string, HashSet<ProductieRegel<T>>> _sortedRules = new Dictionary<string, HashSet<ProductieRegel<T>>>();
        public HashSet<T> _alfabet = new HashSet<T>();
        private string _startSymbool;

        public Grammatica(string startSymbool, HashSet<ProductieRegel<T>> productieRegels)
        {
            this._startSymbool = startSymbool;
            foreach(ProductieRegel<T> t in productieRegels){
                if(!_sortedRules.ContainsKey(t.linkerkant))
                {
                    var a = new HashSet<ProductieRegel<T>>();
                    a.Add(t);
                    _sortedRules.Add(t.linkerkant, a);
                }
                else
                    _sortedRules[t.linkerkant].Add(t);
                _alfabet.Add(t.x);
            }
        }
        

        public bool Equals(Grammatica<T> other)
        {
            if(other == null)
            {
                return false;
            }
            else if(this.ToString() == other.ToString() && this._startSymbool == other._startSymbool && this._sortedRules == other._sortedRules && this._alfabet == other._alfabet)
            {
                return true;
            }
            else
                return false;
        }

        public override string ToString()
        {
            String beschrijving = "";
            foreach (KeyValuePair<string, HashSet<ProductieRegel<T>>> pair in _sortedRules)
            {
                beschrijving += pair.Key + " --> ";
                foreach (ProductieRegel<T> t in pair.Value)
                    beschrijving += t.x + t.rechterkant + "|";
                beschrijving = beschrijving.Substring(0,beschrijving.Length-1) + "\n";
            }
            return beschrijving;      
        }

        public NDFA<T> TransformToNDFA()
        {
            NDFA<T> ndfa = new NDFA<T>();
            ndfa._invoerSymbolen = _alfabet;
            foreach (KeyValuePair<string, HashSet<ProductieRegel<T>>> toestandEnOvergangen in _sortedRules)
            {
                foreach (ProductieRegel<T> t in toestandEnOvergangen.Value)
                {                    
                    Toestand<T> toestand = new Toestand<T>(toestandEnOvergangen.Key,new Tuple<string,T>(t.rechterkant,t.x));
                    ndfa._toestanden.Add(toestand);
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