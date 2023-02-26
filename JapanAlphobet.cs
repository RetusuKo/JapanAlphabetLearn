using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapanRandomHiraganaKatakana
{
    internal class JapanAlphobet
    {
        private static List<string[]> Alphabets = new List<string[]>
        {
            new string[11]
            {
            "あいうえお",
            "かきくけこ",
            "さしすせそ",
            "たちつてと",
            "なにぬねの",
            "はひふへほ",
            "まみむめも",
            "やゆよ",
            "らりるれろ",
            "わを",
            "ん",
            },
            new string[11]
            {
            "アイウエオ",
            "カキクケコ",
            "サシスセソ",
            "タチツテト",
            "ナニヌネノ",
            "ハヒフヘホ",
            "マミムメモ",
            "ヤユヨ",
            "ラリルレロ",
            "ワヰヱヲ",
            "ン",
            }
        };
        public static string RandomAlphabet(int rowNumber, AlphabetType type, bool includePreviousRows = false)
        {
            Random random = new Random();
            StringBuilder selectedAlphabet = new StringBuilder(Alphabets[(int)type][rowNumber]);
            if (includePreviousRows)
            {
                var previousRows = Enumerable.Range(0, rowNumber).Select(i => Alphabets[(int)type][i]);
                selectedAlphabet.Append(string.Join(string.Empty, previousRows));
            }
            StringBuilder randomAlphabet = new StringBuilder();
            for (int i = random.Next(4); i >= 0; i--)
                randomAlphabet.Append(selectedAlphabet[random.Next(selectedAlphabet.Length)]);
            return randomAlphabet.ToString();
        }
        public enum AlphabetType
        {
            Hiragana,
            Katakana
        }
    }
}
