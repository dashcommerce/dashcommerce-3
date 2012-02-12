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
