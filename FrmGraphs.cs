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
    public partial class FrmGraphs : Form
    {
        public FrmGraphs()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-U2CN370; Initial Catalog = PersonelVeriTabani; Integrated Security = True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //Grafik 1
            conn.Open();
            SqlCommand komutg1 = new SqlCommand("Select PerSehir,Count(*) from tbl_Personel Group By PerSehir", conn);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            conn.Close();

            //Grafik 2
            conn.Open();
            SqlCommand komutg2 = new SqlCommand("Select PerMeslek,Avg(PerMaas) from tbl_personel group by PerMeslek",conn);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            conn.Close();
        }
    }
}
