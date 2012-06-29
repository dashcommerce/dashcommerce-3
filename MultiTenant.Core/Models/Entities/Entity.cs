using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Validator.Engine;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MettleSystems.MultiTenant.Core.Models.Entities {

  public abstract class Entity<T> {

    private IEnumerable<InvalidValue> _invalidValues;

    public virtual IEnumerable<InvalidValue> InvalidValues {
      get {
        return _invalidValues;
      }
      private set {
        _invalidValues = value;
      }
    }

    public virtual bool IsValid() {
      bool isValid = false;
      Validate();
      if(InvalidValues.Count() == 0){
        isValid = true;
      }
      return isValid;
    }

    public virtual void Validate(){
      IClassValidator classValidator = GetClassValidator(typeof(T), new ResourceManager("MettleSystems.MultiTenant.Core.Validation.Messages", Assembly.GetExecutingAssembly()), Thread.CurrentThread.CurrentCulture);
      InvalidValues = classValidator.GetInvalidValues(this);
    }

    public virtual IClassValidator GetClassValidator(System.Type type, ResourceManager resource, CultureInfo culture) {
			return new ClassValidator(type, resource, culture, ValidatorMode.UseAttribute);
		}

  }
}
