using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_TextControl.Extensions
{
    public static class Extensions
    {
        public static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        public static bool IsNullOrEmpty(this object data)
        {
            return string.IsNullOrEmpty(Convert.ToString(data));
        }
        public static bool SetCheckBox(this object data, object option = null)
        {
            if (!IsNullOrEmpty(data))
            {
                var _checkbox = (CheckBox)data;
                if (!IsNullOrEmpty(option))
                {
                    /*set disable checkbok follow option*/
                    var _opckb = (CheckBox)option;

                    if (_checkbox.Enabled)
                    {
                        _checkbox.Checked = false;
                        return _checkbox.Enabled = false;
                    }
                    else
                    {
                        return _checkbox.Enabled = true;
                    }
                }

                /*set defualt checkbok if option is null*/
                if (_checkbox.Enabled)
                    return _checkbox.Enabled = false;
                else
                    return _checkbox.Enabled = true;
            }            

            return string.IsNullOrEmpty(Convert.ToString(data));
        }
    }
}
