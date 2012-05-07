#region Copyright / License

/*
Copyright © 2008 Mettle Systems LLC.  All rights reserved.
Unauthorized reproduction is a violation of applicable law.
This material contains certain confidential or proprietary 
information or trade secrets of Mettle Systems LLC.
*/

#endregion

using System;
using System.Runtime.Serialization;

using MettleSystems.dashCommerce.Store.Services.PaymentService;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {
  [Serializable]
  public class AuthorizeNetServiceException : PaymentServiceException {

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:AuthorizeNetServiceException"/> class.
    /// </summary>
    public AuthorizeNetServiceException()
      : base() {
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="T:AuthorizeNetServiceException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public AuthorizeNetServiceException(string message)
      : base(message) {
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="T:AuthorizeNetServiceException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public AuthorizeNetServiceException(string message, Exception innerException)
      : base(message, innerException) {
    }

    public AuthorizeNetServiceException(SerializationInfo info, StreamingContext context) 
      : base(info, context) { 
    }

    #endregion

  }
}