using System;
using System.Web;

using System.Data;
using System.IO;
using System.Web.Security;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  
  
  public class download : IHttpHandler {
    
    int downloadId = 0;
    bool canDownload = false;

    public void ProcessRequest(HttpContext context) {
      try {
        downloadId = Utility.GetIntParameter("did");

        #region Download Download

        if (downloadId > 0) {
          Download download = new Download(downloadId);
          if (download.ForPurchaseOnly) {
            if (Membership.GetUser() != null) {
              Query query = new Query(DownloadAccessControl.Schema)
                .WHERE(DownloadAccessControl.Columns.UserId, Membership.GetUser().ProviderUserKey)
                .WHERE(DownloadAccessControl.Columns.DownloadId, downloadId);
              DownloadAccessControlCollection downloadAccessControllCollection = new DownloadAccessControlCollection();
              downloadAccessControllCollection.LoadAndCloseReader(query.ExecuteReader());
              if (downloadAccessControllCollection.Count > 0) {
                canDownload = true;
              }
            }
            else {
              canDownload = false;
            }
          }
          else {
            canDownload = true;
          }
          FileInfo fileInfo = new FileInfo(context.Server.MapPath(download.DownloadFile));
          if (fileInfo.Exists && canDownload) {
            context.Response.Clear();
            context.Response.AddHeader("Pragma", "public");
            context.Response.AddHeader("Expires", "0");
            context.Response.AddHeader("Cache-Control", "must-revalidate, post-check=0, pre-check=0");
            context.Response.AddHeader("Content-Type", "application/force-download");
            context.Response.AddHeader("Content-Type", "application/octet-stream");
            context.Response.AddHeader("Content-Type", "application/download");
            context.Response.AddHeader("Content-Disposition", "attachement; filename=" + fileInfo.Name);
            context.Response.AddHeader("Content-Transfer-Encoding", "binary");
            context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            context.Response.ContentType = download.ContentType;
            context.Response.WriteFile(fileInfo.FullName);
            context.Response.End();
          }
          else {
            context.Response.Clear();
            context.Response.Write(LocalizationUtility.GetText("lblAccessDenied"));
            context.Response.End();
          }
        }

        #endregion


      }
      catch(System.Threading.ThreadAbortException) {
        //swallow it
      }
      catch(Exception ex) {
        Logger.Error(typeof(download).Name + ".ProcessRequest", ex);
        throw;
      }
    }

    public bool IsReusable {
      get {
        return false;
      }
    }
  }
}
