﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_TextControl.Extensions
{
    public class ExampleModel
    {
        private string _header = string.Empty;
        public string ExHeader
        {
            get { return _header; }
            set { _header = value; }
        }

        private string _title = string.Empty;
        public string ExTitle
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _body = string.Empty;
        public string ExBody
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _footer = string.Empty;
        public string ExFooter
        {
            get { return _footer; }
            set { _footer = value; }
        }

        private string _type = string.Empty;
        public string ExType
        {
            get { return _type; }
            set { _type = value; }
        }
    }

    public class ExampleType
    {
        public const string Example = "Example";

        public const string SingleText = "SingleText";
        public const string Parameter = "Parameter";

        public const string NomalField = "NomalField";
        public const string DBField = "DBField";

    }

}