using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_kayit
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-U2CN370; Initial Catalog = PersonelVeriTabani; Integrated Security = True");
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel
            conn.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) from tbl_personel",conn);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }
            conn.Close();

            //Evli Personel
            conn.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from tbl_Personel where PerDurum=1",conn);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPersonel.Text = dr2[0].ToString();
            }
            conn.Close();

            //Bekar Personel

            conn.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) from tbl_Personel where Perdurum=0", conn);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }
            conn.Close();

            //Toplam Şehir Sayısı
            conn.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(PerSehir)) from tbl_personel",conn);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            conn.Close();

            //Toplam Maaş
            conn.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from tbl_personel",conn);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
            }
            conn.Close();

            //Ortalama Maaş
            conn.Open();
            SqlCommand komut6 = new SqlCommand("select avg(PerMaas) from tbl_personel", conn);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtalamMaas.Text = dr6[0].ToString();
            }
            conn.Close();
        }
    }
}
