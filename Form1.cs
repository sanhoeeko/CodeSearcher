using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsPySeacher
{
    public partial class Form1 : Form
    {
        public static string focus_name;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search
            string name = textBox1.Text;
            var selected_node = treeView1.SelectedNode;
            if (selected_node == null)
            {
                return;
            }
            else
            {
                var new_node = new TreeNode(name);
                selected_node.Nodes.Add(new_node);
                selected_node.Expand();
                this.treeView1.Select();
            }
            //不可用双引号，因为它包裹着指令的最外层
            string res = Backend.run("search", new string[] { "\'" + name + "\'" });
            label1.Text = res;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cd path
            string path = textBox1.Text;
            Backend.cdpath(path);
            label1.Text = "cd " + path;
            textBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string res = Backend.init();
            label1.Text = res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            var selected_node = treeView1.SelectedNode;
            if (selected_node != null) 
            {
                selected_node.Remove();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selected_node = treeView1.SelectedNode;
            string name = selected_node.Text;
            string res = Backend.run("search", new string[] { "\'" + name + "\'" });
            label1.Text = res;
        }
    }
}
