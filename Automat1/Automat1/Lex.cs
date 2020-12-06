using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat1
{
    class Lex
    {
        List<Automat> automats;
        Dictionary<Automat, string> Tokens;
        public Lex(List<Automat> automats)
        {
            Tokens = new Dictionary<Automat, string>();
            this.automats = automats;
            Tokens.Add(automats[0], "ID");
            Tokens.Add(automats[1], "int");
            Tokens.Add(automats[2], "real");
            Tokens.Add(automats[3], "space");
            Tokens.Add(automats[4], "operation");
            Tokens.Add(automats[5], "bool");
            Tokens.Add(automats[6], "keyword");

        }
        public HashSet<KeyValuePair<string, string>> toRecognizeCode(string inputText, ref int skip)
        {
            var resultLex = new HashSet<KeyValuePair<string, string>>();
            while (skip < inputText.Length)
            {
                int maxCount = -1;
                Automat automat = null;
                string s = "";
                bool isRecognize = false;
                foreach (var item in automats)
                {
                    var result = item.toRecognize(inputText, skip);
                    if (result.Value != 0)
                    {
                        isRecognize = true;
                        if (result.Value > maxCount)
                        {
                            maxCount = result.Value;
                            automat = item;
                            s = inputText.Substring(skip, result.Value);
                        }
                        if (result.Value == maxCount)
                        {
                            if (item.Priority > automat.Priority)
                            {
                                automat = item;
                                s = inputText.Substring(skip, result.Value);
                            }
                        }
                    }
                }
                if (isRecognize)
                {
                    resultLex.Add(new KeyValuePair<string, string>(s, Tokens[automat]));
                    skip += maxCount;
                }
                else
                {
                    skip++;
                }
            }
            return resultLex;
        }
    }
}
