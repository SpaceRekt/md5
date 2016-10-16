using System;
using System.Text;
using System.Windows.Forms;

namespace md5
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                string hash = md5(string.Join("", args));
                Clipboard.SetText(hash);
                Console.WriteLine($"Set to clipboard! [{hash}]");
            }
            else
            {
                Console.WriteLine("ERROR: Correct Syntax is: md5 [string hash]");
            }
        }

        public static string md5(string raw)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(raw));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}
