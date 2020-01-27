using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETiadelerdetayhizmet : Form
    {
        public frmINTERNETiadelerdetayhizmet(long iadedetayid, int gmref, int smref, string ozelkod, decimal tutar, DateTime dt1, DateTime dt2,
            double urunsatis, double genelsatis, double yuzde, double hizmetgenel, double hizmet, double hizmetbirim, double hizmettop)
        {
            InitializeComponent();

            IadeDetayID = iadedetayid;
            GMREF = gmref;
            SMREF = smref;
            OZELKOD = ozelkod;
            Tutar = tutar;
            Dt1 = dt1;
            Dt2 = dt2;

            SonradanHizmet = false;

            lblUrunSatis.Text = urunsatis.ToString("N2");
            lblGenelSatis.Text = genelsatis.ToString("N2");
            lblYuzde.Text = yuzde.ToString("N2");
            lblHizmetGenel.Text = hizmetgenel.ToString("N2");
            lblHizmet.Text = hizmet.ToString("N2");
            lblSatisIadeOran.Text = hizmetbirim.ToString("N2");
            lblHizmetTop.Text = hizmettop.ToString("N2");
            IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(IadeDetayID);
            lblSatisIadeOran.Text = (Convert.ToDecimal(urunsatis) / (id.mnFiyat * id.intMiktar)).ToString("N2");
        }

        public frmINTERNETiadelerdetayhizmet(int gmref, int smref, string ozelkod, DateTime dt1, DateTime dt2, double hizmettop)
        {
            InitializeComponent();

            IadeDetayID = 0;
            GMREF = gmref;
            SMREF = smref;
            OZELKOD = ozelkod;
            Tutar = Convert.ToDecimal(hizmettop);
            Dt1 = dt1;
            Dt2 = dt2;

            SonradanHizmet = true;

            lblHizmetTop.Text = hizmettop.ToString("N2");
            pnlBilgiler.Visible = false;
        }

        DateTime Dt1;
        DateTime Dt2;
        long IadeDetayID;
        int GMREF;
        int SMREF;
        string OZELKOD;
        decimal Tutar;

        bool SonradanHizmet;

        ArrayList IlkHizmetTutarlar;

        private void frmINTERNETiadelerdetayhizmet_Load(object sender, EventArgs e)
        {
            IlkHizmetTutarlar = new ArrayList();

            if (SonradanHizmet)
                GetObjectsSonradan(true);
            else
                GetObjects(true);

            lblSecilecek.Text = Tutar.ToString("N2");
            lblSecilen.Text = 0.ToString("N2");
            lblKalan.Text = Tutar.ToString("N2");
            lblTedarikci.Text = OzelKodlar.GetObjectByOzelKod(OZELKOD);
        }

        private void GetObjects(bool IlkAcilis)
        {
            DataTable dt = new DataTable();
            if (GMREF != 0)
                IadeHizmet.GetObjectsByGMREF(dt, GMREF, OZELKOD, Dt1, Dt2);
            else
                IadeHizmet.GetObjectsBySMREF(dt, SMREF, OZELKOD, Dt1, Dt2);
            dataGridView1.DataSource = dt;

            if (IlkAcilis)
            {
                IlkHizmetTutarlar.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArrayList deger = new ArrayList();
                    deger.Add(i);
                    deger.Add(Convert.ToDecimal(dt.Rows[i]["TUTIADE"]));
                    IlkHizmetTutarlar.Add(deger);
                }
            }
        }

        private void GetObjectsSonradan(bool IlkAcilis)
        {
            DataTable dt = new DataTable();
            if (GMREF != 0)
                IadeHizmet.GetObjectsByGMREFOZELKODforSonradanHizmet(dt, GMREF, OZELKOD, Dt1, Dt2);
            else
                IadeHizmet.GetObjectsBySMREFOZELKODforSonradanHizmet(dt, SMREF, OZELKOD, Dt1, Dt2);
            dataGridView1.DataSource = dt;

            if (IlkAcilis)
            {
                IlkHizmetTutarlar.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArrayList deger = new ArrayList();
                    deger.Add(i);
                    deger.Add(Convert.ToDecimal(dt.Rows[i]["TUTIADE"]));
                    IlkHizmetTutarlar.Add(deger);
                }
            }
        }

        private void btnYukaridan_Click(object sender, EventArgs e)
        {
            if (SonradanHizmet)
                GetObjectsSonradan(false);
            else
                GetObjects(false);

            decimal kalantutar = Tutar;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal ilktutfark = Convert.ToDecimal(dataGridView1.Rows[i].Cells["clTUTFARK"].Value);
                decimal ilktutiade = Convert.ToDecimal(dataGridView1.Rows[i].Cells["clTUTIADE"].Value);

                dataGridView1.Rows[i].Cells["clCheck"].Value = true;

                if (kalantutar == ilktutfark)
                {
                    dataGridView1.Rows[i].Cells["clTUTFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clTUTIADE"].Value = dataGridView1.Rows[i].Cells["clNETKDV"].Value;
                    kalantutar = 0;
                    break;
                }
                else if (kalantutar > ilktutfark)
                {
                    dataGridView1.Rows[i].Cells["clTUTFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clTUTIADE"].Value = dataGridView1.Rows[i].Cells["clNETKDV"].Value;
                    kalantutar = kalantutar - ilktutfark;
                }
                else if (kalantutar < ilktutfark)
                {
                    dataGridView1.Rows[i].Cells["clTUTFARK"].Value = ilktutfark - kalantutar;
                    dataGridView1.Rows[i].Cells["clTUTIADE"].Value = ilktutiade + kalantutar;
                    kalantutar = 0;
                    break;
                }
            }

            lblSecilen.Text = (kalantutar < 0) ? lblSecilecek.Text : (Convert.ToDecimal(lblSecilecek.Text) - kalantutar).ToString("N2");
        }

        private void btnAsagidan_Click(object sender, EventArgs e)
        {
            if (SonradanHizmet)
                GetObjectsSonradan(false);
            else
                GetObjects(false);

            decimal kalantutar = Tutar;

            for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
            {
                decimal ilktutfark = Convert.ToDecimal(dataGridView1.Rows[i].Cells["clTUTFARK"].Value);
                decimal ilktutiade = Convert.ToDecimal(dataGridView1.Rows[i].Cells["clTUTIADE"].Value);

                dataGridView1.Rows[i].Cells["clCheck"].Value = true;

                if (kalantutar == ilktutfark)
                {
                    dataGridView1.Rows[i].Cells["clTUTFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clTUTIADE"].Value = dataGridView1.Rows[i].Cells["clNETKDV"].Value;
                    kalantutar = 0;
                    break;
                }
                else if (kalantutar > ilktutfark)
                {
                    dataGridView1.Rows[i].Cells["clTUTFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clTUTIADE"].Value = dataGridView1.Rows[i].Cells["clNETKDV"].Value;
                    kalantutar = kalantutar - ilktutfark;
                }
                else if (kalantutar < ilktutfark)
                {
                    dataGridView1.Rows[i].Cells["clTUTFARK"].Value = ilktutfark - kalantutar;
                    dataGridView1.Rows[i].Cells["clTUTIADE"].Value = ilktutiade + kalantutar;
                    kalantutar = 0;
                    break;
                }
            }

            lblSecilen.Text = (kalantutar < 0) ? lblSecilecek.Text : (Convert.ToDecimal(lblSecilecek.Text) - kalantutar).ToString("N2");
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblKalan.Text) == 0)
            {
                if (MessageBox.Show("Devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    TutarEkle();
                else
                    return;
            }
            else
            {
                if (MessageBox.Show("Hizmet tutarıyla seçilen tutarlar toplamı eşleşmiyor. Yine de devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    TutarEkle();
                else
                    return;
            }

            if (!SonradanHizmet)
            {
                IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(IadeDetayID);
                idf.dtHizmetTarihi = DateTime.Now;
                idf.strHizmetleyen = frmAna.KAdi.ToUpper();
                idf.DoUpdate();
            }

            this.Close();
        }

        private void TutarEkle()
        {
            //decimal hizmettoplam = 0;
            //for (int j = 0; j < dataGridView1.Rows.Count; j++)
            //{
            //    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells["clCheck"].Value))
            //    {
            //        toplam += Convert.ToDecimal(dataGridView1.Rows[j].Cells["clTUTIADE"].Value) - Convert.ToDecimal(IlkHizmetTutarlar[j]);
            //    }
            //}

            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[j].Cells["clCheck"].Value))
                {
                    //hizmettoplam += Convert.ToDecimal(dataGridView1.Rows[j].Cells["clTUTIADE"].Value) - Convert.ToDecimal(IlkHizmetTutarlar[j]);

                    decimal ilktutar = -1;
                    for (int i = 0; i < IlkHizmetTutarlar.Count; i++)
                    {
                        ArrayList deger = (ArrayList)IlkHizmetTutarlar[i];
                        if (deger[0].ToString() == j.ToString())
                        {
                            ilktutar = Convert.ToDecimal(deger[1]);
                            break;
                        }
                    }

                    if (ilktutar == 0)
                        IadeHizmetTutar.DoInsert(dataGridView1.Rows[j].Cells["clSTRREF"].Value.ToString(), Convert.ToDecimal(dataGridView1.Rows[j].Cells["clTUTIADE"].Value), IadeDetayID, GMREF, OZELKOD);
                    else if (ilktutar > 0)
                        IadeHizmetTutar.DoUpdate(dataGridView1.Rows[j].Cells["clSTRREF"].Value.ToString(), Convert.ToDecimal(dataGridView1.Rows[j].Cells["clTUTIADE"].Value), IadeDetayID);
                }
            }

            if (!SonradanHizmet)
            {
                IadelerDetayFiy idf = IadelerDetayFiy.GetObjectByIadelerDetayID(IadeDetayID);
                idf.mnHizmetToplam = Convert.ToDecimal(lblSecilen.Text);
                idf.DoUpdate();

                IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(IadeDetayID);
                id.mnFiyat = (idf.mnIadeToplam - idf.mnHizmetToplam) / id.intMiktar;
                id.DoUpdate();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValueType == typeof(bool))
            {
                decimal kalantutar = Convert.ToDecimal(lblKalan.Text);

                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue))
                {
                    decimal ilktutfark = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["clTUTFARK"].Value);
                    decimal ilktutiade = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["clTUTIADE"].Value);

                    if (kalantutar == ilktutfark)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clTUTFARK"].Value = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["clTUTIADE"].Value = dataGridView1.Rows[e.RowIndex].Cells["clNETKDV"].Value;
                        kalantutar = 0;
                    }
                    else if (kalantutar > ilktutfark)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clTUTFARK"].Value = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["clTUTIADE"].Value = dataGridView1.Rows[e.RowIndex].Cells["clNETKDV"].Value;
                        kalantutar = kalantutar - ilktutfark;
                    }
                    else if (kalantutar < ilktutfark)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clTUTFARK"].Value = ilktutfark - kalantutar;
                        dataGridView1.Rows[e.RowIndex].Cells["clTUTIADE"].Value = ilktutiade + kalantutar;
                        kalantutar = 0;
                    }

                    lblSecilen.Text = (kalantutar < 0) ? lblSecilecek.Text : (Convert.ToDecimal(lblSecilecek.Text) - kalantutar).ToString();
                }
                else
                {
                    decimal tutartop = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["clNETKDV"].Value);
                    decimal iadeedilmistutar = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["clTUTIADE"].Value);

                    decimal ilktutar = 0;
                    for (int i = 0; i < IlkHizmetTutarlar.Count; i++)
                    {
                        ArrayList deger = (ArrayList)IlkHizmetTutarlar[i];
                        if (deger[0].ToString() == e.RowIndex.ToString())
                        {
                            ilktutar = Convert.ToDecimal(deger[1]);
                            break;
                        }
                    }

                    dataGridView1.Rows[e.RowIndex].Cells["clTUTIADE"].Value = ilktutar;
                    dataGridView1.Rows[e.RowIndex].Cells["clTUTFARK"].Value = tutartop - ilktutar;

                    lblSecilen.Text = (Convert.ToDecimal(lblSecilen.Text) - (iadeedilmistutar - ilktutar)).ToString("N2");
                }
            }
        }

        private void lblSecilen_TextChanged(object sender, EventArgs e)
        {
            lblKalan.Text = (Convert.ToDecimal(lblSecilecek.Text) - Convert.ToDecimal(lblSecilen.Text)).ToString("N2");
        }

        private void lblKalan_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblKalan.Text) == 0)
                dataGridView1.ReadOnly = true;
        }

        private void btnSecimiSifirla_Click(object sender, EventArgs e)
        {
            if (SonradanHizmet)
                GetObjectsSonradan(false);
            else
                GetObjects(false);

            dataGridView1.ReadOnly = false;

            lblSecilecek.Text = Tutar.ToString("N2");
            lblSecilen.Text = 0.ToString("N2");
        }

        private void cbAnaSube_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbAnaSube.Checked)
            //{
            //    GMREF = CariHesaplar.GetGMREFBySMREF(SMREF);
            //}
            //else
            //{
            //    GMREF = 0;
            //}

            //GetObjects(true);
            //dataGridView1.ReadOnly = false;

            //lblSecilecek.Text = Tutar.ToString("N2");
            //lblSecilen.Text = 0.ToString("N2");
        }
    }
}
