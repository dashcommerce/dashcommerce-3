using System;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {
  public class NullPaymentProvider : IPaymentProvider {

    #region Constants

    private const string SYSTEM = "System";

    #endregion

    #region IPaymentProvider Members

    public Transaction Authorize(Order order) {
      throw new Exception("The method or operation is not implemented.");
    }

    public Transaction Charge(Order order) {
      Transaction transaction = new Transaction();
      transaction.OrderId = order.OrderId;
      transaction.TransactionTypeDescriptorId = (int)TransactionType.Charge;
      transaction.PaymentMethod = order.CreditCardType.ToString();
      transaction.GatewayName = "Null Payment Provider";
      transaction.GatewayResponse = "Charged";
      transaction.GatewayTransactionId = Core.CoreUtility.GenerateRandomString(16);
      transaction.GrossAmount = Convert.ToDecimal(order.Total);
      transaction.TransactionDate = DateTime.UtcNow;
      transaction.GatewayErrors = string.Empty;
      transaction.AVSCode = "N/A";
      transaction.CVV2Code = "N/A";
      transaction.Save(SYSTEM);
      return transaction;
    }

    public Transaction Refund(Transaction transaction, Order order) {
      Transaction refundedTransaction = new Transaction();
      refundedTransaction.OrderId = transaction.OrderId;
      refundedTransaction.TransactionTypeDescriptorId = (int)TransactionType.Refund;
      refundedTransaction.PaymentMethod = order.CreditCardType.ToString();
      refundedTransaction.GatewayName = "Null Payment Provider";
      refundedTransaction.GatewayResponse = "Refunded";
      refundedTransaction.GatewayTransactionId = Core.CoreUtility.GenerateRandomString(16);
      refundedTransaction.TransactionDate = DateTime.UtcNow;
      refundedTransaction.GrossAmount = Convert.ToDecimal(order.Total);
      transaction.GatewayErrors = string.Empty;
      transaction.AVSCode = "N/A";
      transaction.CVV2Code = "N/A";
      transaction.Save(SYSTEM);
      return refundedTransaction;
    }


    #endregion
  }
}
