﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class urunler : Form
    {
        Class1 marketotomasyon=new Class1 ();
        public urunler()
        {
            InitializeComponent();
        }

        private void urunler_Load(object sender, EventArgs e)
        {
            Yenilelistele();
        }

        private void Yenilelistele()
        {
            string cümle = "select *from urunekle";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource=marketotomasyon.listele(adtr2, cümle);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1gecis = new Form1();
            this.Hide();
            form1gecis.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cümle = "update urunekle set urunadi=@urunadi,urunaliş=@urunaliş,urunsatiş=@urunsatiş where urunkodu=@urunkodu";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@urunadi", txtad.Text);
            komut2.Parameters.AddWithValue("@urunkodu", txtkod.Text);
            komut2.Parameters.AddWithValue("@urunaliş", txtaliş.Text);
            komut2.Parameters.AddWithValue("@urunsatiş", txtsatiş.Text);
            marketotomasyon.ekle_sil_güncelle(komut2, cümle);
            foreach (Control item in Controls) if (item is TextBox) item.Text="";
            Yenilelistele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1gecis = new Form1();
            this.Hide();
            form1gecis.ShowDialog();
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string cümle = "select *from urunekle where urunkodu like '%"+textBox5.Text+"%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource=marketotomasyon.listele(adtr2, cümle);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtad.Text=satir.Cells[0].Value.ToString();
            txtkod.Text=satir.Cells[1].Value.ToString();
            txtaliş.Text=satir.Cells[2].Value.ToString();
            txtsatiş.Text=satir.Cells[3].Value.ToString();


        }
    }
}
