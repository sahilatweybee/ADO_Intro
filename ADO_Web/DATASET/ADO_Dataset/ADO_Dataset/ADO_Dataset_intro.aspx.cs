using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Dataset
{
    public partial class ADO_Dataset_intro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter("Select * from student", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Response.Write($"{ds.DataSetName} \n {ds.CaseSensitive} \n {ds.DefaultViewManager} \n {ds.Namespace} \n {ds.Site} \n {ds.Tables.Count}");
                con.Close();
            } catch(Exception ex)
            {
                Response.Write("Something Wrnt Wrong \n\n" + ex);
            }
        }
    }
}