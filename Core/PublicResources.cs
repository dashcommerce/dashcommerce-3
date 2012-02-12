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
using MettleSystems.dashCommerce.Core.Properties;

namespace MettleSystems.dashCommerce.Core {
  /// <summary>
  /// Public class that exposes common Resource file definitions for use
  /// across different projects to reduce redundancy.
  /// </summary>
  public class PublicResources {

    #region Methods
    
    #region Public

      /// <summary>
      /// Gets the argument exception message.
      /// </summary>
      /// <value>The argument exception.</value>
      public static string ArgumentExceptionMessage {
        get {
          return Resources.ArgumentException;
        }
      }

      /// <summary>
      /// Gets the argument null exception message.
      /// </summary>
      /// <value>The argument null exception.</value>
      public static string ArgumentNullExceptionMessage {
        get {
          return Resources.ArgumentNullException;
        }
      }

      /// <summary>
      /// Gets the object null exception message.
      /// </summary>
      /// <value>The object null exception.</value>
      public static string ObjectNullExceptionMessage {
        get {
          return Resources.ObjectNullException;
        }
      }

      /// <summary>
      /// Gets the object type exception message.
      /// </summary>
      /// <value>The object type exception.</value>
      public static string ObjectTypeExceptionMessage {
        get {
          return Resources.ObjectTypeException;
        }
      }

      /// <summary>
      /// Gets the enum definition exception message.
      /// </summary>
      /// <value>The enum definition exception.</value>
      public static string EnumDefinitionExceptionMessage {
        get {
          return Resources.EnumDefinitionException;
        }
      }

      /// <summary>
      /// Gets the argument greater than zero exception message.
      /// </summary>
      /// <value>The argument greater than zero exception message.</value>
      public static string ArgumentGreaterThanZeroExceptionMessage {
        get {
          return Resources.ArgumentMustBeGreaterThanZero;
        }
      }

      /// <summary>
      /// Gets the argument must be serializable exception message.
      /// </summary>
      /// <value>The argument must be serializable exception message.</value>
      public static string ArgumentMustBeSerializableExceptionMessage {
        get {
          return Resources.ArgumentMustBeSerializable;
        }
      }

      #endregion
      
    #endregion
     
  }
}
