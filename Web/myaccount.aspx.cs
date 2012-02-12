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
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Web.controls;


namespace MettleSystems.dashCommerce.Web {
  public partial class myaccount : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables

    MembershipUser membershipUser = null;

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e) {
      if (!Page.User.Identity.IsAuthenticated) {
        Response.Redirect(string.Format("login.aspx?ReturnUrl={0}", Request.Url), true);
      }
      membershipUser = Membership.GetUser(WebUtility.GetUserName());
      lblUserNameDisplay.Text = membershipUser.UserName;
      lblEmailDisplay.Text = membershipUser.Email;
      if (!Page.IsPostBack) {
        LoadOrders();
        LoadAddresses();
        LoadCountries();
        LoadDownloads();

        if (Request.QueryString.Get("edit") == "true") {
          tcMyAccount.ActiveTab = tpAddresses;
        }
      }

      SetMyAccountProperties();
    }

    void rptrBillingAddresses_ItemDataBound(object sender, RepeaterItemEventArgs e) {
      addressdisplay add = e.Item.FindControl("dcBillingAddress") as addressdisplay;
      if (add != null) {
        add.Address = e.Item.DataItem as Address;
      }
    }

    void rptrShippingAddresses_ItemDataBound(object sender, RepeaterItemEventArgs e) {
      addressdisplay add = e.Item.FindControl("dcShippingAddress") as addressdisplay;
      if (add != null) {
        add.Address = e.Item.DataItem as Address;
      }
    }

    void dgOrders_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton lbView = e.Item.FindControl("lbView") as LinkButton;
        if (lbView != null) {
          lbView.Text = LocalizationUtility.GetText("lblDetails");
        }
      }
    }

    protected void lbChangePassword_Click(object sender, EventArgs e) {
      pnlUser.Visible = false;
      pnlMyOrders.Visible = false;
      pnlChangePassword.Visible = true;
    }

    protected void lbChangeEmail_Click(object sender, EventArgs e) {
      pnlUser.Visible = false;
      pnlMyOrders.Visible = false;
      pnlChangeEmail.Visible = true;
    }

    protected void btnEmailCancel_Click(object sender, EventArgs e) {
      pnlUser.Visible = true;
      pnlMyOrders.Visible = true;
      pnlChangeEmail.Visible = false;
    }

    protected void HideChangePassword(object sender, EventArgs e) {
      pnlUser.Visible = true;
      pnlMyOrders.Visible = true;
      pnlChangePassword.Visible = false;
    }

    protected void btnEmailSave_Click(object sender, EventArgs e) {
      if (Membership.ValidateUser(WebUtility.GetUserName(), txtPassword.Text)) {
        MembershipUser membershipUser = Membership.GetUser(WebUtility.GetUserName());
        membershipUser.Email = txtEmail.Text;
        Membership.UpdateUser(membershipUser);
        Response.Redirect("myaccount.aspx", true);
      }
    }

    protected void lbUpdateAddress_Click(object sender, EventArgs e) {
      Address address = WebProfile.Current.AddressCollection.Find(delegate(Address addressToFind) {
        return addressToFind.AddressId == new Guid(hfAddressId.Value) && addressToFind.AddressType == (AddressType)Enum.Parse(typeof(AddressType), hfAddressType.Value);
      });

      //AddressType addressType = address.AddressType;
      int addressIndex = WebProfile.Current.AddressCollection.FindIndex(delegate(Address addressToFind) {
        return addressToFind.AddressId == new Guid(hfAddressId.Value) && addressToFind.AddressType == (AddressType)Enum.Parse(typeof(AddressType), hfAddressType.Value);
      });
      WebProfile.Current.AddressCollection.RemoveAt(addressIndex);
      //WebProfile.Current.AddressCollection.Remove(address);
      WebProfile.Current.Save();

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
      address.AddressType = address.AddressType;

      WebProfile.Current.AddressCollection.Add(address);
      WebProfile.Current.Save();

      Response.Redirect("myaccount.aspx?edit=true");
    }

    protected void ddlCountry_Changed(object sender, EventArgs e) {
      LoadStateOrRegion(ddlCountry.SelectedValue);
    }

    protected void lbView_Click(object sender, CommandEventArgs e) {
      Response.Redirect(string.Format("receipt.aspx?oid={0}", e.CommandArgument.ToString()), true);
    }

    protected void lbCancelAddressEdit_Click(object sender, EventArgs e) {
      pnlEditAddress.Visible = false;
      pnlBillingAddresses.Visible = true;
      pnlShippingAddresses.Visible = true;
    }

    #endregion

    #region methods

    #region public

    public void ShippingEdits(object s, RepeaterCommandEventArgs e) {
      Address address = new Address();
      Guid selectedAddress = new Guid(e.CommandArgument.ToString());
      address = WebProfile.Current.AddressCollection.Find(delegate(Address addressToFind) {
        return addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.ShippingAddress;
      });

      if (address.AddressId != Guid.Empty) {
        if (e.CommandName == "Edit") {
          //Do the edit
          pnlBillingAddresses.Visible = false;
          pnlShippingAddresses.Visible = false;
          pnlEditAddress.Visible = true;
          LoadEditPanel(address);
        }
        if (e.CommandName == "Delete") {
          WebProfile.Current.AddressCollection.Remove(address);
          WebProfile.Current.Save();
          Response.Redirect("myaccount.aspx?edit=true");
        }
      }
    }

    public void BillingEdits(object s, RepeaterCommandEventArgs e) {
      Address address = new Address();
      Guid selectedAddress = new Guid(e.CommandArgument.ToString());
      address = WebProfile.Current.AddressCollection.Find(delegate(Address addressToFind) {
        return addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.BillingAddress;
      });

      if (address.AddressId != Guid.Empty) {
        if (e.CommandName == "Edit") {
          //Do the edit
          pnlBillingAddresses.Visible = false;
          pnlShippingAddresses.Visible = false;
          pnlEditAddress.Visible = true;
          LoadEditPanel(address);
        }
        if (e.CommandName == "Delete") {
          WebProfile.Current.AddressCollection.Remove(address);
          WebProfile.Current.Save();
          Response.Redirect("myaccount.aspx?edit=true");
        }
      }
    }

    protected string GetFormattedAmount(string amount) {
      return StoreUtility.GetFormattedAmount(amount, true);
    }

    #endregion

    #region private

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

    private AddressCollection LoadAddresses(AddressType addressType) {
      List<Address> addressList = WebProfile.Current.AddressCollection.FindAll(delegate(Address address) {
        return address.AddressType == addressType;
      });
      AddressCollection addressCollection = new AddressCollection();
      addressCollection.AddRange(addressList);
      return addressCollection;
    }

    private void LoadOrders() {
      OrderCollection orderCollection = new OrderController().FetchOrdersForUser(WebUtility.GetUserName());
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
    /// Loads the downloads.
    /// </summary>
    private void LoadDownloads() {
      Guid userGuid = new Guid(membershipUser.ProviderUserKey.ToString());
      DownloadCollection downloadCollection = new DownloadController().FetchPurchasedDownloadsByUserId(userGuid);
      if (downloadCollection.Count > 0) {
        dlFiles.DataSource = downloadCollection;
        dlFiles.ItemDataBound += new DataListItemEventHandler(dlFiles_ItemDataBound);
        dlFiles.DataBind();
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dlFiles control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataListItemEventArgs"/> instance containing the event data.</param>
    void dlFiles_ItemDataBound(object sender, DataListItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        Download download = e.Item.DataItem as Download;
        HyperLink hlDownload = e.Item.FindControl("hlDownload") as HyperLink;
        System.Web.UI.WebControls.Image imgIcon = e.Item.FindControl("imgIcon") as System.Web.UI.WebControls.Image;

        if (hlDownload != null) {
          hlDownload.Text = download.Title;
          hlDownload.NavigateUrl = string.Format("~/download.ashx?did={0}", download.DownloadId);
        }
        if (imgIcon != null) {
          imgIcon.ImageUrl = string.Format("~/App_Themes/dashCommerce/images/icons/{0}.gif", DownloadController.GetFileTypeIcon(Path.GetExtension(download.DownloadFile)));
        }

      }
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

    private void LoadCountries() {
      CountryController countryController = new CountryController();
      CountryCollection countryCollection = countryController.FetchAll();

      ddlCountry.DataSource = countryCollection;
      ddlCountry.DataTextField = "Name";
      ddlCountry.DataValueField = "Code";
      ddlCountry.DataBind();
    }

    private void SetMyAccountProperties() {
      btnEmailCancel.Text = LocalizationUtility.GetText("lblCancel");
      btnEmailSave.Text = LocalizationUtility.GetText("btnSave");
      lblPasswordChange.Text = LocalizationUtility.GetText("lblPassword");
      lblEmailChange.Text = LocalizationUtility.GetText("lblEmail");
      lblEmailConfirmation.Text = LocalizationUtility.GetText("lblEmailConfirmation");
      cvEmailAddresses.ErrorMessage = LocalizationUtility.GetText("lblEmailAddressesDoNotMatch");
      Page.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, LocalizationUtility.GetText("lblMyAccount"));
    }

    #endregion


    #endregion

  }
}
