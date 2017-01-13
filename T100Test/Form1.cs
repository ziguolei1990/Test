using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T100Test
{
    public partial class Form1 : Form
    {
        private static string PATH = @"C:\Log\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\T100Test\";
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {

        }

        private void button_Stop_Click(object sender, EventArgs e)
        {

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            string filenamePreFunction = "button1_Click";
            try
            {
                string tabledata = "";
                string xmldata = "";
                string path = Application.StartupPath + "\\";
                bool flag= T100XML.CreateT100Detail(null, path+ @"txt\T100Detail.txt", ref tabledata, ref sw);
                if (!flag)
                {
                    throw new Exception("Detail Error");
                }
                flag = T100XML.CreateT100XML(path + @"txt\Detail.txt", tabledata, ref xmldata, ref sw);
                if (!flag)
                {
                    throw new Exception("Xml Error");
                }


                #region Testdaaaa
                //测试数据
                #endregion

                sw.WriteLine("提交的数据：");

                sw.WriteLine(xmldata);

                T100WBS.TIPTOPServiceGateWay t = new T100WBS.TIPTOPServiceGateWay();
                string respone = t.invokeSrv(xmldata);

                sw.WriteLine("返回结果：");
                sw.WriteLine(respone);

                MessageBox.Show("OK---");
            }
            catch(Exception ex)
            {
                sw.WriteLine(ex.Message);
                sw.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                string filename = filenamePreFunction + "-" + System.DateTime.Now.ToFileTime() + ".txt";
                if (!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }
                File.WriteAllText(PATH + filename, sw.ToString(), Encoding.UTF8);
            }

        }
        public string Testxml()
        {
            return @"";
        }
    }
}
