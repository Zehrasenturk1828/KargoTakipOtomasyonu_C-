﻿using BAL1;
using BEL;
using DAL;
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

namespace KargoTakipOtomasyonu
{
    public partial class GonderiDurumSorgula : Form
    {
        Bilgiler bilg = new Bilgiler();
        Islemler Islemler = new Islemler();
        vtBaglanti dbBaglanti = new vtBaglanti();


        public GonderiDurumSorgula()
        {
            InitializeComponent();
        }

        private void gondurumsorgula_Click(object sender, EventArgs e)
        {
            dbBaglanti.baglantiac();
            SqlCommand komut = new SqlCommand("Select [Gonderi_kodu],[Gonderi_durum] from [dbo].[Gonderi] where [Gonderi_kodu]="+gonkodu.Text+"",dbBaglanti.baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["Gonderi_kodu"].ToString());
                item.SubItems.Add(oku["Gonderi_durum"].ToString());
                gonderiler.Items.Add(item);
            }
            dbBaglanti.baglantikapa();
            

        }

        private void paneledon_Click(object sender, EventArgs e)
        {
            YetkiliPanel yetkiliPanel = new YetkiliPanel();
            yetkiliPanel.Show();
            this.Hide();
        }
    }
}