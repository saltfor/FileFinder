using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        string directory = "";
        int size = 0;
        ArrayList files = new ArrayList();
        List<long> fileSize = new List<long>();
        ArrayList fileDirectory = new ArrayList();

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (directchoosedlg.ShowDialog() == DialogResult.OK)
            {
                directory = directchoosedlg.SelectedPath;
                label1.Text = directory;
                button1.Enabled = false;
                DirSearch(directory);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            for(int i = 0; i < size; i++)
            {
                bool isSame = false;
                for (int j = i + 1; j < size; j++)
                {
                    if (files[i].ToString() == files[j].ToString() && fileSize[i]==fileSize[j] && files[j].ToString()!="-")
                    {
                        isSame = true;
                        listBox1.Items.Add(files[j]);
                        listBox2.Items.Add(fileSize[j] + " KB");
                        listBox3.Items.Add(fileDirectory[j]);
                        files[j] = "-";
                    }
                }
                if (isSame)
                {
                    listBox1.Items.Add(files[i]);
                    listBox2.Items.Add(fileSize[i] + " KB");
                    listBox3.Items.Add(fileDirectory[i]);
                }
            }

            button3.Enabled = true;
        }
        void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, "*.*"))
                    {
                        FileInfo info = new FileInfo(f);
                        size++;
                        files.Add(info.Name);
                        fileSize.Add(info.Length);
                        fileDirectory.Add(info.DirectoryName);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            listBox3.SelectedIndex = listBox1.SelectedIndex;
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<files></files>");
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                XmlElement newElem = doc.CreateElement("file");
                newElem.InnerText = listBox1.Items[i] + " - " + listBox2.Items[i] + " - " + listBox3.Items[i];
                doc.DocumentElement.AppendChild(newElem);
            }

            doc.PreserveWhitespace = true;
            doc.Save("data.xml");
            MessageBox.Show("Data has saved to XML!");
        }
    }
}
