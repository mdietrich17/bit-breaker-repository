using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimplySeniors
{
    public partial class PhotoUploadWebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //string cs = ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetImageById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // Using custom sql procedure found in our SQL scripts. Pulls image by ID number. 
                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = Request.QueryString["Id"]
                    
                };
                    cmd.Parameters.Add(paramId);
                    con.Open();
                    byte[] bytes = (byte[]) cmd.ExecuteScalar();
                    // If there is no photo uploaded then display place holder, else convert to byte array and store strBase64 in the image url to be shown. 
                    if (bytes == null)
                    {
                       
                        Image1.ImageUrl = "~/Photos/noimageavailble.jpg";
                    }
                    else
                    {
                        string strBase64 = Convert.ToBase64String(bytes);
                        Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                    }
            }
        }
    }
}