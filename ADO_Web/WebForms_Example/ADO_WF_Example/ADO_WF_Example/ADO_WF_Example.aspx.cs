using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ADO_WF_Example
{
    public partial class ADO_WF_Example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            { 
                con = new SqlConnection("data source=.; database=Student; integrated security=SSPI");
                string query = "INSERT student1(name, email, contact) VALUES('" + UsernameId.Text + "','" + EmailId.Text + "','" + ContactId.Text + "')";  
                SqlCommand sc = new SqlCommand(query, con);                
                con.Open();
                sc.ExecuteNonQuery();
                Label1.Text = "Your record has been saved with the following details!";

                //----------------------------- Retrieving Data ----------------------------------- //  
                string squery = "SELECT TOP 1 * FROM student1";
                SqlCommand cm = new SqlCommand(squery, con);
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                    Label2.Text = "User Name"; Label5.Text = sdr["name"].ToString();
                    Label3.Text = "Email ID"; Label6.Text = sdr["email"].ToString();
                    Label4.Text = "Contact"; Label7.Text = sdr["contact"].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }
        }
    }
}