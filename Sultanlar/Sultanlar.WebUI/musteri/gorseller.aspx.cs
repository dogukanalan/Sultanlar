using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Sultanlar.DatabaseObject.Internet;
using System.Data;
using System.Collections;
//using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using Sultanlar.Class;

namespace Sultanlar.WebUI.musteri
{
    public partial class gorseller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
            //if (!IsPostBack)
                //GetObjects();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            Resimler.GetObjects(dt);
            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            Response.Redirect("resim.aspx?uid=" + e.Values[0].ToString(), true);
            //byte[] resim = Resim.ResimOlustur400400(Resimler.GetObjectByResimID(Convert.ToInt32(e.Values[0].ToString())), true, true);
            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "image/png";
            //Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", e.Values[0].ToString()));
            //Response.BinaryWrite(resim);
            //Response.Flush();
            //Response.End();
        }

        protected void btnIndir_Click(object sender, EventArgs e)
        {
            //ArrayList indirilecekler = new ArrayList();
            //for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            //    if (ASPxGridView1.Selection.IsRowSelected(i))
            //        indirilecekler.Add(ASPxGridView1.GetRowValues(i, "RESIMID").ToString());

            //Response.AddHeader("Content-Disposition", "attachment; filename=Gorseller.zip");
            //Response.ContentType = "application/zip";
            //using (var zipStream = new ZipOutputStream(Response.OutputStream))
            //{
            //    zipStream.SetLevel(3);
            //    //byte[] buffer = new byte[4096];
            //    for (int i = 0; i < indirilecekler.Count; i++)
            //    {
            //        byte[] fileBytes = Resimler.GetObjectByResimID(Convert.ToInt32(indirilecekler[i]));
            //        Stream fs = new MemoryStream(fileBytes);

            //        string Urun = Urunler.GetProductName(UrunResim.GetUrunIDByResimID(Convert.ToInt32(indirilecekler[i]))).Replace(" ", "-");
            //        var fileEntry = new ZipEntry(Urun + ".jpg")
            //        {
            //            Size = fileBytes.Length
            //        };

            //        //int count = fs.Read(buffer, 0, buffer.Length);
            //        //while (count > 0)
            //        //{
            //        //    zipStream.Write(buffer, 0, count);
            //        //    count = fs.Read(buffer, 0, buffer.Length);
            //        //    if (!Response.IsClientConnected)
            //        //    {
            //        //        break;
            //        //    }
            //        //    Response.Flush();
            //        //}
            //        //fs.Close();

            //        zipStream.PutNextEntry(fileEntry);
            //        zipStream.Write(fileBytes, 0, fileBytes.Length);

            //        ResimlerIndirmeler ri = new ResimlerIndirmeler(Convert.ToInt32(indirilecekler[i]), ((Musteriler)Session["Musteri"]).pkMusteriID, DateTime.Now, "");
            //        ri.DoInsert();
            //    }

            //    //zipStream.Finish();
            //    zipStream.Close();
            //    //zipStream.Flush();
            //    Response.Flush();
            //    Response.End();
            //}
        }

        //protected void ASPxGridView1_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        //{
        //    ASPxGridView1.Selection.UnselectAll();
        //    ASPxGridView1.Selection.SelectRowByKey(e.Parameters);
        //}
    }
}