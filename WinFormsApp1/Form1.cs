using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(login())
            {
                timer1.Start();//启动计时器
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1 .Visible = false;
                button1 .Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;

            }
        }
        private bool login()
        {
            if(textBox1.Text==""||textBox2.Text==""||comboBox1.Text=="")
            {
                MessageBox.Show("输入不完整，请检查","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(comboBox1.Text=="学生")
            {
                string sql = "select * from Student where Name='" + textBox1.Text + "'and PassWord='"+textBox2.Text+ "'";
                Dao dao = new Dao();
                IDataReader dr=dao.read(sql);
                if(dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (comboBox1.Text == "老师")
            {
                string sql= "select * from Teacher where Name='" + textBox1.Text + "'and PassWord='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    return false;
                }
            }
            if (comboBox1.Text == "管理员")
            {
                if(textBox1.Text=="admin"&&textBox2.Text=="admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 150)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                if(comboBox1.Text=="学生")
                {
                    string sql = "select * from Student where Name='" + textBox1.Text + "'and PassWord='" + textBox2.Text + "'";
                    Dao dao = new Dao();
                    IDataReader dr = dao.read(sql);
                    dr.Read();
                    string sID = dr["id"].ToString();
                    Form3 form3 = new Form3 (sID);
                    
                    form3.Show();
                    this.Hide();
                    //this.Close(); 
                }
                else
                {
                    if(comboBox1.Text=="老师")
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        if(comboBox1.Text=="管理员")
                        {
                            Form4 form4 = new Form4();
                            form4.Show();
                            this.Hide();
                        }
                    }
                }
                timer1.Stop();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;

        }
    }
}
