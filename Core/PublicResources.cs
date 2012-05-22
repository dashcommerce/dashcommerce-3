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
