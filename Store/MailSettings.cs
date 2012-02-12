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

using MettleSystems.dashCommerce.Core.Configuration;

namespace MettleSystems.dashCommerce.Store {
  
  [Serializable()]
  public class MailSettings {

    #region Constants

    public const string SECTION_NAME = "mailSettings";

    #endregion

    #region Member Variables

    private string _from;
    private string _contact;
    private string _host;
    private string _userName;
    private string _password;
    private int _port;
    private bool _requireSsl = false;
    private bool _requireAuthenticaion = true;

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Loads this instance.
    /// </summary>
    /// <returns></returns>
    public static MailSettings Load() {
      DatabaseConfigurationProvider databaseConfigurationprovider = new DatabaseConfigurationProvider();
      MailSettings mailSettings = databaseConfigurationprovider.FetchConfigurationByName(MailSettings.SECTION_NAME) as MailSettings;
      return mailSettings;
    }
    
    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets from.
    /// </summary>
    /// <value>From.</value>
    public string From {
      get {
        return _from;
      }
      set {
        _from = value;
      }
    }

    /// <summary>
    /// Website admin email address.
    /// </summary>
    /// <value>From.</value>
    public string Contact {
      get {
        return _contact;
      }
      set {
        _contact = value;
      }
    }

    /// <summary>
    /// Gets or sets the host.
    /// </summary>
    /// <value>The host.</value>
    public string Host {
      get {
        return _host;
      }
      set {
        _host = value;
      }
    }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    /// <value>The name of the user.</value>
    public string UserName {
      get {
        return _userName;
      }
      set {
        _userName = value;
      }
    }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
    public string Password {
      get {
        return _password;
      }
      set {
        _password = value;
      }
    }

    /// <summary>
    /// Gets or sets the port.
    /// </summary>
    /// <value>The port.</value>
    public int Port {
      get {
        return _port;
      }
      set {
        _port = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [require SSL].
    /// </summary>
    /// <value><c>true</c> if [require SSL]; otherwise, <c>false</c>.</value>
    public bool RequireSsl {
      get {
        return _requireSsl;
      }
      set {
        _requireSsl = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [require authentication].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [require authentication]; otherwise, <c>false</c>.
    /// </value>
    public bool RequireAuthentication {
      get {
        return _requireAuthenticaion;
      }
      set {
        _requireAuthenticaion = value;
      }
    }
	

    #endregion

  }
}
