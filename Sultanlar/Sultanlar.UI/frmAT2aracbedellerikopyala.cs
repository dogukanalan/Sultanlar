using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmAT2aracbedellerikopyala : Form
    {
        public frmAT2aracbedellerikopyala()
        {
            InitializeComponent();
            AracID = 0;
        }

        public frmAT2aracbedellerikopyala(int aracID)
        {
            InitializeComponent();
            AracID = aracID;
            TipID = AT2_Araclar.GetObject(AracID).intAracTipiID;
            this.Text = "Kira Bedeli Kopyalama                  Tip: " + AT2_AracTipler.GetObject(TipID).strAracTip + "                  Firma: " + AT2_LojistikFirmalar.GetObject(AT2_Araclar.GetObject(AracID).intLojistikFirmaID).strLojistikFirma;
        }

        int AracID;
        int TipID;
        private FixedSizeCache cache;
        System.Collections.ArrayList List = new System.Collections.ArrayList();

        private void frmAT2aracbedellerikopyala_Load(object sender, EventArgs e)
        {
            cache = new FixedSizeCache(512);
            lbAracBedelleri.DrawItem += new DrawItemEventHandler(lbAracBedelleri_DrawItem);
            GetObjects();
        }

        void lbAracBedelleri_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                String text = "";
                if (cache.Contains(e.Index))
                {
                    text = (String)cache[e.Index];
                }
                else
                {
                    text = ((AT2_AracBedeller)List[e.Index]).ToString();
                    cache.Add(e.Index, text);
                }

                lbAracBedelleri.DefaultDrawItem(e, text);
            }
        }

        private void GetObjects()
        {
            if (AracID > 0)
            {
                AT2_AracBedeller.GetObjects(List, false, TipID, AT2_Araclar.GetObject(AracID).intLojistikFirmaID, true, true);
                lbAracBedelleri.Count = List.Count;
                AT2_Araclar.GetObjects(clbAraclar.Items, false, AT2_Araclar.GetObject(AracID).intLojistikFirmaID, TipID, "", true);
            }
            else
            {
                AT2_AracBedeller.GetObjects(List, false, true, true);
                lbAracBedelleri.Count = List.Count;
                AT2_Araclar.GetObjects(clbAraclar.Items, false, true);
            }

            if (AracID != 0)
            {
                for (int i = 0; i < clbAraclar.Items.Count; i++)
                {
                    if (((AT2_Araclar)clbAraclar.Items[i]).pkID == AracID)
                    {
                        clbAraclar.SetItemChecked(i, true);
                        return;
                    }
                }
            }
        }

        private void btnKopyala_Click(object sender, EventArgs e)
        {
            string log = string.Empty;

            //ArrayList secililer1 = new ArrayList();
            //for (int i = 0; i < clbAraclar.Items.Count; i++)
            //    if (clbAraclar.GetItemChecked(i))
            //        secililer.Add(i);

            //AT2_Araclar.GetObjects(clbAraclar.Items, true, true);

            //for (int i = 0; i < secililer.Count; i++)
            //    clbAraclar.SetItemChecked(Convert.ToInt32(secililer[i]), true);

            //for (int j = 0; j < lbAracBedelleri.Items.Count; j++)
            //{
                if (lbAracBedelleri.SelectedIndex > -1 && clbAraclar.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < clbAraclar.CheckedItems.Count; i++)
                    {
                        AT2_AracBedeller ab1 = ((AT2_AracBedeller)List[lbAracBedelleri.SelectedIndex]);

                        if (AT2_AracBedeller.IsExist(((AT2_Araclar)clbAraclar.CheckedItems[i]).pkID, ab1.intBolgeID))
                        {
                            log += ((AT2_Araclar)clbAraclar.CheckedItems[i]).strPlaka + ":\tBu araç için\t" + AT2_Bolgeler.GetObject(ab1.intBolgeID).strBolge + "\tbölgesinde bedel zaten girilmiş.\r\n";
                        }
                        else
                        {
                            AT2_AracBedeller ab = new AT2_AracBedeller(((AT2_Araclar)clbAraclar.CheckedItems[i]).pkID, ab1.intBolgeID, false, ab1.mnBedel, false, ab1.dtBaslangic, ab1.dtBitis);
                            ab.DoInsert();

                            log += ((AT2_Araclar)clbAraclar.CheckedItems[i]).strPlaka + ":\t" + AT2_Araclar.GetObject(ab1.intAracID).strPlaka + "\tnolu aracın\t" + AT2_Bolgeler.GetObject(ab1.intBolgeID).strBolge + "\tbölgesindeki bedeli kopyalandı (" + ab1.mnBedel.ToString("C2") + ").\r\n";
                        }
                    }
                }
            //}

            GetObjects();

            txtLog.Text = log;
        }
    }
}
