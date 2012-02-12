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

using MettleSystems.dashCommerce.Core.Serialization;

namespace MettleSystems.dashCommerce.Store {

  public partial class AddressCollection : List<Address> {
  
  }

  public partial class Address {

    #region Member Variables

    private string _firstName;
    private string _lastName;
    private string _phone;
    private string _email;
    private string _address1;
    private string _address2;
    private string _city;
    private string _stateOrRegion;
    private string _postalCode;
    private string _country;
    private string _userName;
    private Guid _addressId;
    private AddressType _addressType;
    private DateTime _lastSaved;

    #endregion
    
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Address"/> class.
    /// </summary>
    public Address() {
      _addressId = Guid.NewGuid();
    }

    //Copy Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Address"/> class.
    /// </summary>
    /// <param name="address">The address.</param>
    public Address(Address address) {
      this.AddressId = address.AddressId;
      this.FirstName = address.FirstName;
      this.LastName = address.LastName;
      this.Phone = address.Phone;
      this.Email = address.Email;
      this.Address1 = address.Address1;
      this.Address2 = address.Address2;
      this.City = address.City;
      this.StateOrRegion = address.StateOrRegion;
      this.PostalCode = address.PostalCode;
      this.Country = address.Country;
    }
    
    #endregion

    #region Properties

    public Guid AddressId {
      get {
        return _addressId;
      }
      set {
        _addressId = value;
      }
    }

    public string UserName {
      get {
        return _userName;
      }
      set {
        _userName = value;
      }
    }

    public string FirstName {
      get {
        return _firstName;
      }
      set {
        _firstName = value;
      }
    }

    public string LastName {
      get {
        return _lastName;
      }
      set {
        _lastName = value;
      }
    }

    public string Phone {
      get {
        return _phone;
      }
      set {
        _phone = value;
      }
    }

    public string Email {
      get {
        return _email;
      }
      set {
        _email = value;
      }
    }

    public string Address1 {
      get {
        return _address1;
      }
      set {
        _address1 = value;
      }
    }

    public string Address2 {
      get {
        return _address2;
      }
      set {
        _address2 = value;
      }
    }

    public string City {
      get {
        return _city;
      }
      set {
        _city = value;
      }
    }

    public string StateOrRegion {
      get {
        return _stateOrRegion;
      }
      set {
        _stateOrRegion = value;
      }
    }

    public string PostalCode {
      get {
        return _postalCode;
      }
      set {
        _postalCode = value;
      }
    }

    public string Country {
      get {
        return _country;
      }
      set {
        _country = value;
      }
    }

    public string FullAddress {
      get {
        return this.ToHtmlString();
      }
    }

    public AddressType AddressType {
      get {
        return _addressType;
      }
      set {
        _addressType = value;
      }
    }

    public DateTime LastSaved {
      get {
        return _lastSaved;
      }
      set {
        _lastSaved = value;
      }
    }

    #endregion

    #region ToString() Override
    /// <summary>
    /// Override the base ToString() so that it will format nicely for a web-page
    /// </summary>
    /// <returns></returns>
    public override string ToString() {

      string sOut = FirstName + " " + LastName + "\r\n" +
          Address1 + "\r\n";
      if(!String.IsNullOrEmpty(Address2)) {
        sOut += Address2 + "\r\n";
      }
      sOut += City + ", " + StateOrRegion + "  " + PostalCode + " " + Country;
      return sOut;
    }

    public string ToHtmlString() {
      string sOut = "<table>";
      sOut += "<tr><td><b>" + FirstName + " " + LastName + "</b></td></tr>" +
          "<tr><td>" + Address1 + "</td></tr>";
      if(!String.IsNullOrEmpty(Address2)) {
        sOut += "<tr><td>" + Address2 + "</td></tr>";
      }
      sOut += "<tr><td>" + City + ", " + StateOrRegion + "  " + PostalCode + " " + Country + "</td></tr>";
      sOut += "<tr><td>" + Phone + "</td></tr>";
      sOut += "<tr><td>" + Email + "</td></tr>";
      sOut += "</table>";
      return sOut;
    }

    #endregion

    #region Comparisons

    public bool Equals(Address compareAddress) {
      bool bOut = false;
      if(compareAddress != null) {
        //if the first, last, address1, city, state, etc are equal return true
        if(compareAddress.FirstName.ToLower().Equals(this.FirstName.ToLower()) &&
            compareAddress.LastName.ToLower().Equals(this.LastName.ToLower()) &&
            compareAddress.Address1.ToLower().Equals(this.Address1.ToLower()) &&
            compareAddress.City.ToLower().Equals(this.City.ToLower()) &&
            compareAddress.StateOrRegion.ToLower().Equals(this.StateOrRegion.ToLower()) &&
            compareAddress.Country.ToLower().Equals(this.Country.ToLower())
            ) {
          bOut = true;
        }
      }
      return bOut;
    }

    #endregion
    
    #region Serialization Methods

    /// <summary>
    /// News from XML.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <returns></returns>
    public object NewFromXml(string xml) {
      Serializer serializer = new Serializer();
      return serializer.DeserializeObject(xml, typeof(Address).AssemblyQualifiedName);
    }

    /// <summary>
    /// Toes the XML.
    /// </summary>
    /// <returns></returns>
    public string ToXml() {
      Serializer serializer = new Serializer();
      this.LastSaved = DateTime.UtcNow;
      return serializer.SerializeObject(this, typeof(Address));
    }
    
    #endregion

  }
}
