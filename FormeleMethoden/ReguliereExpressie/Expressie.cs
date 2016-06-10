using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eindopdracht;
using Eindopdracht.NDFAAndDFA;

namespace Eindopdracht.ReguliereExpressie
{
    public class Expressie
    {
        public Operator op;
        public string terminals;
        public const char EPSILON = 'ԑ';
        public enum Operator { PLUS, STAR, OR, DOT, ONE}    
        public Expressie left;
        public Expressie right;

        public Expressie()
        {
            op = Operator.ONE;
            terminals = "";
            left = null;
            right = null;
        }
    
        public Expressie(String p)
        {
            op = Operator.ONE;
            terminals = p;
            left = null;
            right = null;
        }
    
        public Expressie plus()
        {
            Expressie result = new Expressie();
            result.op = Operator.PLUS;
            result.left = this;
            return result;
        }

        public Expressie star()
        {
            Expressie result = new Expressie();
            result.op = Operator.STAR;
            result.left = this;
            return result;
        }

        public Expressie or(Expressie e2)
        {
            Expressie result = new Expressie();
            result.op = Operator.OR;
            result.left = this;
            result.right = e2;
            return result;
        }

        public Expressie dot(Expressie e2)
        {
            Expressie result = new Expressie();
            result.op = Operator.DOT;
            result.left = this;
            result.right = e2;
            return result;
        }

        public HashSet<String> GetLanguage(int maxSteps)
        {
            HashSet<String> emptyLanguage = new HashSet<String>();
            HashSet<String> languageResult = new HashSet<String>();        
            HashSet<String> languageLeft, languageRight;        
            if (maxSteps < 1) return emptyLanguage;        
            switch (this.op) {
                case Operator.ONE:
                     languageResult.Add(terminals);
                     break;
                case Operator.OR:
                    languageLeft = left == null ? emptyLanguage : left.GetLanguage(maxSteps - 1);
                    languageRight = right == null ? emptyLanguage : right.GetLanguage(maxSteps - 1);
                    languageResult.UnionWith(languageLeft);
                    languageResult.UnionWith(languageRight);
                    break;
                case Operator.DOT:
                    languageLeft = left == null ? emptyLanguage : left.GetLanguage(maxSteps - 1);
                    languageRight = right == null ? emptyLanguage : right.GetLanguage(maxSteps - 1);
                    foreach (String s1 in languageLeft){
                        foreach(String s2 in languageRight){
                            languageResult.Add(s1 + s2);
                        }
                    }
                    break;
                // STAR(*) en PLUS(+) kunnen we bijna op dezelfde manier uitwerken:
                case Operator.STAR:
                case Operator.PLUS:
                    languageLeft = left == null ? emptyLanguage : left.GetLanguage(maxSteps - 1);
                    languageResult.UnionWith(languageLeft);
                    for (int i = 1; i < maxSteps; i++){  
                        HashSet<String> languageTemp = new HashSet<String>(languageResult);
                        foreach (String s1 in languageLeft){   
                            foreach (String s2 in languageTemp){  
                                languageResult.Add (s1+s2);
                            }
                        }
                    }
                    if (this.op  == Operator.STAR)
                        {languageResult.Add("");}
                    break;                
                default:
                    Console.WriteLine("getLanguage is nog niet gedefinieerd voor de operator: " + this.op);
                    break;
            }
            return languageResult;
        }
        
