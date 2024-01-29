using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CountWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = Words.CountWords("Enter the text you want to analyze. " +
                "Put the text here, whatever the text that you want to analyze " +
                "TO COUNT EACH WORD IN DESCENDING ORDER");

            foreach (var d in dic)
            {
                Console.WriteLine($"Word: {d.Key} | Count: {d.Value}");
            }
        }
    }
    class Words
    {
        public static Dictionary<string, int> CountWords(string s)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            s = s.ToLower();
            string pattern = @"[0-9a-z]";
            string word = null;
            bool proc = false;
            bool end = false;
            Dictionary<string, int> occ = new Dictionary<string, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (Regex.IsMatch(s[i].ToString(), pattern))
                {
                    word = word + s[i].ToString();
                    proc = true;
                    end = false;
                    if (i == s.Length - 1)
                    {
                        end = true;
                    }
                }
                else
                {
                    end = true;
                }
                if (proc == true && end == true)
                {
                    if (occ.ContainsKey(word))
                        occ[word] = occ[word] + 1;
                    else
                        occ.Add(word, 1);
                    word = null;
                    proc = false;
                    end = false;
                }
            }
            int j = occ.Count;
            for (int i = 0; i < j; i++)
            {
                int max = 0;
                string palabra = null;
                foreach (var dict in occ)
                {
                    if (dict.Value > max)
                    {
                        palabra = dict.Key;
                        max = dict.Value;
                    }
                }
                if (palabra != null)
                {
                    res.Add(palabra, max);
                    occ.Remove(palabra);
                }
            }
            return res;
        }
    }
}