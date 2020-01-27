using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Xml;

namespace Sultanlar.UI
{
    public partial class frmDeneme : Form
    {
        public frmDeneme()
        {
            InitializeComponent();
        }

        private void frmDeneme_Load(object sender, EventArgs e)
        {
            //Deneme();
            //gridView1.Columns[0].GroupIndex = 0;
            //gridView1.Columns[1].GroupIndex = 1;
            //gridView1.Columns[2].GroupIndex = 2;
            //((DevExpress.XtraGrid.GridGroupSummaryItem)gridView1.GroupSummary[0]).ShowInGroupColumnFooter = gridView1.Columns["Hedef"];
            //((DevExpress.XtraGrid.GridGroupSummaryItem)gridView1.GroupSummary[1]).ShowInGroupColumnFooter = gridView1.Columns["Bekleyen"];
            //((DevExpress.XtraGrid.GridGroupSummaryItem)gridView1.GroupSummary[2]).ShowInGroupColumnFooter = gridView1.Columns["Satış"];

            //XDocument docum = XDocument.Load("http://95.0.47.130/SulWCF/General.svc/web/xml/komsu/GetProducts/?kullanici=komsu&sifre=100152763");
            //XmlDocument docu = new XmlDocument();
            //docu.Load(docum.CreateReader());

            //XmlNodeList xmlnod1 = docu.GetElementsByTagName("Kod");
            //XmlNodeList xmlnod2 = docu.GetElementsByTagName("Baslik");
            //XmlNodeList xmlnod3 = docu.GetElementsByTagName("Fiyat");

            //for (int i = 0; i < xmlnod1.Count; i++)
            //    MessageBox.Show(xmlnod1[i].InnerText);
        }

        public void Deneme()
        {
            SqlConnection conn = new SqlConnection("Server=10.1.1.14; Database=KurumsalWebSAP; User Id=rapor; Password=rapor; Trusted_Connection=False;");
            SqlDataAdapter da = new SqlDataAdapter("SELECT [SAT TEM] AS Satıcı,KATEGORI AS Kategori,UPPER(PRIM_GRUBU) AS [Prim Grubu],sum(HEDEF) AS Hedef,sum(SATIŞ) AS Satış,sum(BEKLEYEN) AS Bekleyen FROM (SELECT [SAT TEM],(SELECT PG_B_Z_ACIKLAMA FROM SAP_PRM_GRP WHERE PG_B_Z = [Web-Hedef-PrimGrubu].PRIMB) AS PRIM_GRUBU,dbo.YeniBolum(PRIMB) AS KATEGORI,sum([HEDEF]) AS HEDEF,0 AS SATIŞ,0 AS BEKLEYEN FROM [Web-Hedef-PrimGrubu] INNER JOIN [Web-SatisTemsilcileri] ON [Web-Hedef-PrimGrubu].SLSREF = [Web-SatisTemsilcileri].SLSMANREF WHERE YIL = 2017 AND [AY] = MONTH(getdate()) AND SMREF = 0 GROUP BY SLSREF,[SAT TEM],PRIMB UNION ALL SELECT [Web-SatisTemsilcileri].[SAT TEM],(SELECT PG_B_Z_ACIKLAMA FROM SAP_PRM_GRP WHERE PG_B_Z = [vw_Web-Satis-Rapor-1].PG_B_Z) AS PRIM_GRUBU,dbo.YeniBolum(PG_B_Z) AS KATEGORI,0 AS HEDEF,0 AS BEKLEYEN,sum(KOLIT) AS SATIŞ FROM [vw_Web-Satis-Rapor-1] INNER JOIN [Web-SatisTemsilcileri] ON [vw_Web-Satis-Rapor-1].SIPALN_KOD = [Web-SatisTemsilcileri].SLSMANREF WHERE YIL = 2017 AND AY = MONTH(getdate()) AND PG_B_Z > 11 AND SIPALN_KOD IN (SELECT DISTINCT SLSREF FROM [Web-Hedef] WHERE YIL = [vw_Web-Satis-Rapor-1].YIL AND AY = [vw_Web-Satis-Rapor-1].AY) GROUP BY [Web-SatisTemsilcileri].[SAT TEM],PG_B_Z UNION ALL SELECT [SAT TEM],(SELECT PG_B_Z_ACIKLAMA FROM SAP_PRM_GRP WHERE PG_B_Z = vw_Web_Hedef_Bekleyen_3.PRIMB) AS PRIM_GRUBU,dbo.YeniBolum(PRIMB) AS KATEGORI,0 AS HEDEF,sum(KOLI) AS BEKLEYEN,0 AS SATIŞ FROM vw_Web_Hedef_Bekleyen_3 INNER JOIN [Web-SatisTemsilcileri] ON vw_Web_Hedef_Bekleyen_3.SIPALN_KOD = [Web-SatisTemsilcileri].SLSMANREF WHERE YIL = 2017 AND AY = MONTH(getdate()) AND PRIMB > 11 AND SIPALN_KOD IN (SELECT DISTINCT SLSREF FROM [Web-Hedef] WHERE YIL = vw_Web_Hedef_Bekleyen_3.YIL AND AY = vw_Web_Hedef_Bekleyen_3.AY) GROUP BY [SAT TEM],PRIMB) AS TABLO1 GROUP BY [SAT TEM],KATEGORI,PRIM_GRUBU", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
