using System;
using System.Collections.Generic;

namespace Reorganize_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aaabbbcdd";
            Solution s = new Solution();
            var answer = s.ReorganizeString(str);
            Console.WriteLine(answer);
        }
    }

    // Run time - O(N)
    // Space - O(N)
    public class Solution
    {
        public string ReorganizeString(string s)
        {
            Dictionary<char, int> frequency = new Dictionary<char, int>();
            // store the max frequency
            int max = 0;
            // store the max frequency character
            char maxc = s[0];
            foreach (char c in s)
            {
                if (!frequency.ContainsKey(c))
                {
                    frequency.Add(c, 0);
                }
                frequency[c]++;
                if (frequency[c] > max)
                {
                    max = frequency[c];
                    maxc = c;
                }
            }


            int length = s.Length;
            char[] result = new char[length];
            // Base condition
            if (max > (length + 1) / 2) return "";

            int idx = 0;
            // put all the max frequent char in the result string and reduce the char frequency by 1 at each step
            while (idx < length && max > 0)
            {
                result[idx] = maxc;
                idx += 2;
                frequency[maxc]--;
                max--;
            }

            foreach (var kvp in frequency)
            {
                char key = kvp.Key;
                int val = kvp.Value;
                // this condition to skip the already processed max char
                while (val > 0)
                {
                    // when idx reach to end , reset the idx to start from 1
                    if (idx >= length)
                    {
                        idx = 1;
                    }
                    result[idx] = key;
                    idx += 2;
                    val--;
                }

            }

            return new String(result);
        }
    }
}
