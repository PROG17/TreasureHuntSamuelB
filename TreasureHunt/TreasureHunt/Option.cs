using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Option
    {
        Func<string> executeFunc;

        public string Key { get; set; }
        public ConsoleKey CKey { get; set; }

        public Option(string key, Func<string> executeFunc, ConsoleKey cKey = ConsoleKey.X) //treat Ckey X as NO key at all which is default
        {
            this.CKey = cKey; 
            this.Key = key;
            this.executeFunc = executeFunc;
        }

        public string Execute()
        {
            return this.executeFunc();
        }
    }
}
