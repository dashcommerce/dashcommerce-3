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
