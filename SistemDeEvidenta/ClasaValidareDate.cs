using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemDeEvidenta
{
    class ClasaValidareDate
    {
        public static bool VerifClasa(string text)
        {
            if (text.Length == 0 || text.Length > 2)
                return false;
            for (int i = 0; i < text.Length; i++)
                if (!Char.IsDigit(text[i]))
                    return false;
            if (text[0] == '0')
                return false;
            int nr = Int32.Parse(text);
            if (nr < 1 || nr > 12)
                return false;
            return true;
        }
        public static bool VerifNume(string text)
        {
            if (text.Length < 3) return false;
            for (int i = 0; i < text.Length; i++)
                if (!Char.IsLetter(text[i]) && text[i]!=' ')
                    return false;
            return true;
        }
        public static bool VerifPrenume(string text)
        {
            if (text.Length < 3) return false;
            for (int i = 0; i < text.Length; i++)
                if (!Char.IsLetter(text[i]) && text[i] != ' ')
                    return false;
            return true;
        }
        public static bool  VerifEmail(string text)
        {
            if (text.Length < 7)
                return false;
            int ap = 0, ar = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                    ar++;
                if (text[i] == '.')
                    ap++;
            }
            if (ar != 1 || ap != 1)
                return false;
            return true;
        }

        public static bool VerifNrtlf(string text)
        {
            if (text.Length != 10) return false;
            for (int i = 0; i < 10; i++)
                if (!Char.IsDigit(text[i]))
                    return false;
            return true;
        }
        public static bool VerifAdresa(string text)
        {
            int cnt = 0;
            for (int i = 0; i < text.Length; i++)
                if (Char.IsLetter(text[i]))
                    cnt++;
            if (cnt < 4) return false;
            return true;
        }
        public static bool VerifData(System.Windows.Forms.DateTimePicker d)
        {
            if (d.Text.Length == 0 || d.Value == null) return false;
            return true;
        }

        public static bool VerifCB(System.Windows.Forms.ComboBox d)
        {
            if (string.IsNullOrEmpty(d.Text) || d.SelectedIndex == -1)
                return false;
            return true;
        }
    }
}
