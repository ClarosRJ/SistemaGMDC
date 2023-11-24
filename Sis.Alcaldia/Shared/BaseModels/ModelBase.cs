using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cpa.Alcadia.Shared.BaseModels
{
  
    public enum ModelMode
    {
        Browse,
        Insert,
        Update,
        Delete,
        Select
    }
    public abstract class ModelBase
    {
        public ModelMode Mode { get; set; } = ModelMode.Browse;
        //private string _action = string.Empty;
        //public string GetAction() => _action;
        //public void SetAction(string action) => _action = action;

        #region Delegates y Events
        //public delegate void FieldChangedHandler(string fieldName, ModelBase model);
        //public delegate void SearchClickHandler(string fieldName, ModelBase model);
        //public delegate void ApplyFilterHandler(string fieldName, string fieldFilter);
        //public event FieldChangedHandler FieldChanged;
        //public event SearchClickHandler SearchClick;
        //public event ApplyFilterHandler ApplyFilter;
        //public void NotifyFieldChanged(string fieldName, ModelBase model)
        //{
        //    this.FieldChanged?.Invoke(fieldName, model);
        //}
        //public void NotifySearchClick(string fieldName, ModelBase model)
        //{
        //    this.SearchClick?.Invoke(fieldName, model);
        //}
        //public void NotifyApplyFilter(string fieldName, string fieldFilter)
        //{
        //    this.ApplyFilter?.Invoke(fieldName, fieldFilter);
        //}
        #endregion

        public bool NeedValidate()
        {
            if (this.Mode != ModelMode.Browse && this.Mode != ModelMode.Select)
                return true;
            else
                return false;
        }

        public object GetValue(string fieldName)
        {
            var propertyInfo = this.GetType().GetProperty(fieldName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(this);
                return value;
            }
            return null;
        }

        public PropertyInfo GetField(string fieldName)
        {
            var propertyInfo = this.GetType().GetProperty(fieldName);
            if (propertyInfo != null)
            {
                return propertyInfo;
            }
            return null;
        }

        public void SetValue(string fieldName, object value)
        {
            var propertyInfo = this.GetType().GetProperty(fieldName);
            propertyInfo.SetValue(this, value);
        }

        private IDictionary<string, dynamic> _metadata { get; set; } = new Dictionary<string, dynamic>();
        public virtual IDictionary<string, dynamic> GetMetadata()
        {
            return _metadata;
        }

        public void UpdateMetadata(IDictionary<string, dynamic> metadata)
        {
            foreach (var row in metadata)
            {
                _metadata[row.Key] = row.Value;
            }
        }

    }
}
