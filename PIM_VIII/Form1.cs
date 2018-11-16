using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PIM_VIII
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Documentos\UNIP\5o Bimestre\PROJETO INTEGRADO MULTIDISCIPLINAR VIII\Project\PIM_VIII\DataBase.accdb");
        public Form1()
        {
            InitializeComponent();
            gridRefresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Tabela1 values('"+textBox1.Text+"','"+ dateTimePicker1.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            gridRefresh();
            MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gridRefresh();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Tabela1 where Tarefa= '"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            gridRefresh();
            MessageBox.Show("Dados apagados com sucesso!");
        }

        private void gridRefresh()
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tabela1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
}
}
