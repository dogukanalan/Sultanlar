using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamastoklar : Form
    {
        public frmINTERNETticaripazarlamastoklar()
        {
            InitializeComponent();
        }

        bool Acilis;

        private void frmINTERNETticaripazarlamastoklar_Load(object sender, EventArgs e)
        {
            Acilis = true;
            GetFiyatTipleri();
            comboBox3.SelectedIndex = 7;
            for (int i = 0; i < comboBox1.Items.Count; i++)
                if (comboBox1.Items[i].ToString() == DateTime.Now.Year.ToString())
                    comboBox1.SelectedIndex = i;
            for (int i = 0; i < comboBox2.Items.Count; i++)
                if (comboBox2.Items[i].ToString() == DateTime.Now.Month.ToString())
                    comboBox2.SelectedIndex = i;
            GetFiyatlar();
            Acilis = false;
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObjectAciklamali(comboBox3.Items, true);
        }

        private void GetFiyatlar()
        {
            DataTable dt = new DataTable();
            FiyatlarTP.GetObjects(dt, ((FiyatTipleri)comboBox3.SelectedItem).NOSU, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));
            gridControl1.DataSource = dt;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Acilis)
                GetFiyatlar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Şu andaki liste fiyatları " + comboBox1.SelectedItem.ToString() + " - " + comboBox2.SelectedItem.ToString() + " döneminin üzerine yazılacak, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                FiyatlarTP.Update(((FiyatTipleri)comboBox3.SelectedItem).NOSU, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));

                MessageBox.Show("Fiyatlar seçili dönem için güncellenmiştir.", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFiyatlar();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Şu andaki liste fiyatları " + comboBox1.SelectedItem.ToString() + " - " + comboBox2.SelectedItem.ToString() + " döneminin üzerine yazılacak, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                FiyatTipleri.GetObjects(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["NOSU"].ToString().StartsWith("5") && dt.Rows[i]["NOSU"].ToString().Length == 3)
                    {
                        FiyatlarTP.Update(Convert.ToInt16(dt.Rows[i]["NOSU"].ToString()), Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));
                    }
                }

                FiyatlarTP.Update((short)1, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));
                FiyatlarTP.Update((short)7, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));
                FiyatlarTP.Update((short)20, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));
                FiyatlarTP.Update((short)22, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));
                FiyatlarTP.Update((short)25, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Convert.ToInt32(comboBox2.SelectedItem.ToString()));

                MessageBox.Show("Fiyatlar seçili dönem için güncellenmiştir.", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFiyatlar();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmINTERNETstoklartekligiris frm = new frmINTERNETstoklartekligiris();
            frm.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel dosyaları (*.xlsx)|*.xlsx;|Bütün Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridControl1.ExportToXlsx(sfd.FileName, new DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, true));
        }
    }
}
