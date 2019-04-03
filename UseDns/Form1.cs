using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseDns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty)
            {
                MessageBox.Show("请输入主机名");
            }
            else
            {
                textBox2.Text = string.Empty;
                IPAddress[] ips = Dns.GetHostAddresses(textBox1.Text);
                foreach (var item in ips)
                {
                    textBox2.Text = item.ToString();
                }
                textBox3.Text = Dns.GetHostName();
                //根据指定的主机名获取DNS信息
                textBox4.Text = Dns.GetHostByName(Dns.GetHostName()).HostName;
            }
        }
    }
}
