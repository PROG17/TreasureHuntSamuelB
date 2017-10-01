using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System. Threading.Tasks;

namespace TreasureHunt
{
    static class ListExtensions
    {
        public static bool ContainsSingle(this List<string> strings, string value, out int index)
        {
            index = -1;

            List<string> stringsCopy = new List<string>(strings);
            var indexes = stringsCopy.Select((s,i) =>  i );
            var indexList= indexes.ToList();

            string[] values = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string requestedValue in values)
            {
                for (int i = stringsCopy.Count - 1; i >= 0; i--)
                {
                    if (!stringsCopy[i].Contains(requestedValue))
                    {
                        stringsCopy.RemoveAt(i);
                        indexList.RemoveAt(i);
                    }
                }
            }

            if (stringsCopy.Count == 1)
            {
                index = indexList[0];
                return true;
            }
            else
                return false;
        }

    }
}
