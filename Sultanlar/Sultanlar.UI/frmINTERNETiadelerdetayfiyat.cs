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
    public partial class frmINTERNETiadelerdetayfiyat : Form
    {
        public frmINTERNETiadelerdetayfiyat(long iadedetayid, int gmref, int smref, int itemref, int adet, DateTime dt1, DateTime dt2, bool sontarihoto)
        {
            InitializeComponent();
            GMREF = gmref;
            SMREF = smref;
            ITEMREF = itemref;
            Adet = adet;
            IadeDetayID = iadedetayid;
            Dt1 = dt1;
            Dt2 = dt2;
            Sontarihoto = sontarihoto;
        }

        DateTime Dt1;
        DateTime Dt2;
        long IadeDetayID;
        int GMREF;
        int SMREF;
        int ITEMREF;
        int Adet;
        ArrayList IlkIadeAdetler;
        bool Sontarihoto;

        private void frmINTERNETiadelerdetayfiyat_Load(object sender, EventArgs e)
        {
            IlkIadeAdetler = new ArrayList();
            GetObjects(true);
            lblSecilecek.Text = Adet.ToString();
            lblKalan.Text = Adet.ToString();
            lblTedarikci.Text = OzelKodlar.GetObjectByOzelKod(Urunler.GetProductOzelKod(ITEMREF, true));
        }

        private void GetObjects(bool IlkAcilis)
        {
            DataTable dt = new DataTable();
            if (GMREF != 0)
                IadeFiyat.GetObjectsByGMREFITEMREF(dt, GMREF, ITEMREF, Dt1, Dt2);
            else
                IadeFiyat.GetObjectsBySMREFITEMREF(dt, SMREF, ITEMREF, Dt1, Dt2);
            dataGridView1.DataSource = dt;

            if (IlkAcilis)
            {
                IlkIadeAdetler.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArrayList deger = new ArrayList();
                    deger.Add(i);
                    deger.Add(Convert.ToInt32(dt.Rows[i]["ADIADE"].ToString()));
                    IlkIadeAdetler.Add(deger);
                }
            }

            if (Sontarihoto)
                btnYukaridan.PerformClick();
        }

        private void btnYukaridan_Click(object sender, EventArgs e)
        {
            if (!Sontarihoto)
                GetObjects(false);

            int kalanadet = Adet;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int ilkadfark = Convert.ToInt32(dataGridView1.Rows[i].Cells["clADFARK"].Value);
                int ilkadiade = Convert.ToInt32(dataGridView1.Rows[i].Cells["clADIADE"].Value);

                dataGridView1.Rows[i].Cells["clCheck"].Value = true;

                if (kalanadet == ilkadfark)
                {
                    dataGridView1.Rows[i].Cells["clADFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clADIADE"].Value = dataGridView1.Rows[i].Cells["clADTOP"].Value;
                    kalanadet = 0;
                    break;
                }
                else if (kalanadet > ilkadfark)
                {
                    dataGridView1.Rows[i].Cells["clADFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clADIADE"].Value = dataGridView1.Rows[i].Cells["clADTOP"].Value;
                    kalanadet = kalanadet - ilkadfark;
                }
                else if (kalanadet < ilkadfark)
                {
                    dataGridView1.Rows[i].Cells["clADFARK"].Value = ilkadfark - kalanadet;
                    dataGridView1.Rows[i].Cells["clADIADE"].Value = ilkadiade + kalanadet;
                    kalanadet = 0;
                    break;
                }
            }

            lblSecilen.Text = (kalanadet < 0) ? lblSecilecek.Text : (Convert.ToInt32(lblSecilecek.Text) - kalanadet).ToString();

            if (Sontarihoto)
                btnOnayla.PerformClick();
        }

        private void btnAsagidan_Click(object sender, EventArgs e)
        {
            GetObjects(false);

            int kalanadet = Adet;

            for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
            {
                int ilkadfark = Convert.ToInt32(dataGridView1.Rows[i].Cells["clADFARK"].Value);
                int ilkadiade = Convert.ToInt32(dataGridView1.Rows[i].Cells["clADIADE"].Value);

                dataGridView1.Rows[i].Cells["clCheck"].Value = true;

                if (kalanadet == ilkadfark)
                {
                    dataGridView1.Rows[i].Cells["clADFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clADIADE"].Value = dataGridView1.Rows[i].Cells["clADTOP"].Value;
                    kalanadet = 0;
                    break;
                }
                else if (kalanadet > ilkadfark)
                {
                    dataGridView1.Rows[i].Cells["clADFARK"].Value = 0;
                    dataGridView1.Rows[i].Cells["clADIADE"].Value = dataGridView1.Rows[i].Cells["clADTOP"].Value;
                    kalanadet = kalanadet - ilkadfark;
                }
                else if (kalanadet < ilkadfark)
                {
                    dataGridView1.Rows[i].Cells["clADFARK"].Value = ilkadfark - kalanadet;
                    dataGridView1.Rows[i].Cells["clADIADE"].Value = ilkadiade + kalanadet;
                    kalanadet = 0;
                    break;
                }
            }

            lblSecilen.Text = (kalanadet < 0) ? lblSecilecek.Text : (Convert.ToInt32(lblSecilecek.Text) - kalanadet).ToString();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            string kolon = string.Empty;
            if (rbISK.Checked)
                kolon = "clADID";
            else if (rbISKBDL.Checked)
                kolon = "clADIBD";
            else if (rbISKBDLPR.Checked)
                kolon = "clADIBPD";

            int kacsatir = 0;
            int kacadet = 0;

            decimal toplam = 0;
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[j].Cells["clCheck"].Value))
                {
                    kacsatir++;
                    int adet = Convert.ToInt32(dataGridView1.Rows[j].Cells["clADIADE"].Value) - Convert.ToInt32(((ArrayList)IlkIadeAdetler[j])[1]);
                    kacadet += adet;
                    toplam += Convert.ToDecimal(dataGridView1.Rows[j].Cells[kolon].Value) * adet;
                }
            }



            decimal ortalama = 0;
            if (kacsatir > 0)
                ortalama = toplam / kacadet;




            IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(IadeDetayID);

            if (lblKalan.Text == "0")
            {
                if (Sontarihoto || MessageBox.Show("Ürün için oluşturulan fiyat: " + ortalama.ToString("C2") + "\r\n\r\nDevam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AdetEkle();

                    id.mnFiyat = Convert.ToDecimal(ortalama.ToString("N2"));
                    id.DoUpdate();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("İade adediyle girilen adet eşleşmiyor. Bu ürün için fiyatlandırma yapılamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

                //if (MessageBox.Show("Ürün için oluşturulan fiyat: " + ortalama.ToString("C2") + "\r\n\r\nİade adediyle girilen adet eşleşmiyor. Yine de devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    AdetEkle();

                //    id.mnFiyat = ortalama;
                //    id.DoUpdate();
                //}
                //else
                //{
                //    return;
                //}
            }

            IadelerDetayFiy idf = new IadelerDetayFiy(IadeDetayID, ortalama * id.intMiktar,
                0, DateTime.Now, frmAna.KAdi.ToUpper(), DateTime.MinValue, string.Empty);
            idf.DoInsert();

            this.Close();
        }

        private void AdetEkle()
        {
            string kolon = string.Empty;
            if (rbISK.Checked)
                kolon = "AD ID";
            else if (rbISKBDL.Checked)
                kolon = "AD IBD";
            else if (rbISKBDLPR.Checked)
                kolon = "AD IBPD";


            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[j].Cells["clCheck"].Value))
                {
                    int ilkiade = -1;
                    for (int i = 0; i < IlkIadeAdetler.Count; i++)
                    {
                        ArrayList deger = (ArrayList)IlkIadeAdetler[i];
                        if (deger[0].ToString() == j.ToString())
                        {
                            ilkiade = Convert.ToInt32(deger[1]);
                            break;
                        }
                    }

                    decimal fiyat = 0;
                    if (rbISK.Checked)
                        fiyat = Convert.ToDecimal(dataGridView1.Rows[j].Cells["clADID"].Value);
                    else if (rbISKBDL.Checked)
                        fiyat = Convert.ToDecimal(dataGridView1.Rows[j].Cells["clADIBD"].Value);
                    else if (rbISKBDLPR.Checked)
                        fiyat = Convert.ToDecimal(dataGridView1.Rows[j].Cells["clADIBPD"].Value);

                    if (ilkiade == 0)
                        IadeFiyatAdet.DoInsert(dataGridView1.Rows[j].Cells["clSTRREF"].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[j].Cells["clITEMREF"].Value), Convert.ToInt32(dataGridView1.Rows[j].Cells["clADIADE"].Value), true, IadeDetayID, kolon, fiyat);
                    else if (ilkiade > 0)
                        IadeFiyatAdet.DoUpdate(dataGridView1.Rows[j].Cells["clSTRREF"].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[j].Cells["clADIADE"].Value), true, IadeDetayID, kolon, fiyat);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValueType == typeof(bool))
            {
                int kalanadet = Convert.ToInt32(lblKalan.Text);

                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue))
                {
                    int ilkadfark = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clADFARK"].Value);
                    int ilkadiade = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clADIADE"].Value);

                    if (kalanadet == ilkadfark)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clADFARK"].Value = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["clADIADE"].Value = dataGridView1.Rows[e.RowIndex].Cells["clADTOP"].Value;
                        kalanadet = 0;
                    }
                    else if (kalanadet > ilkadfark)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clADFARK"].Value = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["clADIADE"].Value = dataGridView1.Rows[e.RowIndex].Cells["clADTOP"].Value;
                        kalanadet = kalanadet - ilkadfark;
                    }
                    else if (kalanadet < ilkadfark)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clADFARK"].Value = ilkadfark - kalanadet;
                        dataGridView1.Rows[e.RowIndex].Cells["clADIADE"].Value = ilkadiade + kalanadet;
                        kalanadet = 0;
                    }

                    lblSecilen.Text = (kalanadet < 0) ? lblSecilecek.Text : (Convert.ToInt32(lblSecilecek.Text) - kalanadet).ToString();
                }
                else
                {
                    int adettop = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clADTOP"].Value);
                    int iadeedilmisadet = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clADIADE"].Value);

                    int ilkiade = 0;
                    for (int i = 0; i < IlkIadeAdetler.Count; i++)
                    {
                        ArrayList deger = (ArrayList)IlkIadeAdetler[i];
                        if (deger[0].ToString() == e.RowIndex.ToString())
                        {
                            ilkiade = Convert.ToInt32(deger[1]);
                            break;
                        }
                    }

                    dataGridView1.Rows[e.RowIndex].Cells["clADIADE"].Value = ilkiade;
                    dataGridView1.Rows[e.RowIndex].Cells["clADFARK"].Value = adettop - ilkiade;

                    lblSecilen.Text = (Convert.ToInt32(lblSecilen.Text) - (iadeedilmisadet - ilkiade)).ToString();
                }
            }
        }

        private void lblSecilen_TextChanged(object sender, EventArgs e)
        {
            lblKalan.Text = (Convert.ToInt32(lblSecilecek.Text) - Convert.ToInt32(lblSecilen.Text)).ToString();
        }

        private void lblKalan_TextChanged(object sender, EventArgs e)
        {
            if (lblKalan.Text == "0")
                dataGridView1.ReadOnly = true;
        }

        private void btnSecimiSifirla_Click(object sender, EventArgs e)
        {
            GetObjects(false);
            dataGridView1.ReadOnly = false;

            lblSecilecek.Text = Adet.ToString();
            lblSecilen.Text = "0";
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

            //lblSecilecek.Text = Adet.ToString();
            //lblSecilen.Text = "0";
        }
    }
}
