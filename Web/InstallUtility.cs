using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace MettleSystems.dashCommerce.Web {
  public class InstallUtility {

    public static void RedirectToInstall() {
      if (!WebUtility.CurrentUrl.ToLower().Contains("install/install.aspx")) {
        HttpContext.Current.Response.Redirect("~/install/install.aspx");
      }
    }

    public static void CreateDatabase(string databaseName, string connectionString) {
        string query = string.Format("CREATE DATABASE [{0}]", databaseName);

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
        }
    }

    public static void SetConnectionString(string name, string connectionString) {
      var webConfiguration = WebConfigurationManager.OpenWebConfiguration("~");
      if (webConfiguration.ConnectionStrings.ConnectionStrings[name] != null) {
        webConfiguration.ConnectionStrings.ConnectionStrings[name].ConnectionString = connectionString;
      }
      else {
        webConfiguration.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(name, connectionString));
      }
      webConfiguration.Save();
    }

  }
}