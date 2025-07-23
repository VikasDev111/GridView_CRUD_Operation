using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class gridview_crud : System.Web.UI.Page
{
    static string MyConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
    SqlConnection con = new SqlConnection(MyConn);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Student", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string age = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

        SqlCommand cmd = new SqlCommand("UPDATE Student SET Name=@Name, Age=@Age WHERE Id=@Id", con);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Age", age);
        cmd.Parameters.AddWithValue("@Id", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE Id=@Id", con);
        cmd.Parameters.AddWithValue("@Id", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        BindGrid();
    }


    protected void LoopAllRows_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            string name = row.Cells[1].Text;
            string age = row.Cells[2].Text;

            // You can also access controls inside TemplateField if used.
            // For example: TextBox txtName = (TextBox)row.FindControl("txtName");

            Response.Write("Student: " + name + " - Age: " + age + "<br/>");
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO Student (Name, Age) VALUES (@Name, @Age)", con);
        cmd.Parameters.AddWithValue("@Name", txtName.Text.ToString());
        cmd.Parameters.AddWithValue("@Age", txtAge.Text.ToString());

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        txtName.Text = "";
        txtAge.Text = "";

        BindGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Student WHERE Name LIKE @search", con);
        da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text.ToString() + "%");

        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    //protected void btnModalInsert_Click(object sender, EventArgs e)
    //{
    //    SqlCommand cmd = new SqlCommand("INSERT INTO Student (Name, Age) VALUES (@Name, @Age)", con);
    //    cmd.Parameters.AddWithValue("@Name", txtModalName.Text.Trim());
    //    cmd.Parameters.AddWithValue("@Age", txtModalAge.Text.Trim());

    //    con.Open();
    //    cmd.ExecuteNonQuery();
    //    con.Close();

    //    txtModalName.Text = "";
    //    txtModalAge.Text = "";

    //    BindGrid();
    //}
}