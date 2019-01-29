using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppElComercio
{
    public class ChangeString
    {
        private static readonly List<char> Letter = new List<char>{
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','ñ','o','p','q','r','s','t','u','v','w','x','y','z'
        };
        public string Build(string text)
        {
            var result = "";
            foreach (var item in text.ToCharArray())
            {
                var charAfter = new char();
                if (Char.IsLetter(item))
                {
                    if (char.IsUpper(item))
                    {
                        charAfter = Char.ToUpper(char.ToLower(item) == 'z' ? 'A' : Letter[Letter.IndexOf(char.ToLower(item)) + 1]);
                    }
                    else
                    {
                        charAfter = Char.ToLower(char.ToLower(item) == 'z' ? 'a' : Letter[Letter.IndexOf(char.ToLower(item)) + 1]);
                    }
                }
                else
                {

                    charAfter = item;
                }

                result = result + charAfter;
            }
            return result;
        }
    }
}
