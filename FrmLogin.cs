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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source = ServerName; Initial Catalog = DatabaseName; Integrated Security = True");
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_yonetici where kullaniciAd=@p1 and sifre=@p2",conn);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHomePage frmAna = new FrmHomePage();
                frmAna.Show();
                this.Hide();
            }else { MessageBox.Show("Kullanıcı adı veya şifre hatalı!"); }
            conn.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
