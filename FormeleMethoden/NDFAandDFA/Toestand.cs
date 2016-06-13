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
        public Tuple<string, T> _volgendeToestand; //naam volgende toestand met actie

        public Toestand(string name, Tuple<string, T> volgendeToestand)
        {
            _name = name;
            _volgendeToestand = volgendeToestand;
            _vorigeToestand = name;
        }

        public void Reverse()
        {
            string tempVorigeToestand = _vorigeToestand;
            _vorigeToestand = _volgendeToestand.Item1;
            _volgendeToestand = new Tuple<string,T>(tempVorigeToestand, _volgendeToestand.Item2);
            _name = _vorigeToestand;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_volgendeToestand.Item2.ToString()))
                return "Van toestand '" + _name + "' naar toestand: '" + _volgendeToestand.Item1 + "' met " + ReguliereExpressie.Expressie.EPSILON;
            return "Van toestand '" + _name + "' naar toestand: '" + _volgendeToestand.Item1 + "' met " + _volgendeToestand.Item2.ToString();
        }

        public bool Equals(Toestand<T> other)
        {
            if(this._name == other._name && this._volgendeToestand == other._volgendeToestand)
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
