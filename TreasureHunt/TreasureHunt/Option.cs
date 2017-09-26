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

        public Option(string key, Func<string> executeFunc)
        {
            this.Key = key;
            this.executeFunc = executeFunc;
        }

        public string Execute()
        {
            return this.executeFunc();
        }
    }
}
