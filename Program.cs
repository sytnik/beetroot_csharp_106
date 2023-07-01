using System.Text;

namespace beetroot_csharp_106;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        List<char> chs = DuplicateUsingList("hello world");
        char[] charArr = Duplicate("hello world");
        StrInterpolation();
    }

    static void StrInterpolation()
    {
        string str1 = "Hello";
        string str2 = "hello";
        bool res1 = str1.ToLower() == str2.ToLower();
        bool result = str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine(result); // виведе true

        var ch = 'a'.ToString();
        string someText = "This is a var of:";
        var r1 = someText[5..];
        var r2 = someText[5..10];
        var sub1 = someText.Substring(5);
        var sub2 = someText.Substring(5, 5);
        var f1 = someText.IndexOf('i');
        var f2 = someText.IndexOf("va");
        var f3 = someText.LastIndexOf("a", StringComparison.Ordinal);
        var rp1 = someText
            .Replace('i', 'x')
            .Replace("ar", "bx");
        var strtoTrim1 = "   " + someText + "  ";
        var strtoTrim = $"   {someText}  ";
        var tr1 = strtoTrim.TrimStart();
        var tr2 = strtoTrim.TrimEnd();
        var tr3 = strtoTrim.Trim();
        var rp2 = someText.Replace("ar", "bx");
        var nl = $"test\r\ntest{Environment.NewLine}test";
        someText += "123";
        int vari = 15000;
        string endText = "is ready";
        // concatenation
        string concat = someText + " " + vari + " " + endText;
        // interpolation
        string inter = $"{someText} and text {vari} {endText}";
        // stringbuilder
        StringBuilder sb = new StringBuilder();
        sb = sb.Append(someText)
            .Append(" ")
            .Append(vari)
            .Append(" ")
            .Append(endText);
        string res = sb.ToString();
        StringBuilder sb1 = new StringBuilder();
        sb1 = sb1.AppendJoin(" ", someText, vari, endText);
        string re1 = sb1.ToString();
        // join to one string if separator is the same
        var intList = new List<int>();
        intList.Add(1);
        string res2 =
            string.Join(" ", someText, vari, endText);
        
        string res3 =
            new StringBuilder()
                .AppendJoin(" ", someText, vari, endText)
                .ToString();
    }

    static bool Compare(string str1, string str2)
    {
        if (str1.Length != str2.Length)
        {
            return false;
        }

        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
            {
                return false;
            }
        }

        return true;
    }

    static void Analyze(string input,
        out int numAlphabetic, out int numDigits, out int numSpecial)
    {
        numAlphabetic = 0;
        numDigits = 0;
        numSpecial = 0;
        // char[] arr = input.ToCharArray();
        // input = arr.ToString();
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                numAlphabetic++;
            }
            else if (char.IsDigit(c))
            {
                numDigits++;
            }
            else // if not letter or digit
            {
                numSpecial++;
            }
        }
    }

    static string Sort(string str)
    {
        // string => char[]
        char[] chars = str.ToCharArray();
        // sort array
        Array.Sort(chars, StringComparer.OrdinalIgnoreCase);
        // char[] => string
        str = new string(chars);
        return str;
    }

    static char[] Duplicate(string str)
    {
        // with resize new char[str.Length]
        char[] duplicates = new char[0];
        char[] seen = new char[str.Length];
        int duplicateIndex = 0;
        int seenIndex = 0;

        foreach (char c in str)
        {
            bool isDuplicate = false;
            for (int i = 0; i < seenIndex; i++)
            {
                if (c == seen[i])
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (isDuplicate)
            {
                bool isAlreadyAdded = false;
                for (int i = 0; i < duplicateIndex; i++)
                {
                    if (c == duplicates[i])
                    {
                        isAlreadyAdded = true;
                        break;
                    }
                }

                if (!isAlreadyAdded) // not true
                {
                    Array.Resize(ref duplicates, duplicates.Length + 1);
                    duplicates[duplicateIndex++] = c;
                }
            }
            else
            {
                seen[seenIndex++] = c;
            }
        }

        // with resize
        // Array.Resize(ref duplicates, duplicateIndex);

        return duplicates;
    }

    static List<char> DuplicateUsingList(string str)
    {
        List<char> duplicates = new List<char>(); // 0 elements
        List<char> seen = new List<char>(); // 0 elements
        str = str.Replace(" ", ""); // => "str"
        foreach (char c in str)
        {
            if (seen.Contains(c) && !duplicates.Contains(c))
            {
                duplicates.Add(c); // size +1
            }
            else // if is not seen or is in the duplicates list
            {
                seen.Add(c);
            }
        }

        char[] dupArray = duplicates.ToArray();
        List<char> dupList = dupArray.ToList();
        return duplicates;
    }
}