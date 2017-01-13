using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace T100Test
{
    public class T100XML
    {
        public static bool CreateT100XML(string filename,string tabledata,ref string xmldata,ref StringWriter sw)
        {
            try
            {
                StreamReader sr = new StreamReader(filename, Encoding.Default);
                string line;
                StringWriter _s = new StringWriter();
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line.ToString());
                    xmldata += line.ToString();
                    _s.WriteLine(line.ToString());
                }
                xmldata = _s.ToString();
                xmldata = xmldata.Replace("@Detail", tabledata);
                return true;
            }
            catch(Exception ex)
            {
                sw.WriteLine(ex.Message);
                sw.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public static bool CreateT100Detail(DataTable dt, string filename,ref string tabledata, ref StringWriter sw)
        {
            try
            {
                StreamReader sr = new StreamReader(filename, Encoding.UTF8);
                string line;
                StringWriter _s = new StringWriter(); 
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line.ToString());
                    //tabledata += line.ToString();
                    _s.WriteLine(line.ToString());
                }
                tabledata = _s.ToString();
                return true;
            }
            catch(Exception ex)
            {
                sw.WriteLine(ex.Message);
                sw.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
