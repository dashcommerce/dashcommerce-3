#region dashCommerce License
/*
The MIT License

Copyright (c) 2008 - 2010 Mettle Systems LLC, P.O. Box 181192 Cleveland Heights, Ohio 44118, United States

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System;

using System.Runtime.Serialization;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService.PayPal {

  [Serializable]
  public class PayPalServiceException : PaymentServiceException {
  
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalServiceException"/> class.
    /// </summary>
    public PayPalServiceException()
      : base() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalServiceException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public PayPalServiceException(string message)
      : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalServiceException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public PayPalServiceException(string message, Exception innerException)
      : base(message, innerException) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalServiceException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
    /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
    public PayPalServiceException(SerializationInfo info, StreamingContext context) 
      : base(info, context) {
    }
    
    #endregion

    public override string Message {
      get {
        string message = base.Message.Substring(base.Message.IndexOf("LongMessage:") + 12, (base.Message.IndexOf("SeverityCode:") - (base.Message.IndexOf("LongMessage:") + 12)));
        return message;
      }
    }

    public string MessageDetail {
      get {
        return base.Message;
      }
    }
    
  }
}