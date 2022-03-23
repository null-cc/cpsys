using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        string SID;
        public Form3(string sID)
        {
            SID = sID;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            toolStripStatusLabel1.Text = "欢迎学号为" + SID + "的同学登录选课系统";
            timer1.Start();
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Course";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while(dr.Read())
            {
                string a, b, c, d;
                a=dr["id"].ToString();
                b= dr["Name"].ToString();
                c = dr["Teacher"].ToString();
                d=dr["Credit"].ToString();
                
                string[]str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            string cID = dataGridView1.SelectedCells[0].Value.ToString();//获取选课信息
            string sql1 = "select * from CourseRecord where sid='" + SID+"'and cid='"+cID+"'";
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql1);
            if(!dc.Read())
            {
                string sql = "insert into CourseRecord values('" + SID + "','" + cID + "')";
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("选课成功");
                }
            }
            else
            {
                MessageBox.Show("不允许重复选课");
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31(SID);
            f.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
