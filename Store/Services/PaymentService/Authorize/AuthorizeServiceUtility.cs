#region Copyright / License

/*
Copyright © 2008 Mettle Systems LLC.  All rights reserved.
Unauthorized reproduction is a violation of applicable law.
This material contains certain confidential or proprietary 
information or trade secrets of Mettle Systems LLC.
*/

#endregion

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService.AuthorizeNET {

  public class AuthorizeServiceUtility {

    public static string GetAuthorizeServiceEndpoint(bool isLive) {
      if(isLive) {
        return "https://secure.authorize.net/gateway/transact.dll";
      }
      else {
        return "https://test.authorize.net/gateway/transact.dll";
      }
    }

    public static string AuthorizeNetVersionNumber {
      get {
        return "3.1";
      }
    }

  }
}
