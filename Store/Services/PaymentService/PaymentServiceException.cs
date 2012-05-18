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

using System.Runtime.Serialization;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {
  
  [Serializable]
  public class PaymentServiceException : Exception {

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PaymentServiceException"/> class.
    /// </summary>
    public PaymentServiceException() 
      : base() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PaymentServiceException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public PaymentServiceException(string message) 
      : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PaymentServiceException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public PaymentServiceException(string message, Exception innerException) 
      : base(message, innerException) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PaymentServiceException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
    /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
    public PaymentServiceException(SerializationInfo info, StreamingContext context) 
      : base(info, context) {
    }

    #endregion

  }
}
