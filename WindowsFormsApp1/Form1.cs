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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-260HDTK;Initial Catalog=market_otomasyon;Integrated Security=True");
        DataSet daset = new DataSet();
        private void sepetlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Sepet", baglanti);
            adtr.Fill(daset, "Sepet");
            dataGridView1.DataSource = daset.Tables["Sepet"];
            dataGridView1.Columns[0].Visible=false;
            dataGridView1.Columns[1].Visible=false;
            dataGridView1.Columns[2].Visible=false;

            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'market_otomasyonDataSet5.Sepet' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sepetTableAdapter.Fill(this.market_otomasyonDataSet5.Sepet);
            sepetlistele();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            urunler urunler = new urunler();
            this.Hide();
            urunler.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if(item is TextBox  ){
                        if (item != textBox2)
                        {
                            item.Text="";
                        }
                    }
                  

                       
                    
                }
            }
                baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urunekle where urunkodu like '"+textBox1.Text+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            
                while (read.Read())
                {
                    textBox3.Text=read["urunadi"].ToString();
                    textBox4.Text=read["urunsatiş"].ToString();
                }
                baglanti.Close();
            }
        }
    }