        public NDFA<char> ToNDFA()
        {
            NDFA<char> ndfa = new NDFA<char>();
            bool orOperation = false;
            Stack<Tuple<int, Toestand<char>>> bracketLocations = new Stack<Tuple<int, Toestand<char>>>();
            Stack<Toestand<char>> stuffInBrackets = new Stack<Toestand<char>>();
            int index = 0;
            foreach(char c in terminals){
                Toestand<char> t = ndfa._toestanden.LastOrDefault(y => y._voglendeToestand.Item2 != EPSILON);
                if (t == null)
                    t = new Toestand<char>("0", new Tuple<string, char>("0", EPSILON));
                switch (c)
                {
                    case '(':
                        bracketLocations.Push(new Tuple<int, Toestand<char>>(index, t));
                        break;
                    case ')':
                        var indexLastBracket = bracketLocations.Pop();
                        Toestand<char> p = new Toestand<char>(t._voglendeToestand.Item1, new Tuple<string,char>(indexLastBracket.Item2._name,EPSILON));
                        stuffInBrackets.Push(p);
                        break;
                    case '*':
                        if (stuffInBrackets.Count == 0)
                        {
                            //epsilon van vorige naar nieuwste
                            Toestand<char> ts = new Toestand<char>(t._name, new Tuple<string, char>(t._voglendeToestand.Item1, EPSILON));
                            //epsilon van nieuwste naar vorige
                            Toestand<char> t3 = new Toestand<char>(t._voglendeToestand.Item1, new Tuple<string, char>(t._name, EPSILON));
                            ndfa._toestanden.Add(ts);
                            ndfa._toestanden.Add(t3);
                        }
                        else
                        {
                            var t5 = stuffInBrackets.Pop();
                            ndfa._toestanden.Add(t5);
                            ndfa._toestanden.Add(new Toestand<char>(t5._voglendeToestand.Item1, new Tuple<string, char>(t5._name, EPSILON)));
                        }
                        break;
                    case '+':
                        if (stuffInBrackets.Count == 0)
                        {
                            //epsilon van nieuwste naar vorige
                            Toestand<char> t4 = new Toestand<char>(t._voglendeToestand.Item1, new Tuple<string, char>(t._name, EPSILON));
                            ndfa._toestanden.Add(t4);
                        }
                        else
                        {
                            var t6 = stuffInBrackets.Pop();
                            ndfa._toestanden.Add(t6);
                        }
                        break;
                    case '|':
                        orOperation = true;
                        break;
                    default:
                        if(orOperation)
                        {
                            ndfa._toestanden.Add(new Toestand<char>(t._name, new Tuple<string, char>(t._voglendeToestand.Item1, c)));
                        }
                        else
                        {
                            if(ndfa._toestanden.Count == 0)
                                ndfa._toestanden.Add(new Toestand<char>("0", new Tuple<string, char>((ndfa._toestanden.Count + 1).ToString(), c)));
                            else
                                ndfa._toestanden.Add(new Toestand<char>(t._voglendeToestand.Item1, new Tuple<string, char>((ndfa._toestanden.Count + 1).ToString(), c)));
                        }
                            
                        orOperation = false;
                        break;
                }
                index++;
            }
            ndfa._startSymbolen.Add(ndfa._toestanden.First()._name);
            int eindtoestand = 0;
            foreach (var r in ndfa._toestanden)
            {
                if (eindtoestand < int.Parse(r._voglendeToestand.Item1))
                    eindtoestand = int.Parse(r._voglendeToestand.Item1);
                if (!r._voglendeToestand.Item2.Equals(EPSILON))
                    ndfa._invoerSymbolen.Add(r._voglendeToestand.Item2);
            }
            ndfa._eindToestanden.Add(eindtoestand.ToString());
            return ndfa;
        }

        public bool Equals(Expressie other)
        {
            if (other == null)
            {
                return false;
            }
            else if (this.ToString() == other.ToString() && this.terminals == other.terminals && this.op == other.op && this.left == other.left && this.right == other.right)
            {
                return true;
            }
            else
                return false;
        }

        public override string ToString()
        {
            string expressie = "";
            Expressie mostleft = left;
            if (mostleft != null)
            {
                while (mostleft != null)
                {
                    mostleft = left.left;
                }
                while (mostleft.right != null)
                {
                    expressie += mostleft.terminals;
                    mostleft = mostleft.right;
                }
            }
            else {
                expressie = terminals;
            }
            return expressie;
        }
    }
}
