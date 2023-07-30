using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Crud_asp.net
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-621JH0K;Initial Catalog=db_Employee;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
                clear();
            }


        }

        public void clear()
        {
            txtname.Text = "";
            textAge.Text="";
            textAddress.Text = "";
            rbl.Text = "";

        }

        public void databind()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_get", con);
            cmd.CommandType = new CommandType();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            grdview.DataSource = dt;
            grdview.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Age", textAge.Text);
                cmd.Parameters.AddWithValue("@Gender", rbl.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Address", textAddress.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                databind();
                clear();
            }
            else if(btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ViewState["m"]);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Age", textAge.Text);
                cmd.Parameters.AddWithValue("@Gender", rbl.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Address", textAddress.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                databind();
                clear();
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AA")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                databind();
            }

            else if(e.CommandName=="BB")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("usp_edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["Name"].ToString();
                textAge.Text = dt.Rows[0]["Age"].ToString();
                rbl.Text = dt.Rows[0]["Gender"].ToString();
                textAddress.Text = dt.Rows[0]["Address"].ToString();
                btnsave.Text = "Update";
                ViewState["m"] = e.CommandArgument;



            }
        }
        
        
    }
}