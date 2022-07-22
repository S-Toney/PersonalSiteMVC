using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class PSDataLayer
    {
        public string ApplicationName = "PersonalSiteMVC";
        private string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationConnectionString"].ConnectionString;
        
        protected SqlConnection CreateConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }

        #region Error Tracking
        public void ErrorMessageWriter(Exception ex, string messageURL, string serverName, string app)
        {
            SqlConnection con = CreateConnection();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("AddErrorDetailsToDB", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicationName", app);
                cmd.Parameters.AddWithValue("@ServerName", serverName);
                cmd.Parameters.AddWithValue("@URL", messageURL);
                cmd.Parameters.AddWithValue("@MessageDate", DateTime.Now);
                if (ex.Source == null)
                {
                    string source = "Originally set to null";
                    cmd.Parameters.AddWithValue("@Source", source);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Source", ex.Source);
                }
                cmd.Parameters.AddWithValue("@Message", ex.Message);
                if (ex.InnerException != null)
                {
                    cmd.Parameters.AddWithValue("@Stack", ex.InnerException.ToString());
                }
                else
                {
                    if (ex.StackTrace == null)
                    {
                        string stack = "Originally set to null";
                        cmd.Parameters.AddWithValue("@Stack", stack);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Stack", ex.StackTrace);
                    }
                }
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();            }
                catch (Exception ex1)
                {
                    ErrorMessageWriter(ex1, "PSDataLayer.cs", "n/a", app);
                    throw;
                }
            }           
        }
        #endregion
    }
}
