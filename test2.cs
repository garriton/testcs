using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TEST
{
    public partial class WebForm : System.Web.UI.Page
    {
        public static string ConnectionString
        {
            get; set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.Form["product_name"];
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    CommandText = "SELECT ProductId FROM Products WHERE ProductName = '" + name + "'",
                    CommandType = CommandType.Text,
                };

                SqlDataReader reader = sqlCommand.ExecuteReader();
            }
        }

        protected void Page_Load1(object sender, EventArgs e)
        {
            string name = Request.Form["product_name"];
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    CommandText = string.Format("SELECT ProductId FROM Products WHERE ProductName = '{0}'", name),
                    CommandType = CommandType.Text,
                };

                SqlDataReader reader = sqlCommand.ExecuteReader();
            }
        }
}
