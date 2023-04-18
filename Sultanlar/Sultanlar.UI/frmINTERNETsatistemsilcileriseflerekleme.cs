using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETsatistemsilcileriseflerekleme : Form
    {
        public frmINTERNETsatistemsilcileriseflerekleme()
        {
            InitializeComponent();

            ustslsref = 0;
            Esitle();
        }

        public frmINTERNETsatistemsilcileriseflerekleme(int UstSLSREF)
        {
            InitializeComponent();

            ustslsref = UstSLSREF;
            altrefler = new ArrayList();
            EsitleAltlar();
        }

        int ustslsref;
        ArrayList altrefler;

        private void frmINTERNETsatistemsilcileriseflerekleme_Load(object sender, EventArgs e)
        {

        }

        private void GetSatisTemsilcileri()
        {
            SatisTemsilcileri.GetObjectsAll(lb1.Items, true);
        }

        private void Esitle()
        {
            GetSatisTemsilcileri();

            SatisTemsilcileriSefler.GetUstler(lb2.Items, true);

            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < lb2.Items.Count; i++)
            {
                for (int j = 0; j < lb1.Items.Count; j++)
                {
                    if (((SatisTemsilcileri)lb1.Items[j]).SLSREF == ((SatisTemsilcileriSefler)lb2.Items[i]).ustSLSREF)
                    {
                        silinecekler.Add(lb1.Items[j]);
                        break;
                    }
                }
            }

            for (int i = 0; i < silinecekler.Count; i++)
                lb1.Items.Remove(silinecekler[i]);
        }

        private void EsitleAltlar()
        {
            GetSatisTemsilcileri();

            lb2.Items.Clear();
            ArrayList altlar = SatisTemsilcileriSefler.GetAltlar(ustslsref);
            for (int i = 0; i < altlar.Count; i++)
                lb2.Items.Add(altlar[i].ToString());

            altrefler = SatisTemsilcileriSefler.GetAltRefler(ustslsref);

            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < altrefler.Count; i++)
            {
                for (int j = 0; j < lb1.Items.Count; j++)
                {
                    if (((SatisTemsilcileri)lb1.Items[j]).SLSREF == Convert.ToInt32(altrefler[i]))
                    {
                        silinecekler.Add(lb1.Items[j]);
                        break;
                    }
                }
            }

            for (int i = 0; i < silinecekler.Count; i++)
                lb1.Items.Remove(silinecekler[i]);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (lb1.SelectedIndex == -1)
                return;

            if (ustslsref == 0)
            {
                SatisTemsilcileriSefler sts = new SatisTemsilcileriSefler(((SatisTemsilcileri)lb1.SelectedItem).SLSREF, ((SatisTemsilcileri)lb1.SelectedItem).SLSREF);
                sts.DoInsert();

                Esitle();
            }
            else
            {
                SatisTemsilcileriSefler sts = new SatisTemsilcileriSefler(ustslsref, ((SatisTemsilcileri)lb1.SelectedItem).SLSREF);
                sts.DoInsert();

                EsitleAltlar();
            }
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            if (lb2.SelectedIndex == -1)
                return;

            if (ustslsref == 0)
            {
                SatisTemsilcileriSefler.DoDeleteAltlarla(((SatisTemsilcileriSefler)lb2.SelectedItem).ustSLSREF);

                Esitle();
            }
            else
            {
                SatisTemsilcileriSefler sts = new SatisTemsilcileriSefler(ustslsref, Convert.ToInt32(altrefler[lb2.SelectedIndex]));
                sts.DoDelete();

                EsitleAltlar();
            }
        }

        private void lb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEkle.PerformClick();
        }

        private void lb2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnCikar.PerformClick();
        }

        private void btnTumunuEkle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lb1.Items.Count; i++)
            {
                SatisTemsilcileriSefler sts = new SatisTemsilcileriSefler(ustslsref, ((SatisTemsilcileri)lb1.Items[i]).SLSREF);
                sts.DoInsert();

                //lb1.SelectedIndex = 0;
                //btnEkle.PerformClick();
            }

            EsitleAltlar();
        }
    }
}
