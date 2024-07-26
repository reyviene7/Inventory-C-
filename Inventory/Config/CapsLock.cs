using System.Globalization;
using System.Windows.Forms;

namespace Inventory.Config
{
    public static class CapsLock
    {
        private static CultureInfo ci = new CultureInfo("en-US");
        public static string ToTitleCase(this string str)
        {
            str = str.ToLower();
            var strArray = str.Split(' ');
            if (strArray.Length > 1)
            {
                strArray[0] = ci.TextInfo.ToTitleCase(strArray[0]);
                return string.Join(" ", strArray);
            }
            return ci.TextInfo.ToTitleCase(str);
        }
        public static string ToTitleCase(this string str, TitleCase tcase)
        {
            str = str.ToLower();
            switch (tcase)
            {
                case TitleCase.First:
                    var strArray = str.Split(' ');
                    if (strArray.Length > 1)
                    {
                        strArray[0] = ci.TextInfo.ToTitleCase(strArray[0]);
                        return string.Join(" ", strArray);
                    }
                    break;
                case TitleCase.All:
                    return ci.TextInfo.ToTitleCase(str);
                default:
                    break;
            }
            return ci.TextInfo.ToTitleCase(str);
        }

        public static void UpperCase(TextBox textBox)
        {
            char[] v = textBox.Text.ToCharArray();
            string s = v[0].ToString().ToUpper();
            for (int b = 1; b < v.Length; b++)
                s += v[b].ToString().ToLower();
            textBox.Text = s;
            textBox.Select(textBox.Text.Length, 0);
        }
    }
    public enum TitleCase
    {
        First,
        All
    }
}
