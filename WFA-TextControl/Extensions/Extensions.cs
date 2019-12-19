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
        public static bool SetDisableCheckBox(this object data, object option = null)
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
        public static void ClearCheckBoxAllGruopBox(this object data, object control)
        {
            if (!IsNullOrEmpty(data))
            {
                var _checkbox = (CheckBox)data;
                if (!IsNullOrEmpty(control))
                {
                    /*clear all checkbox control not mine*/
                    var _gbox = (GroupBox)control;

                    foreach (Control c in _gbox.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox _ckb = (CheckBox)c;
                            if (_ckb.Name != _checkbox.Name)
                            {
                                if (_ckb.Checked == true)
                                {
                                    _ckb.Checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ClearCheckBox(this object data, object checkbox)
        {
            if (!IsNullOrEmpty(data))
            {
                var _checkbox = (CheckBox)data;
                if (!IsNullOrEmpty(checkbox))
                {
                    /*clear checkbox control not mine*/
                    var _ckb = (CheckBox)checkbox;

                    if (_checkbox.Checked)
                        _ckb.Checked = false;
                }
            }
        }
        public static void SetDefualtCheck(this object data)
        {
            if (!IsNullOrEmpty(data))
            {
                var _checkbox = (CheckBox)data;
                _checkbox.Checked = true;
            }
        }
    }
}

class Helper
{
    public static void ClearGruopBox(object control)
    {
        /*clear control*/
        var _gbox = (GroupBox)control;

        foreach (Control c in _gbox.Controls)
        {
            if (c is CheckBox)
            {
                CheckBox _ckb = (CheckBox)c;
                _ckb.Checked = false;
            }
            else if (c is TextBox)
            {
                TextBox _ckb = (TextBox)c;
                _ckb.Text = string.Empty;
            }
        }
    }

}