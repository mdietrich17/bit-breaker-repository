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
using Microsoft.AspNet.Identity;
using SimplySeniors.Models.ViewModel;

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
        // function for actually uploading a photo into the SIMPLY SENIORS DB
        protected void btnUpload_Click(object sender, EventArgs e)
        {
             HttpPostedFile postedFile = FileUpload1.PostedFile;
             string fileName = Path.GetFileName(postedFile.FileName);
             string fileExtension = Path.GetExtension(fileName);
             // all identifiers will be set to 1, this was intentional for future sprints. 
             var profileIdentifier = 1; 
             var fileSize = postedFile.ContentLength; 
             // Allow .jpg, .bmp., .png, .gif as accepted formats. 
             if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
             {
                 // Below reads the image using an InputStream and then converts it to a byte array to be stored in the DB. 
                 Stream stream = postedFile.InputStream; 
                 BinaryReader binaryReader = new BinaryReader(stream);
                 byte[] bytes = binaryReader.ReadBytes((int) stream.Length);
                 // SETTINGS FOR AZURE CONTINUOUS DEPLOYMENT BELOW. 
                // string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                 string cs = ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString;

                // Code below creates a new sql connections and add the fields below to the table "Images" in the backend. 
                using (SqlConnection con = new SqlConnection(cs) )
                 {
                     SqlCommand cmd = new SqlCommand("spUploadImage", con);
                     cmd.CommandType = CommandType.StoredProcedure;

                     SqlParameter paramName = new SqlParameter()
                     {
                         ParameterName = "@Name",
                         Value = fileName
                     };
                     cmd.Parameters.Add(paramName);
                    
                     SqlParameter paramSize = new SqlParameter()
                     {
                         ParameterName = "@Size",
                         Value = fileSize
                     };
                     cmd.Parameters.Add(paramSize);
                    // Using profile Id to link FK to PK for updated photo algorithm in future refinements. 
                    SqlParameter paramProfileIdentifier = new SqlParameter()
                    {
                        
                        ParameterName = "@ProfileId",
                        Value = profileIdentifier
                    };
                    string number = con.ClientConnectionId.ToString();
                    cmd.Parameters.Add(paramProfileIdentifier);
                    
                    SqlParameter paramImageData = new SqlParameter()
                     {
                         ParameterName = "@ImageData",
                         Value = bytes
                     };
                     cmd.Parameters.Add(paramImageData);

                     SqlParameter paramNewId = new SqlParameter()
                     {
                         ParameterName = "@NewId",
                         Value = -1,
                         Direction = ParameterDirection.Output
                     };
                     cmd.Parameters.Add(paramNewId);

                     con.Open();
                     cmd.ExecuteNonQuery(); 
                     con.Close();
                     lblMessage.Visible = true;
                     // If uploaded properly a message in green will be displayed in the UI else error is displayed and they can try again.
                     lblMessage.Text = "Your upload was successfully saved to the Simply Senior's database";
                     lblMessage.ForeColor = System.Drawing.Color.Green;
                     hyperlink.Visible = true;
                     hyperlink.NavigateUrl = "~/PhotoDownloadForm.aspx?Id=" + cmd.Parameters["@NewId"].Value.ToString();
                 }
             }
             else {
                lblMessage.Visible = true;
                lblMessage.Text = "You can only upload .jpg, .png, .gif and .bmp.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                hyperlink.Visible = false; 
             }
        }
    }
}