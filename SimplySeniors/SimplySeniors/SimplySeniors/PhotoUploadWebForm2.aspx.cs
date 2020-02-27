using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace SimplySeniors
{
    public partial class PhotoUploadWebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                hyperlink.Visible = false; 
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
             HttpPostedFile postedFile = FileUpload1.PostedFile;
             string fileName = Path.GetFileName(postedFile.FileName);
             string fileExtension = Path.GetExtension(fileName);
             int fileSize = postedFile.ContentLength; 

             if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
             {
                 Stream stream = postedFile.InputStream; 
                 BinaryReader binaryReader = new BinaryReader(stream);
                 byte[] bytes = binaryReader.ReadBytes((int) stream.Length);

                 string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                 using (SqlConnection con = new SqlConnection(cs) )
                 {
                     SqlCommand cmd = new SqlCommand("spUploadImage", con);
                     cmd.CommandType = CommandType.StoredProcedure; 
                 }
             }
            else {
                lblMessage.Visible = true;
                lblMessage.Text = "You can only upload .jpg, .png, .gif and .bmp to your account.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                hyperlink.Visible = false; 
             }
        }
    }
}