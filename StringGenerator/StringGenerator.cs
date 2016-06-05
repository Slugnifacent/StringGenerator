using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringGenerator
{
    class StringGenerator
    {
        StreamWriter file;
        Regex regexPattern;
        List<Entry> Options;
        MatchCollection matches;

        public StringGenerator(string Filename,string RegexPattern)
        {
            file = new System.IO.StreamWriter(Filename, true);
            regexPattern = new Regex(RegexPattern);
            Options = new List<Entry>();
        }

        public void ProcessString(string value)
        {
            matches = regexPattern.Matches(value);
             
            for (Byte index = 0; index < matches.Count; ++index)
            {
                string[] splits = matches[index].Groups[1].Value.Split('|');
                Entry temp = new Entry(matches[index].Value, splits);
                Options.Add(temp);
            }
            if (Options.Count > 0)
            {
                GenerateString(value, Options, 0);
            }
            else
            {
                file.WriteLine(value);
                file.Flush();
            }
            Options.Clear();
        }

        private void GenerateString(string String, List<Entry> Options, Byte CurrentIndex)
        {
            for (Byte index = 0; index < Options[CurrentIndex].entries.Length; ++index)
            {
                // Check if the next step is at the bottom
                string Value = String.Replace(Options[CurrentIndex].match, Options[CurrentIndex].entries[index]);
                if (CurrentIndex + 1 >= Options.Count)
                {
                    file.WriteLine(Value);
                    file.Flush();
                    continue;
                }
                else {
                    GenerateString(Value, Options, ++CurrentIndex);
                    --CurrentIndex;
                }
            }
        }
    }
}
