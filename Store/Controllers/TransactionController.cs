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

using System.Data;
using SubSonic;

namespace MettleSystems.dashCommerce.Store {
  public partial class TransactionController {
  
    #region Constants
    
    private const string TOO_MANY_TRANSACTIONS = "Transaction Collection cannot have more than 1.";
    
    #endregion
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Fetch by order id.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <returns></returns>
    public TransactionCollection FetchByOrderId(int orderId) {
      IDataReader reader = SPs.FetchAssociatedOrderTransactions(orderId).GetReader();
      TransactionCollection transactionCollection = new TransactionCollection();
      transactionCollection.LoadAndCloseReader(reader);
      transactionCollection.Sort(Transaction.Columns.TransactionDate, true);
      return transactionCollection;
    }

    /// <summary>
    /// Fetch by order id and transaction type id.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <param name="transactionTypeId">The transaction type id.</param>
    /// <returns></returns>
    public Transaction FetchByOrderIdAndTransactionTypeId(int orderId, int transactionTypeId) {
      Transaction transaction = null;
      Query query = new Query(Transaction.Schema).
        AddWhere(Transaction.Columns.OrderId, orderId).
        AddWhere(Transaction.Columns.TransactionTypeDescriptorId, transactionTypeId);
      TransactionCollection transactionCollection = new TransactionController().FetchByQuery(query);
      if(transactionCollection.Count > 1) {
        throw new InvalidOperationException(TOO_MANY_TRANSACTIONS);
      }
      if(transactionCollection.Count > 0) {
        transaction = transactionCollection[0];
      }
      return transaction;
    }
    
    #endregion
    
    #endregion
    
  }
}
