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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Web.controls;

//TODO: CMC - Need to break out the shared controls (MyAccount / Customer Information)
namespace MettleSystems.dashCommerce.Web.admin {
  public partial class customerinformation : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private Order _order = new Order();
    private WebProfile _user;
    private Product _product = new Product();

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e) {
      if (Request.QueryString.Get("edit") == "true") {
        tcMyAccount.ActiveTab = tpAddresses;
      }
      if (!IsPostBack) {
        LoadCustomers();
      }
      SetCustomerInformationProperties();
    }

    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(ddlCustomer.SelectedValue)) {
        _user = new WebProfile().GetProfile(ddlCustomer.SelectedValue);
        MembershipUser member = Membership.GetUser(_user.UserName);
        lblUserNameDisplay.Text = member.UserName;
        lblEmailDisplay.Text = member.Email;
        LoadOrders();
        LoadAddresses();
        LoadCountries();
        tcMyAccount.Visible = true;
      }
      else {
        tcMyAccount.Visible = false;
      }
    }

    void rptrBillingAddresses_ItemDataBound(object sender, RepeaterItemEventArgs e) {
      addressdisplay add = e.Item.FindControl("dcBillingAddress") as addressdisplay;
      if (add != null) {
        add.Address = e.Item.DataItem as Address;
        add.DataBind();
        add.DisplayAddress();
      }
    }

    void rptrShippingAddresses_ItemDataBound(object sender, RepeaterItemEventArgs e) {
      addressdisplay add = e.Item.FindControl("dcShippingAddress") as addressdisplay;
      if (add != null) {
        add.Address = e.Item.DataItem as Address;
        add.DataBind();
        add.DisplayAddress();
      }
    }

    void dgOrders_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        HyperLink editLink = e.Item.Cells[0].FindControl("hlEditLink") as HyperLink;
        if (editLink != null) {
          editLink.Text = LocalizationUtility.GetText("hlEditLink");
        }
      }
    }

    protected void lbChangePassword_Click(object sender, EventArgs e) {
      pnlUser.Visible = false;
      pnlMyOrders.Visible = false;
      pnlChangePassword.Visible = true;
      tcMyAccount.ActiveTab = tpUserInfo;
    }

    protected void lbChangeEmail_Click(object sender, EventArgs e) {
      pnlUser.Visible = false;
      pnlMyOrders.Visible = false;
      pnlChangeEmail.Visible = true;
      tcMyAccount.ActiveTab = tpUserInfo;
    }

    protected void btnEmailCancel_Click(object sender, EventArgs e) {
      pnlUser.Visible = true;
      pnlMyOrders.Visible = true;
      pnlChangeEmail.Visible = false;
      tcMyAccount.ActiveTab = tpUserInfo;
    }

    protected void HideChangePassword(object sender, EventArgs e) {
      pnlUser.Visible = true;
      pnlMyOrders.Visible = true;
      pnlChangePassword.Visible = false;
      tcMyAccount.ActiveTab = tpUserInfo;
    }

    protected void btnEmailSave_Click(object sender, EventArgs e) {
      if (Membership.ValidateUser(WebUtility.GetUserName(), txtPassword.Text)) {
        MembershipUser membershipUser = Membership.GetUser(WebUtility.GetUserName());
        membershipUser.Email = txtEmail.Text;
        Membership.UpdateUser(membershipUser);
        tcMyAccount.ActiveTab = tpUserInfo;
      }
    }

    protected void lbUpdateAddress_Click(object sender, EventArgs e) {
      _user = new WebProfile().GetProfile(ddlCustomer.SelectedValue);
      Address address = _user.AddressCollection.Find(delegate(Address addressToFind) {
        return addressToFind.AddressId == new Guid(hfAddressId.Value) &&
               addressToFind.AddressType == (AddressType)Enum.Parse(typeof(AddressType), hfAddressType.Value);
      });

      AddressType addressType = address.AddressType;
      _user.AddressCollection.Remove(address);
      _user.Save();

      address.FirstName = txtFirstName.Text;
      address.LastName = txtLastName.Text;
      address.Phone = txtPhone.Text;
      address.Email = txtEmailEdit.Text;
      address.Address1 = txtAddress1.Text;
      address.Address2 = txtAddress2.Text;
      address.City = txtCity.Text;
      address.StateOrRegion = ddlStateOrRegion.SelectedValue;
      address.Country = ddlCountry.SelectedValue;
      address.PostalCode = txtPostalCode.Text;
      address.UserName = WebUtility.GetUserName();
      address.AddressType = addressType;

      _user.AddressCollection.Add(address);
      _user.Save();

      LoadAddresses();
      pnlEditAddress.Visible = false;
      pnlBillingAddresses.Visible = true;
      pnlShippingAddresses.Visible = true;

      tcMyAccount.ActiveTab = tpAddresses;
    }

    protected void ddlCountry_Changed(object sender, EventArgs e) {
      LoadStateOrRegion(ddlCountry.SelectedValue);
    }

    protected void lbCancelAddressEdit_Click(object sender, EventArgs e) {
      pnlEditAddress.Visible = false;
      pnlBillingAddresses.Visible = true;
      pnlShippingAddresses.Visible = true;
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Formats the edit URL.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <returns></returns>
    protected string FormatEditUrl(string orderId) {
      return string.Format("orderedit.aspx?view=r&orderId={0}", orderId);
    }

    public void ShippingEdits(object s, RepeaterCommandEventArgs e) {
      Address address = new Address();
      Guid selectedAddress = new Guid(e.CommandArgument.ToString());
      _user = new WebProfile().GetProfile(ddlCustomer.SelectedValue);
      address = _user.AddressCollection.Find(delegate(Address addressToFind) {
        return addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.ShippingAddress;
      });

      if (address.AddressId != Guid.Empty) {
        if (e.CommandName == "Edit") {
          //Do the edit
          pnlBillingAddresses.Visible = false;
          pnlShippingAddresses.Visible = false;
          pnlEditAddress.Visible = true;
          LoadEditPanel(address);
          tcMyAccount.ActiveTab = tpAddresses;
        }
        if (e.CommandName == "Delete") {
          _user.AddressCollection.Remove(address);
          _user.Save();
          LoadAddresses();
          tcMyAccount.ActiveTab = tpAddresses;
        }
      }
    }

    public void BillingEdits(object s, RepeaterCommandEventArgs e) {
      Address address = new Address();
      Guid selectedAddress = new Guid(e.CommandArgument.ToString());
      _user = new WebProfile().GetProfile(ddlCustomer.SelectedValue);
      address = _user.AddressCollection.Find(delegate(Address addressToFind) {
        return addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.BillingAddress;
      });

      if (address.AddressId != Guid.Empty) {
        if (e.CommandName == "Edit") {
          //Do the edit
          pnlBillingAddresses.Visible = false;
          pnlShippingAddresses.Visible = false;
          pnlEditAddress.Visible = true;
          LoadEditPanel(address);
          tcMyAccount.ActiveTab = tpAddresses;
        }
        if (e.CommandName == "Delete") {
          _user.AddressCollection.Remove(address);
          _user.Save();
          LoadAddresses();
          tcMyAccount.ActiveTab = tpAddresses;
        }
      }
    }

    protected string GetFormattedAmount(string amount) {
      return StoreUtility.GetFormattedAmount(amount, true);
    }

    #endregion

    #region Private

    /// <summary>
    /// Loads the ddlCustomers drop down list
    /// </summary>
    private void LoadCustomers() {
      _user = new WebProfile().GetProfile(ddlCustomer.SelectedValue);
      ddlCustomer.DataSource = Membership.GetAllUsers();
      if (IsPostBack) {
        ddlCustomer.SelectedValue = _user.UserName;
      }
      ddlCustomer.DataBind();
      ddlCustomer.Items.Insert(0, "");
    }

    /// <summary>
    /// Loads the addresses.
    /// </summary>
    private void LoadAddresses() {
      AddressCollection billingAddresses = LoadAddresses(AddressType.BillingAddress);
      rptrBillingAddresses.DataSource = billingAddresses;
      rptrBillingAddresses.ItemDataBound += new RepeaterItemEventHandler(rptrBillingAddresses_ItemDataBound);
      rptrBillingAddresses.DataBind();

      AddressCollection shippingAddresses = LoadAddresses(AddressType.ShippingAddress);
      rptrShippingAddresses.DataSource = shippingAddresses;
      rptrShippingAddresses.ItemDataBound += new RepeaterItemEventHandler(rptrShippingAddresses_ItemDataBound);
      rptrShippingAddresses.DataBind();
    }

    /// <summary>
    /// Loads the addresses.
    /// </summary>
    /// <param name="addressType">Type of the address.</param>
    /// <returns></returns>
    private AddressCollection LoadAddresses(AddressType addressType) {
      List<Address> addressList = _user.AddressCollection.FindAll(delegate(Address address) {
        return address.AddressType == addressType;
      });
      AddressCollection addressCollection = new AddressCollection();
      addressCollection.AddRange(addressList);
      return addressCollection;
    }

    /// <summary>
    /// Loads the orders.
    /// </summary>
    private void LoadOrders() {
      OrderCollection orderCollection = new OrderController().FetchOrdersForUser(ddlCustomer.SelectedValue);
      orderCollection.Sort(Order.Columns.CreatedOn, false);
      dgOrders.DataSource = orderCollection;
      dgOrders.ItemDataBound += new DataGridItemEventHandler(dgOrders_ItemDataBound);
      dgOrders.Columns[0].HeaderText = LocalizationUtility.GetText("hdrDetails");
      dgOrders.Columns[1].HeaderText = LocalizationUtility.GetText("hdrOrderNumber");
      dgOrders.Columns[2].HeaderText = LocalizationUtility.GetText("hdrTotal");
      dgOrders.Columns[3].HeaderText = LocalizationUtility.GetText("hdrStatus");
      dgOrders.Columns[4].HeaderText = LocalizationUtility.GetText("hdrOrderDate");
      dgOrders.DataBind();
    }

    /// <summary>
    /// Loads the edit panel.
    /// </summary>
    /// <param name="address">The address.</param>
    private void LoadEditPanel(Address address) {
      hfAddressId.Value = address.AddressId.ToString();
      hfAddressType.Value = address.AddressType.ToString();
      txtFirstName.Text = address.FirstName;
      txtLastName.Text = address.LastName;
      txtPhone.Text = address.Phone;
      txtEmailEdit.Text = address.Email;
      txtAddress1.Text = address.Address1;
      txtAddress2.Text = address.Address2;
      txtCity.Text = address.City;
      txtPostalCode.Text = address.PostalCode;
      ddlCountry.SelectedValue = address.Country;
      LoadStateOrRegion(address.Country);
      ddlStateOrRegion.SelectedValue = address.StateOrRegion;
    }

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
    /// Loads the countries.
    /// </summary>
    private void LoadCountries() {
      CountryController countryController = new CountryController();
      CountryCollection countryCollection = countryController.FetchAll();

      ddlCountry.DataSource = countryCollection;
      ddlCountry.DataTextField = "Name";
      ddlCountry.DataValueField = "Code";
      ddlCountry.DataBind();
    }

    private void SetCustomerInformationProperties() {
      cvEmailAddresses.ErrorMessage = LocalizationUtility.GetText("lblEmailAddressesDoNotMatch");
      Page.Title = LocalizationUtility.GetText("titleSalesCustomerInformation");
    }



    #endregion

    #endregion

  }
}
