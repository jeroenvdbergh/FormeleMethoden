using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFAAndDFA
{
    public class Toestand<T>
    {
        public string _name;
        public string _vorigeToestand;
        public Tuple<string, T> _voglendeToestand; //naam volgende toestand met actie

        public Toestand(string name, Tuple<string, T> volgendeToestand)
        {
            _name = name;
            _voglendeToestand = volgendeToestand;
            _vorigeToestand = name;
        }

        public void Reverse()
        {
            string tempVorigeToestand = _vorigeToestand;
            _vorigeToestand = _voglendeToestand.Item1;
            _voglendeToestand = new Tuple<string,T>(tempVorigeToestand,_voglendeToestand.Item2);
            _name = _vorigeToestand;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_voglendeToestand.Item2.ToString()))
                return "Van toestand '" + _name + "' naar toestand: '" + _voglendeToestand.Item1 + "' met " + ReguliereExpressie.Expressie.EPSILON;
            return "Van toestand '" + _name + "' naar toestand: '" + _voglendeToestand.Item1 + "' met " + _voglendeToestand.Item2.ToString();
        }

        public bool Equals(Toestand<T> other)
        {
            if(this._name == other._name && this._voglendeToestand == other._voglendeToestand)
            {
                return true;
            }
            else
                return false;
        }

        public static Toestand<char> CreateToestand(string s)
        {
            var letters = s.ToCharArray();
            return new Toestand<char>(s[0].ToString(),new Tuple<string,char>(s[1].ToString(),s[2]));
        }
    }
}
