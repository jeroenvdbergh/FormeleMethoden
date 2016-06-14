using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFAAndDFA
{
    public class Toestand<T>
    {
        public string naam;
        public string vorigeToestand;
        public Tuple<string, T> volgendeToestand; //naam volgende toestand met actie

        //constructor
        public Toestand(string naam, Tuple<string, T> volgendeToestand)
        {
            this.naam = naam;
            this.volgendeToestand = volgendeToestand;
            this.vorigeToestand = naam;
        }

        public void Reverse()
        {
            string tempVorigeToestand = vorigeToestand;
            vorigeToestand = volgendeToestand.Item1;
            volgendeToestand = new Tuple<string,T>(tempVorigeToestand, volgendeToestand.Item2);
            naam = vorigeToestand;
        }

        //Overschrijf de ToString methode om een leesbare output van de toestand weer te geven
        public override string ToString()
        {
            if (string.IsNullOrEmpty(volgendeToestand.Item2.ToString()))
                return "Van toestand '" + naam + "' naar toestand: '" + volgendeToestand.Item1 + "' met " + ReguliereExpressie.Expressie.EPSILON;
            return "Van toestand '" + naam + "' naar toestand: '" + volgendeToestand.Item1 + "' met " + volgendeToestand.Item2.ToString();
        }

        //Methode om te kijken de huidige toestand gelijk is aan een gegeven toestand
        public bool Equals(Toestand<T> other)
        {
            if(this.naam == other.naam && this.volgendeToestand == other.volgendeToestand)
            {
                return true;
            }
            else
                return false;
        }

        //Maak een nieuwe toestand aan
        public static Toestand<char> CreateToestand(string s)
        {
            var letters = s.ToCharArray();
            return new Toestand<char>(s[0].ToString(),new Tuple<string,char>(s[1].ToString(),s[2]));
        }
    }
}
