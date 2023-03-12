using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CsPySeacher
{
    class Backend
    {
        public static string PATH = "";
        public static string init()
        {
            string res = run("test", new string[] { });
            return res;
        }
        public static void cdpath(string path)
        {
            Regex regex = new Regex("\\\\");
            PATH = regex.Replace(path, "/");
        }
        public static string run(string func_name, string[] args)
        {
            List<string> list = new List<string>(args);
            list.Insert(0, "\'" + PATH + "\'"); //cmd trick的引号不可不慎！
            string res = Cmd.Run(func_name, list.ToArray());
            return res;
        }
    }
}
