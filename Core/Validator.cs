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
using MettleSystems.dashCommerce.Core.Properties;

namespace MettleSystems.dashCommerce.Core {
  /// <summary>
  /// Class that provides general validation methods.
  /// </summary>
  public static class Validator {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Validates the string argument is not null or empty string.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <param name="argumentName">Name of the argument.</param>
    public static void ValidateStringArgumentIsNotNullOrEmptyString(string argument, string argumentName) {
      if (string.IsNullOrEmpty(argument)) {
        throw new ArgumentException(Resources.ArgumentException, argumentName);
      }
    }

    /// <summary>
    /// Validates the argument is not null.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <param name="argumentName">Name of the argument.</param>
    public static void ValidateArgumentIsNotNull(object argument, string argumentName) {
      if (argument == null) {
        throw new ArgumentNullException(argumentName, Resources.ArgumentNullException);
      }
    }

    /// <summary>
    /// Validates the object is not null.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <param name="objectName">Name of the object.</param>
    public static void ValidateObjectIsNotNull(object obj, string objectName) {
      if (obj == null) {
        throw new InvalidOperationException(string.Format(PublicResources.ObjectNullExceptionMessage, objectName));
      }
    }

    /// <summary>
    /// Validates the type of the object.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <param name="type">The type.</param>
    public static void ValidateObjectType(object obj, Type type) {
      if (obj.GetType() != type) {
        throw new ArgumentException(string.Format(PublicResources.ObjectTypeExceptionMessage, type, obj.GetType()));
      }
    }

    /// <summary>
    /// Validates the enum is defined.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="argument">The argument.</param>
    public static void ValidateEnumIsDefined(Type type, string argument) {
      if (!Enum.IsDefined(type, argument)) {
        throw new ArgumentOutOfRangeException(
          string.Format(PublicResources.EnumDefinitionExceptionMessage, type, argument));
      }
    }

    /// <summary>
    /// Validates the integer is greater than zero.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="argumentName">Name of the argument.</param>
    public static void ValidateIntegerIsGreaterThanZero(int value, string argumentName) {
      if (value <= 0) {
        throw new ArgumentException(string.Format(PublicResources.ArgumentGreaterThanZeroExceptionMessage, argumentName));
      }
    }

    /// <summary>
    /// Validates the argument is serializable.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <param name="argumentName">Name of the argument.</param>
    public static void ValidateArgumentIsSerializable(object obj, string argumentName) {
      if (!obj.GetType().IsSerializable) {
        throw new ArgumentOutOfRangeException(argumentName, string.Format(PublicResources.ArgumentMustBeSerializableExceptionMessage, obj.GetType().Name));
      }
    }
    
    #endregion
    
    #endregion
    
  }
}
