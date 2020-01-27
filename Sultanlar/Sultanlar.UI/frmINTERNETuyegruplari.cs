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
    public partial class frmINTERNETuyegruplari : Form
    {
        public frmINTERNETuyegruplari()
        {
            InitializeComponent();
        }

        frmYukleniyor frmyukleniyor;

        private void frmINTERNETuyegruplari_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            GetUyeGruplari();
            GetFiyatTipleri();
            GetOzelKodlar();
            GetGrupKodlar();

            lbUyeGruplari.SelectedIndex = 0;
        }

        private void GetUyeGruplari()
        {
            UyeGruplari.GetObject(lbUyeGruplari.Items, true);
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObject(lbFiyatTipleri.Items, true);
        }

        private void GetOzelKodlar()
        {
            Urunler.GetOzelKodlar(lbOzelKodlar.Items);
        }

        private void GetGrupKodlar()
        {
            Urunler.GetGrupKodlar(lbGrupKodlar.Items);
        }

        private void FiyatTipEsitle()
        {
            GetFiyatTipleri();
            lbFiyatTipleriYetkili.Items.Clear();

            if (lbUyeGruplari.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrubuFiyatTipleri.GetObject(al, ((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, true);

                for (int i = 0; i < lbFiyatTipleri.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((FiyatTipleri)lbFiyatTipleri.Items[i]).NOSU == ((UyeGrubuFiyatTipleri)al[j]).sintFiyatTipiID)
                        {
                            lbFiyatTipleri.Items.RemoveAt(i);
                            arttirma = true;
                            lbFiyatTipleriYetkili.Items.Add((UyeGrubuFiyatTipleri)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void OzelKodEsitle()
        {
            GetOzelKodlar();
            lbOzelKodlarYetkili.Items.Clear();

            if (lbUyeGruplari.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrubuOzelKodlar.GetObject(al, ((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, true);

                for (int i = 0; i < lbOzelKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((OzelKodlar)lbOzelKodlar.Items[i]).OZELKOD == ((UyeGrubuOzelKodlar)al[j]).strOzelKod)
                        {
                            lbOzelKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbOzelKodlarYetkili.Items.Add((UyeGrubuOzelKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void GrupKodEsitle()
        {
            GetGrupKodlar();
            lbGrupKodlarYetkili.Items.Clear();

            if (lbUyeGruplari.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrubuGrupKodlar.GetObject(al, ((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, true);

                for (int i = 0; i < lbGrupKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((GrupKodlar)lbGrupKodlar.Items[i]).GRUPKOD == ((UyeGrubuGrupKodlar)al[j]).strGrupKod)
                        {
                            lbGrupKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbGrupKodlarYetkili.Items.Add((UyeGrubuGrupKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void GetGruptakiUyeler()
        {
            Musteriler.GetObjectByUyeGrupID(lbMusteriler.Items, ((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID);
        }

        private void FiyatTipiYetkiEkle()
        {
            if (lbFiyatTipleri.SelectedIndex > -1)
            {
                UyeGrubuFiyatTipleri ugft = new UyeGrubuFiyatTipleri(((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, ((FiyatTipleri)lbFiyatTipleri.SelectedItem).NOSU);
                ugft.DoInsert();
            }
        }

        private void FiyatTipiYetkiKaldir()
        {
            if (lbFiyatTipleriYetkili.SelectedIndex > -1)
            {
                UyeGrubuFiyatTipleri ugft = (UyeGrubuFiyatTipleri)lbFiyatTipleriYetkili.SelectedItem;
                ugft.DoDelete();
            }
        }

        private void OzelKodYetkiEkle()
        {
            if (lbOzelKodlar.SelectedIndex > -1)
            {
                UyeGrubuOzelKodlar ugok = new UyeGrubuOzelKodlar(((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, ((OzelKodlar)lbOzelKodlar.SelectedItem).OZELKOD);
                ugok.DoInsert();
            }
        }

        private void OzelKodYetkiKaldir()
        {
            if (lbOzelKodlarYetkili.SelectedIndex > -1)
            {
                UyeGrubuOzelKodlar ugok = (UyeGrubuOzelKodlar)lbOzelKodlarYetkili.SelectedItem;
                ugok.DoDelete();
            }
        }

        private void GrupKodYetkiEkle()
        {
            if (lbGrupKodlar.SelectedIndex > -1)
            {
                // once o grupkoda ait butun ozelkod yetkilerini sil:
                ArrayList ozelkodlar = OzelKodlar.GetObjectsByGrupKod(((GrupKodlar)lbGrupKodlar.SelectedItem).GRUPKOD);
                for (int i = 0; i < ozelkodlar.Count; i++)
                {
                    UyeGrubuOzelKodlar ugok = UyeGrubuOzelKodlar.GetObject(((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, ((OzelKodlar)ozelkodlar[i]).OZELKOD);
                    if (ugok.pkID != 0)
                        ugok.DoDelete();
                }

                UyeGrubuGrupKodlar uggk = new UyeGrubuGrupKodlar(((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, ((GrupKodlar)lbGrupKodlar.SelectedItem).GRUPKOD);
                uggk.DoInsert();
                for (int i = 0; i < ozelkodlar.Count; i++)
                {
                    UyeGrubuOzelKodlar ugok = new UyeGrubuOzelKodlar(((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, ((OzelKodlar)ozelkodlar[i]).OZELKOD);
                    ugok.DoInsert();
                }
            }
        }

        private void GrupKodYetkiKaldir()
        {
            if (lbGrupKodlarYetkili.SelectedIndex > -1)
            {
                UyeGrubuGrupKodlar uggk = (UyeGrubuGrupKodlar)lbGrupKodlarYetkili.SelectedItem;
                uggk.DoDelete();

                ArrayList ozelkodlar = OzelKodlar.GetObjectsByGrupKod(uggk.strGrupKod);
                for (int i = 0; i < ozelkodlar.Count; i++)
                {
                    UyeGrubuOzelKodlar ugok = UyeGrubuOzelKodlar.GetObject(((UyeGruplari)lbUyeGruplari.SelectedItem).pkUyeGrupID, ((OzelKodlar)ozelkodlar[i]).OZELKOD);
                    if (ugok.pkID != 0)
                        ugok.DoDelete();
                }
            }
        }

        private void TaksitPlaniDegistir()
        {
            UyeGruplari ug = (UyeGruplari)lbUyeGruplari.SelectedItem;
            ug.blTaksitPlani = cbTaksitPlani.Checked;
            ug.DoUpdate();
        }

        private void lbUyeGruplari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUyeGruplari.SelectedIndex < 0)
                return;

            if (lbUyeGruplari.SelectedIndex > 0)
                groupBox1.Enabled = true;
            else
                groupBox1.Enabled = false;

            cbTaksitPlani.Checked = ((UyeGruplari)lbUyeGruplari.SelectedItem).blTaksitPlani;

            lbUyeGruplari.Enabled = false;
            lbMusteriler.Enabled = false;
            frmyukleniyor = new frmYukleniyor();
            frmyukleniyor.StartPosition = FormStartPosition.CenterScreen;
            frmyukleniyor.Show();
            //frmyukleniyor.Left = this.Left + 196;
            //frmyukleniyor.Top = this.Top + 76;
            //frmyukleniyor.Size = new System.Drawing.Size(this.Width - 24, this.Height - 30);
            System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ThreadStart(Get));
            thr.Start();
        }
        private void Get()
        {
            FiyatTipEsitle();
            OzelKodEsitle();
            GrupKodEsitle();
            GetGruptakiUyeler();
            frmyukleniyor.Dispose();
            lbUyeGruplari.Enabled = true;
            lbMusteriler.Enabled = true;
        }

        private void btnFiyatTipiYetkiEkle_Click(object sender, EventArgs e)
        {
            FiyatTipiYetkiEkle();
            FiyatTipEsitle();
        }

        private void btnFiyatTipiYetkiKaldir_Click(object sender, EventArgs e)
        {
            FiyatTipiYetkiKaldir();
            FiyatTipEsitle();
        }

        private void btnOzelKodYetkiEkle_Click(object sender, EventArgs e)
        {
            OzelKodYetkiEkle();
            OzelKodEsitle();
        }

        private void btnOzelKodYetkiKaldir_Click(object sender, EventArgs e)
        {
            OzelKodYetkiKaldir();
            OzelKodEsitle();
        }

        private void lbFiyatTipleri_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnFiyatTipiYetkiEkle.PerformClick();
        }

        private void lbFiyatTipleriYetkili_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnFiyatTipiYetkiKaldir.PerformClick();
        }

        private void lbOzelKodlar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOzelKodYetkiEkle.PerformClick();
        }

        private void lbOzelKodlarYetkili_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOzelKodYetkiKaldir.PerformClick();
        }

        private void lbGrupKodlar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnGrupKodYetkiEkle.PerformClick();
        }

        private void lbGrupKodlarYetkili_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnGrupKodYetkiKaldir.PerformClick();
        }

        private void btnGrupKodYetkiEkle_Click(object sender, EventArgs e)
        {
            GrupKodYetkiEkle();
            GrupKodEsitle();
            OzelKodEsitle();
        }

        private void btnGrupKodYetkiKaldir_Click(object sender, EventArgs e)
        {
            GrupKodYetkiKaldir();
            GrupKodEsitle();
            OzelKodEsitle();
        }

        private void cbTakistPlani_CheckedChanged(object sender, EventArgs e)
        {
            if (((UyeGruplari)lbUyeGruplari.SelectedItem).blTaksitPlani != cbTaksitPlani.Checked && lbUyeGruplari.SelectedIndex != 0)
                TaksitPlaniDegistir();
        }

        private void btnGrupEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETuyegrubuolustur ugo = new frmINTERNETuyegrubuolustur();
            ugo.ShowDialog();

            GetUyeGruplari();
            GetFiyatTipleri();
            GetOzelKodlar();
            GetGrupKodlar();

            lbUyeGruplari.SelectedIndex = lbUyeGruplari.Items.Count - 1;
        }

        private void lbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUyeGruplari.SelectedIndex == 0 && lbMusteriler.SelectedIndex > -1)
            {
                if (lbMusteriler.SelectedIndex > -1)
                    cbTaksitPlani.Checked = ((Musteriler)lbMusteriler.SelectedItem).blTaksitPlani;

                lbUyeGruplari.Enabled = false;
                lbMusteriler.Enabled = false;
                frmyukleniyor = new frmYukleniyor();
                frmyukleniyor.StartPosition = FormStartPosition.CenterScreen;
                frmyukleniyor.Show();
                //frmyukleniyor.Left = this.Left + 196;
                //frmyukleniyor.Top = this.Top + 76;
                //frmyukleniyor.Size = new System.Drawing.Size(this.Width - 24, this.Height - 30);
                System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ThreadStart(GetUye));
                thr.Start();
            }
        }
        private void GetUye()
        {
            UyeFiyatTipEsitle();
            UyeOzelKodEsitle();
            UyeGrupKodEsitle();
            frmyukleniyor.Dispose();
            lbUyeGruplari.Enabled = true;
            lbMusteriler.Enabled = true;
        }
        #region UyeYetkileri
        private void UyeFiyatTipEsitle()
        {
            GetFiyatTipleri();
            lbFiyatTipleriYetkili.Items.Clear();

            if (lbMusteriler.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeFiyatTipleri.GetObject(al, ((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, true);

                for (int i = 0; i < lbFiyatTipleri.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((FiyatTipleri)lbFiyatTipleri.Items[i]).NOSU == ((UyeFiyatTipleri)al[j]).sintFiyatTipiID)
                        {
                            lbFiyatTipleri.Items.RemoveAt(i);
                            arttirma = true;
                            lbFiyatTipleriYetkili.Items.Add((UyeFiyatTipleri)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void UyeOzelKodEsitle()
        {
            GetOzelKodlar();
            lbOzelKodlarYetkili.Items.Clear();

            if (lbMusteriler.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeOzelKodlar.GetObject(al, ((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, true);

                for (int i = 0; i < lbOzelKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((OzelKodlar)lbOzelKodlar.Items[i]).OZELKOD == ((UyeOzelKodlar)al[j]).strOzelKod)
                        {
                            lbOzelKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbOzelKodlarYetkili.Items.Add((UyeOzelKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }

        private void UyeGrupKodEsitle()
        {
            GetGrupKodlar();
            lbGrupKodlarYetkili.Items.Clear();

            if (lbMusteriler.SelectedIndex > -1)
            {
                ArrayList al = new ArrayList();
                UyeGrupKodlar.GetObject(al, ((Musteriler)lbMusteriler.SelectedItem).pkMusteriID, true);

                for (int i = 0; i < lbGrupKodlar.Items.Count; i++)
                {
                    bool arttirma = false;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (((GrupKodlar)lbGrupKodlar.Items[i]).GRUPKOD == ((UyeGrupKodlar)al[j]).strGrupKod)
                        {
                            lbGrupKodlar.Items.RemoveAt(i);
                            arttirma = true;
                            lbGrupKodlarYetkili.Items.Add((UyeGrupKodlar)al[j]);
                            j = al.Count;
                        }
                    }

                    if (arttirma)
                    {
                        i--;
                    }
                }
            }
        }
        #endregion
    }
}
