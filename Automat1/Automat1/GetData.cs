using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Automat1
{
    class GetData
    {
        public Automat GetAutomat(string fileName)
        {
            Automat automat = null;
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string s = streamReader.ReadToEnd();
                automat = JsonConvert.DeserializeObject<Automat>(s);
            }
            return automat;
        }

        public Lex GetLex()
        {
            var result = new List<Automat>();
            var automatByIdObject = GetAutomat("idAutomation.txt");
            result.Add(automatByIdObject);

            var automatByIntObject = GetAutomat("intAutomation.txt");
            result.Add(automatByIntObject);

            var automatByrealObject = GetAutomat("realAutomation.txt");
            result.Add(automatByrealObject);

            var automatBySpaceObject = GetAutomat("spaceAutomation.txt");
            result.Add(automatBySpaceObject);

            var automatByOperatorObject = GetAutomat("operatorAutomation.txt");
            result.Add(automatByOperatorObject);

            var automatByBoolObject = GetAutomat("boolAutomation.txt");
            result.Add(automatByBoolObject);

            var automatByWordObject = GetAutomat("keywordAutomation.txt");
            result.Add(automatByWordObject);

            return new Lex(result);
        }
    }
}
