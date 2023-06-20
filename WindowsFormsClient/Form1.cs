using ConsoleClientMessager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        private static int MessageID = 0;
        private static string UserName;
        private static MessagerClientAPI API = new MessagerClientAPI();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;
            string Message = textBox2.Text;
            if ((Message.Length>1) && (UserName.Length > 1))
            {
                ConsoleClientMessager.Message msg = new ConsoleClientMessager.Message(UserName, Message, DateTime.UtcNow);
                API.SendMessage(msg);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var getMessage = new Func<Task>(async () =>
            {
                
                ConsoleClientMessager.Message msg = await API.GetMessageHTTPAsync(MessageID);
                while (msg != null)
                {
                    listBox1.Items.Add(msg);
                    MessageID++;
                    msg = await API.GetMessageHTTPAsync(MessageID);
                }
            });
            getMessage.Invoke();
        }
    }
}
