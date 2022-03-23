using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form31 : Form
    {
        string SID;
        public Form31(string sID)
        {
            SID = sID;
            InitializeComponent();
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from CourseRecord where sid ='" + SID + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string cID = dr["cid"].ToString();
                string sql2 = "select * from Course where id='" + cID + "'";
                IDataReader dr2 = dao.read(sql2);
                dr2.Read();
                string a, b, c, d;
                
                a = dr2["id"].ToString();
                b = dr2["Name"].ToString();
                c = dr2["Teacher"].ToString();
                d = dr2["Credit"].ToString();
                string[] str = { a, b, c, d };
                dataGridView2.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();
        }

        private void Form31_Load(object sender, EventArgs e)
        {

        }

        private void 取消这门课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cID = dataGridView1.SelectedCells[0].Value.ToString();
            string sql = "delete CourseRecord where sid='" + SID + "'and cid='" + cID + "'";
            Dao dao= new Dao();
            dao.Excute(sql);
            Table();
        }
    }
}
