using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Teacher";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["Id"].ToString();
                b = dr["Name"].ToString();
                c = dr["PassWord"].ToString();
                d = dr["ZC"].ToString();

                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 f = new Form41(this);
            f.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString()};

            Form41 f = new Form41(str, this);
            f.ShowDialog();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string tID = dataGridView1.SelectedCells[0].Value.ToString();
                string tName = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Teacher where Id='" + tID + "' and Name ='" + tName + "'";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                 }
            }
            Table();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
