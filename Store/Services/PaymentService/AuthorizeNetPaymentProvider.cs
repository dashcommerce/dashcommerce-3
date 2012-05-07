#region Copyright / License

/*
Copyright © 2008 Mettle Systems LLC.  All rights reserved.
Unauthorized reproduction is a violation of applicable law.
This material contains certain confidential or proprietary 
information or trade secrets of Mettle Systems LLC.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN 
NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using System;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.PaymentService;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {

  public class AuthorizeNetPaymentProvider : IPaymentProvider {

    #region Constants

    public static readonly string API_USERNAME = "ApiUserName";
    public static readonly string API_TRANSACTION_KEY = "ApiTransactionKey";
    public static readonly string ISLIVE = "IsLive";
    public static readonly string IS_IN_TEST_MODE = "IsInTestMode";

    #endregion

    #region Member Variables

    AuthorizeNET.AuthorizeService _authorizeService = null;
    
    #endregion
    
    #region Constructors
    
    public AuthorizeNetPaymentProvider() {
    }
    
    public AuthorizeNetPaymentProvider(string apiUserName, string apiTransactionKey, string isInTestMode, string isLive) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiUserName, "apiUserName");
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiTransactionKey, "apiTransactionKey");
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(isInTestMode, "isInTestMode");
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(isLive, "isLive");

      bool IsInTestMode = true; //default to test mode
      bool isParsed = bool.TryParse(isInTestMode, out IsInTestMode);


      bool IsLive = false; //default to the sandbox
      isParsed = bool.TryParse(isLive, out IsLive);
      _authorizeService = new AuthorizeNET.AuthorizeService(apiUserName, apiTransactionKey, IsInTestMode, IsLive);
    }
    
    #endregion

    #region IPaymentProvider Members

    public Transaction Authorize(Order order) {
      throw new Exception("The method or operation is not implemented.");
    }

    public Transaction Charge(Order order) {
      Transaction transaction = _authorizeService.Charge(order);
      return transaction;
    }

    public Transaction Refund(Transaction transaction, Order order) {
      Transaction refundTransaction = _authorizeService.Refund(transaction, order);
      return refundTransaction;
    }

    #endregion

  }
}
