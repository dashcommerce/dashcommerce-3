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
  
  internal enum AuthorizeNetTransactionType {
    AUTH_CAPTURE,
    AUTH_ONLY,
    PRIOR_AUTH_CAPTURE,
    CAPTURE_ONLY,
    CREDIT,
    VOID
  }

}
