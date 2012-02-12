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
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.controls {
  public partial class address : System.Web.UI.UserControl {

    #region Member Variables

    private string _selectedAddress;
    private AddressType _addressType = AddressType.BillingAddress; //Default it to BillingAddress in case it's not set

    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the PreRender event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_PreRender(object sender, EventArgs e) {
      if(ddlAddress.Items.Count > 1 && pnlNewAddress.Visible == true)
        btnCancelAddNew.Visible = true;
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetAddressProperties();
        if (!Page.IsPostBack) {
          LoadAddresses();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(address).Name + ".Page_Load", ex);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void lbAddNew_Click(object sender, EventArgs e) {
      try {
        ShowAddressPanel();
      }
      catch (Exception ex) {
        Logger.Error(typeof(address).Name + ".lbAddNew_Click", ex);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnCancelAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnCancelAddNew_Click(object sender, EventArgs e) {
      try {
        ddlAddress.Visible = true;
        rfvAddress.Visible = true;
        lbAddNew.Visible = true;
        pnlNewAddress.Visible = false;
      }
      catch(Exception ex) {
        Logger.Error(typeof(address).Name + ".btnCancel_Click", ex);
      }
    }

    /// <summary>
    /// Handles the Changed event of the ddlCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void ddlCountry_Changed(object sender, EventArgs e) {
      LoadStateOrRegion(ddlCountry.SelectedValue);
    }

    #endregion
    
    #region Methods
    
    #region Public

    /// <summary>
    /// Loads the addresses.
    /// </summary>
    public void LoadAddresses() {
      List<Address> addressList = WebProfile.Current.AddressCollection.FindAll(delegate(Address address) { return address.AddressType == this.AddressType; });
      AddressCollection addressCollection = new AddressCollection();
      addressCollection.AddRange(addressList);

      if(addressCollection != null) {
        if(addressCollection.Count > 0) {
          ddlAddress.Items.Clear();
          foreach(Address address in addressCollection) {
            ddlAddress.Items.Add(new ListItem(string.Format("{0} {1}, {2} {3}, {4}, {5} {6}", address.FirstName, address.LastName, address.Address1, address.Address2, address.City, address.StateOrRegion, address.PostalCode), address.AddressId.ToString()));
          }
          ddlAddress.Items.Insert(0, new ListItem(LocalizationUtility.GetText("lblSelect"), string.Empty));
          if(!string.IsNullOrEmpty(_selectedAddress)) {
              if (ddlAddress.Items.FindByValue(_selectedAddress) != null)
                  ddlAddress.SelectedValue = _selectedAddress;
          }
        }
        else {//No addresses yet
          ShowAddressPanel();
          pnlAddNew.Visible = false;       
        }
      }
    }
    
    #endregion
    
    #region Private

    /// <summary>
    /// Loads the state or region.
    /// </summary>
    /// <param name="code">The code.</param>
    private void LoadStateOrRegion(string code) {
      StateOrRegionCollection stateOrRegionCollection = new StateOrRegionController().FetchStateOrRegionByCountryCode(code);
      if (stateOrRegionCollection.Count > 0) {
        txtStateOrRegion.Visible = false;
        rfvStateOrRegion.Visible = false;
        ddlStateOrRegion.Visible = true;
        ddlStateOrRegion.DataSource = stateOrRegionCollection;
        ddlStateOrRegion.DataTextField = "Name";
        ddlStateOrRegion.DataValueField = "Abbreviation".ToUpper();
        ddlStateOrRegion.DataBind();
        if (!string.IsNullOrEmpty(txtStateOrRegion.Text.Trim())) {
          //Try Value, then try by Text
          ListItem foundItem = null;
          foundItem = (foundItem == null) ? ddlStateOrRegion.Items.FindByValue(txtStateOrRegion.Text.Trim().ToUpper()) : ddlStateOrRegion.Items.FindByText(txtStateOrRegion.Text.Trim().ToUpper());
          if (foundItem != null) {
            ddlStateOrRegion.SelectedValue = foundItem.Value;
          }
        }
      }
      else {
        txtStateOrRegion.Visible = true;
        rfvStateOrRegion.Visible = true;
        ddlStateOrRegion.Visible = false;
      }
    }

    /// <summary>
    /// Sets the address properties.
    /// </summary>
    private void SetAddressProperties() {
      ddlAddress.ValidationGroup = GetValidationGroup();
      rfvAddress.ValidationGroup = GetValidationGroup();
      txtFirstName.ValidationGroup = GetValidationGroup();
      rfvFirstName.ValidationGroup = GetValidationGroup();
      txtLastName.ValidationGroup = GetValidationGroup();
      rfvLastName.ValidationGroup = GetValidationGroup();
      txtPhone.ValidationGroup = GetValidationGroup();
      rfvPhone.ValidationGroup = GetValidationGroup();
      txtEmail.ValidationGroup = GetValidationGroup();
      rfvEmail.ValidationGroup = GetValidationGroup();
      txtAddress1.ValidationGroup = GetValidationGroup();
      rfvAddress1.ValidationGroup = GetValidationGroup();
      txtAddress2.ValidationGroup = GetValidationGroup();
      txtCity.ValidationGroup = GetValidationGroup();
      rfvCity.ValidationGroup = GetValidationGroup();
      txtStateOrRegion.ValidationGroup = GetValidationGroup();
      rfvStateOrRegion.ValidationGroup = GetValidationGroup();
      txtPostalCode.ValidationGroup = GetValidationGroup();
      rfvPostalCode.ValidationGroup = GetValidationGroup();
      rfvCountry.ValidationGroup = GetValidationGroup();
    }

    /// <summary>
    /// Shows the address panel.
    /// </summary>
    private void ShowAddressPanel() {
      CountryCollection countryCollection = new CountryController().FetchAll();
      countryCollection.Sort(Core.Country.Columns.Name, true);
      ddlCountry.DataSource = countryCollection;
      ddlCountry.DataValueField = "Code";
      ddlCountry.DataTextField = "Name";
      ddlCountry.DataBind();
      ddlCountry.Items.Insert(0, new ListItem(LocalizationUtility.GetText("lblSelect"), string.Empty));
    
      ddlAddress.Visible = false;
      rfvAddress.Visible = false;
      lbAddNew.Visible = false;
      pnlNewAddress.Visible = true;
    }

    /// <summary>
    /// Gets the validation group.
    /// </summary>
    /// <returns></returns>
    private string GetValidationGroup() {
      return this.AddressType == AddressType.BillingAddress ? "billingAddress" : "shippingAddress";
    }

    #endregion
    
    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the address id.
    /// </summary>
    /// <value>The address id.</value>
    public string AddressId {
      get {
        return lblAddressId.Text;
      }
      set {
        lblAddressId.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the name of the first.
    /// </summary>
    /// <value>The name of the first.</value>
    public string FirstName {
      get {
        return txtFirstName.Text;
      }
      set {
        txtFirstName.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the name of the last.
    /// </summary>
    /// <value>The name of the last.</value>
    public string LastName {
      get {
        return txtLastName.Text;
      }
      set {
        txtLastName.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    /// <value>The phone.</value>
    public string Phone {
      get {
        return txtPhone.Text;
      }
      set {
        txtPhone.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email {
      get {
        return txtEmail.Text;
      }
      set {
        txtEmail.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the address1.
    /// </summary>
    /// <value>The address1.</value>
    public string Address1 {
      get {
        return txtAddress1.Text;
      }
      set {
        txtAddress1.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the address2.
    /// </summary>
    /// <value>The address2.</value>
    public string Address2 {
      get {
        return txtAddress2.Text;
      }
      set {
        txtAddress2.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>The city.</value>
    public string City {
      get {
        return txtCity.Text;
      }
      set {
        txtCity.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the state or region.
    /// </summary>
    /// <value>The state or region.</value>
    public string StateOrRegion {
      get {
        string stateOrRegion = string.Empty;
        switch (this.Country) {
          case "US"://Regardless of country, you can assign the collection to ddlStateOrRegion and then let this fall through
          case "CA":
            stateOrRegion = ddlStateOrRegion.SelectedValue;
            break;
          default:
            stateOrRegion = txtStateOrRegion.Text;
            break;
        }
        return stateOrRegion;
      }
      set {
        switch(this.Country) {
          case "US":
          case "CA":
            if (ddlStateOrRegion.Items.FindByValue(value) != null) {
              ddlStateOrRegion.ClearSelection();
              ddlStateOrRegion.Items.FindByValue(value).Selected = true;
            }
            break;
          default:
            txtStateOrRegion.Text = value;
            break;
        }
      }
    }

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>The postal code.</value>
    public string PostalCode {
      get {
        return txtPostalCode.Text;
      }
      set {
        txtPostalCode.Text = value;
      }
    }

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>The country.</value>
    public string Country {
      get {
        return ddlCountry.SelectedValue;
      }
      set {
        ListItem listItem = ddlCountry.Items.FindByValue(value);
        if(listItem != null) {
          ddlCountry.ClearSelection();
          ddlCountry.Items.FindByValue(value).Selected = true;
        }
      }
    }

    /// <summary>
    /// Gets or sets the selected address.
    /// </summary>
    /// <value>The selected address.</value>
    public string SelectedAddress {
      get {
        return _selectedAddress;
      }
      set {
        _selectedAddress = value;
      }
    }

    /// <summary>
    /// Gets or sets the type of the address.
    /// </summary>
    /// <value>The type of the address.</value>
    public AddressType AddressType {
      get {
        return _addressType;
      }
      set {
        _addressType = value;
      }
    }

    /// <summary>
    /// Gets the address list.
    /// </summary>
    /// <value>The address list.</value>
    public DropDownList AddressList {
      get {
        return ddlAddress;
      }
    }

    /// <summary>
    /// Gets the new address panel.
    /// </summary>
    /// <value>The new address panel.</value>
    public Panel NewAddressPanel {
      get {
        return pnlNewAddress;
      }
    }

    #endregion
    
  }
}