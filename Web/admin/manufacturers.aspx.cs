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
using System.Web;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class manufacturers : MettleSystems.dashCommerce.Store.Web.AdminPage {
  
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load (object sender, EventArgs e) {
      try {
        SetManufacturersProperties();
        LoadManufacturers();
      }
      catch (Exception ex) {
        Logger.Error(typeof(manufacturers).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click (object sender, CommandEventArgs e) {
      try {
        Manufacturer manufacturer;
        int manufacturerId = 0;
        int.TryParse(e.CommandArgument.ToString(), out manufacturerId);
        if (manufacturerId > 0) {
          manufacturer = new Manufacturer(manufacturerId);
          ProductCollection productCollection = new ProductCollection().Where(Product.Columns.ManufacturerId, Comparison.Equals, manufacturerId).Load();
          if (productCollection.Count > 0) {
            Master.MessageCenter.DisplayFailureMessage(string.Format(LocalizationUtility.GetText("lblUnableToDeleteManufacturers"), manufacturer.Name));
          }
          else {
            Manufacturer.Delete(manufacturerId);
            LoadManufacturers();
            Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblManufacturerDeleted"));
          }
        }
      }
      catch (HttpException) {
        try {
          if(dgManufacturers.PageCount > 1) {
            dgManufacturers.CurrentPageIndex = dgManufacturers.CurrentPageIndex - 1;
          }
          else {
            dgManufacturers.CurrentPageIndex = 0;
          }
          dgManufacturers.DataBind();
          Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblManufacturerDeleted"));
        }
        catch (Exception exe) {
          Logger.Error(typeof(manufacturers).Name + ".lbDelete_Click", exe);
          Master.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(exe.Message));
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(manufacturers).Name + ".lbDelete_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click (object sender, EventArgs e) {
      try {
        Manufacturer manufacturer = new Manufacturer();
        manufacturer.Name = txtName.Text;
        manufacturer.Save(WebUtility.GetUserName());
        Reset();
        LoadManufacturers();
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblManufacturerSaved"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(manufacturers).Name + ".btnSave_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }
    
    /// <summary>
    /// Handles the PageIndexChanging event of the dgManufacturer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridPageChangedEventArgs"/> instance containing the event data.</param>
    protected void dgManufacturer_PageIndexChanging (object sender, DataGridPageChangedEventArgs e) {
      dgManufacturers.CurrentPageIndex = e.NewPageIndex;
      dgManufacturers.DataBind();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgManufacturers control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgManufacturers_ItemDataBound (object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[0].FindControl("lbDelete") as LinkButton;
        if (deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }

    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the manufacturers properties.
    /// </summary>
    private void SetManufacturersProperties () {
      this.Title = LocalizationUtility.GetText("titleProductManufacturers");
    }

    /// <summary>
    /// Loads the manufacturers.
    /// </summary>
    private void LoadManufacturers () {
      ManufacturerCollection manufacturerCollection = new ManufacturerController().FetchAll();
      if (manufacturerCollection.Count > 0) {
        dgManufacturers.DataSource = manufacturerCollection;
        dgManufacturers.ItemDataBound += new DataGridItemEventHandler(dgManufacturers_ItemDataBound);
        dgManufacturers.Columns[0].HeaderText = LocalizationUtility.GetText("hdrDelete");
        dgManufacturers.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
        dgManufacturers.DataBind();
      }
    }

    /// <summary>
    /// Resets this instance.
    /// </summary>
    private void Reset () {
      txtName.Text = string.Empty;
    }
    
    #endregion
    
    #endregion
    
  }
}
