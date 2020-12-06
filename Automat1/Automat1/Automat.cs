using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat1
{
    class Automat
    {
        Dictionary<KeyValuePair<int, string>, int> transitions;
        public KeyValuePair<KeyValuePair<int, string>, int>[] Transitions
        {
            get
            {
                return transitions.ToArray();
            }
            set
            {
                transitions = value.ToDictionary(x => x.Key, y => y.Value);
            }
        }
        public int MarkerState { get; set; }
        public int StartState { get; set; }
        public int Priority { get; set; }
        public HashSet<int> FinishState { get; set; }
        public Automat()
        {
            transitions = new Dictionary<KeyValuePair<int, string>, int>();
        }
        public Automat(Dictionary<KeyValuePair<int, string>, int> transitions, int startState, HashSet<int> finishState)
        {
            this.transitions = transitions;
            StartState = startState;
            FinishState = finishState;

        }
        public KeyValuePair<bool, int> toRecognize(string s, int skip)
        {
            MarkerState = StartState;
            bool isRecognize = false;
            int countOfSymbol = 0;
            int index = skip;
            while (index < s.Length)
            {
                string str = s[index].ToString();
                if (transitions.ContainsKey(new KeyValuePair<int, string>(MarkerState, str)))
                {
                    isRecognize = true;
                    countOfSymbol++;
                    MarkerState = transitions[new KeyValuePair<int, string>(MarkerState, str)];
                    index++;
                }
                else
                {
                    break;
                }
            }
            if (!FinishState.Contains(MarkerState))
            {
                isRecognize = false;
                countOfSymbol = 0;
            }

            return new KeyValuePair<bool, int>(isRecognize, countOfSymbol);
        }
    }
}
