using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_kayit
{
    public partial class FrmHomePage : Form
    {
        public FrmHomePage()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-U2CN370; Initial Catalog = PersonelVeriTabani; Integrated Security = True");
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtmeslek.Text = "";
            cmbsehir.Text = "";
            mskmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_Personel);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
          this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_Personel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand komut = new SqlCommand("insert into tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", conn);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Veri Eklendi!");
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komutSil = new SqlCommand("Delete From tbl_Personel Where PerId=@k1",conn);
            komutSil.Parameters.AddWithValue("@k1", txtid.Text);
            komutSil.ExecuteNonQuery();
            MessageBox.Show("Veri Silindi!");
            conn.Close();


        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komutGuncelle = new SqlCommand("update tbl_personel set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where PerId=@a7",conn);
            komutGuncelle.Parameters.AddWithValue("@a1",txtad.Text);
            komutGuncelle.Parameters.AddWithValue("@a2",txtsoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@a3",cmbsehir.Text);
            komutGuncelle.Parameters.AddWithValue("@a4",mskmaas.Text);
            komutGuncelle.Parameters.AddWithValue("@a5",label8.Text);
            komutGuncelle.Parameters.AddWithValue("@a6",txtmeslek.Text);
            komutGuncelle.Parameters.AddWithValue("@a7",txtid.Text);
            komutGuncelle.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Veri Güncellendi!");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            FrmStatistics fr = new FrmStatistics();
            fr.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            FrmGraphs frGrafik = new FrmGraphs();
            frGrafik.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
