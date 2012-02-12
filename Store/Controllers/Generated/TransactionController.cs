using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Store
{
    /// <summary>
    /// Controller class for dashCommerce_Store_Transaction
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TransactionController
    {
        // Preload our schema..
        Transaction thisSchemaLoad = new Transaction();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TransactionCollection FetchAll()
        {
            TransactionCollection coll = new TransactionCollection();
            Query qry = new Query(Transaction.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransactionCollection FetchByID(object TransactionId)
        {
            TransactionCollection coll = new TransactionCollection().Where("TransactionId", TransactionId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransactionCollection FetchByQuery(Query qry)
        {
            TransactionCollection coll = new TransactionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TransactionId)
        {
            return (Transaction.Delete(TransactionId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TransactionId)
        {
            return (Transaction.Destroy(TransactionId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int OrderId,int TransactionTypeDescriptorId,string PaymentMethod,string GatewayName,string GatewayResponse,string GatewayTransactionId,string AVSCode,string CVV2Code,decimal GrossAmount,decimal NetAmount,decimal FeeAmount,DateTime TransactionDate,string GatewayErrors,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Transaction item = new Transaction();
		    
            item.OrderId = OrderId;
            
            item.TransactionTypeDescriptorId = TransactionTypeDescriptorId;
            
            item.PaymentMethod = PaymentMethod;
            
            item.GatewayName = GatewayName;
            
            item.GatewayResponse = GatewayResponse;
            
            item.GatewayTransactionId = GatewayTransactionId;
            
            item.AVSCode = AVSCode;
            
            item.CVV2Code = CVV2Code;
            
            item.GrossAmount = GrossAmount;
            
            item.NetAmount = NetAmount;
            
            item.FeeAmount = FeeAmount;
            
            item.TransactionDate = TransactionDate;
            
            item.GatewayErrors = GatewayErrors;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TransactionId,int OrderId,int TransactionTypeDescriptorId,string PaymentMethod,string GatewayName,string GatewayResponse,string GatewayTransactionId,string AVSCode,string CVV2Code,decimal GrossAmount,decimal NetAmount,decimal FeeAmount,DateTime TransactionDate,string GatewayErrors,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Transaction item = new Transaction();
		    
				item.TransactionId = TransactionId;
				
				item.OrderId = OrderId;
				
				item.TransactionTypeDescriptorId = TransactionTypeDescriptorId;
				
				item.PaymentMethod = PaymentMethod;
				
				item.GatewayName = GatewayName;
				
				item.GatewayResponse = GatewayResponse;
				
				item.GatewayTransactionId = GatewayTransactionId;
				
				item.AVSCode = AVSCode;
				
				item.CVV2Code = CVV2Code;
				
				item.GrossAmount = GrossAmount;
				
				item.NetAmount = NetAmount;
				
				item.FeeAmount = FeeAmount;
				
				item.TransactionDate = TransactionDate;
				
				item.GatewayErrors = GatewayErrors;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

