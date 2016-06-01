using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeleMethoden
{
    class Transition
    {
        private string fromState;
        private char symbol;
        private string toState;

        public Transition(string from, char s, string to)
        {
            this.fromState = from;
            this.toState = to;
            this.symbol = s;
        }
    }
}
