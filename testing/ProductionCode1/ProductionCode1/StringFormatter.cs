using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductionCode1
{
    public class StringFormatter
    {
        readonly string[] _keyWords = new[] { "select", "insert", "update", "delete"}; 

        public string SafeString(string s)
        {
            if (s == null)
                throw new NullReferenceException();

            if (s == string.Empty)
                return s;

            string localString = s.Replace("'", "''");

            foreach (var keyWord in _keyWords)
                localString = new Regex(keyWord, RegexOptions.IgnoreCase).Replace(localString, keyWord.ToUpper());

            return localString;
        }
    }
}
