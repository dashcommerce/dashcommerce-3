#region dashCommerce License
/*
dashCommerce® is Copyright © 2008-2012 Mettle Systems LLC. All Rights Reserved.


dashCommerce, and the dashCommerce logo are registered trademarks of Mettle Systems LLC. Mettle Systems LLC logos and trademarks may not be used without prior written consent.

dashCommerce is licensed under the following license. If you do not accept the terms, please discontinue the use of dashCommerce and uninstall dashCommerce. 

Your license to the dashCommerce source and/or binaries is governed by the Reciprocal Public License 1.5 (RPL1.5) license as described here: 

http://www.opensource.org/licenses/rpl1.5.txt 

If you do not wish to release the source of software you build using dashCommerce, you may purchase a site license, which will allow you to deploy dashCommerce for use in 1 web store defined as using 1 URL. You may purchase a site license here: 

http://www.dashcommerce.org/license.html 
*/
#endregion
using System;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.order {
  public partial class transaction : AdminControl {
  
    #region Member Variables
    
    private int orderId = 0;
    private string view = string.Empty;

    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        orderId = Utility.GetIntParameter("orderId");
        view = Utility.GetParameter("view");
        if(orderId > 0 && view == "t") {
          SetTransactionProperties();
          TransactionCollection transactionCollection = new TransactionController().FetchByOrderId(orderId);
          rptrTransactions.DataSource = transactionCollection;
          rptrTransactions.ItemDataBound += new RepeaterItemEventHandler(rptrTransactions_ItemDataBound);
          rptrTransactions.DataBind();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(transaction).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the rptrTransactions control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
    void rptrTransactions_ItemDataBound(object sender, RepeaterItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        Transaction transaction = e.Item.DataItem as Transaction;
        if(transaction != null) {
          if(transaction.GatewayResponse.Contains("Pending")) {
            HyperLink helpLink = e.Item.FindControl("helpPayPalPending") as HyperLink;
            if(helpLink != null) {
              helpLink.Visible = true;
            }
          }
        }
        Label lblTransactionId = e.Item.FindControl("lblTransactionId") as Label;
        if(lblTransactionId != null) {
          
        }
        Label lblTransactionType = e.Item.FindControl("lblTransactionType") as Label;
        if(lblTransactionType != null) {
          
        }
        Label lblPaymentMethod = e.Item.FindControl("lblPaymentMethod") as Label;
        if(lblPaymentMethod != null) {
          
        }
        Label lblGatewayName = e.Item.FindControl("lblGatewayName") as Label;
        if(lblGatewayName != null) {
          
        }
        Label lblGatewayResponse = e.Item.FindControl("lblGatewayResponse") as Label;
        if(lblGatewayResponse != null) {
          
        }
        Label lblGatewayTransactionId = e.Item.FindControl("lblGatewayTransactionId") as Label;
        if(lblGatewayTransactionId != null) {
          
        }
        Label lblAVSCode = e.Item.FindControl("lblAVSCode") as Label;
        if(lblAVSCode != null) {
          
        }
        Label lblCVV2Code = e.Item.FindControl("lblCVV2Code") as Label;
        if(lblCVV2Code != null) {
          
        }
        Label lblGrossAmount = e.Item.FindControl("lblGrossAmount") as Label;
        if(lblGrossAmount != null) {
          
        }
        Label lblNetAmount = e.Item.FindControl("lblNetAmount") as Label;
        if(lblNetAmount != null) {
          
        }
        Label lblFeeAmount = e.Item.FindControl("lblFeeAmount") as Label;
        if(lblFeeAmount != null) {
          
        }
        Label lblTransactionDate = e.Item.FindControl("lblTransactionDate") as Label;
        if(lblTransactionDate != null) {
          
        }
        Label lblGatewayErrors = e.Item.FindControl("lblGatewayErrors") as Label;
        if(lblGatewayErrors != null) {
          
        }
        
      }
    }

    #endregion
    
    #region Methods
    
    #region Protected

    /// <summary>
    /// Gets the formatted amount.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns></returns>
    protected string GetFormattedAmount(string amount) {
      return StoreUtility.GetFormattedAmount(amount, true);
    }
    
    #endregion
    
    #region Private

    /// <summary>
    /// Sets the transaction properties.
    /// </summary>
    private void SetTransactionProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleOrderTransactions");
    
    }

    #endregion
    
    #endregion
    
  }
}