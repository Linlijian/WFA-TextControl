using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_TextControl.Extensions
{
    [Serializable]
    public class baseDTO
    {
        public baseDTO()
        {
            Model = new SplitModel();
        }
        public SplitModel Model { get; set; }
    }
    public class ExampleType
    {
        public const string Example = "Example";

        public const string SingleText = "SingleText";
        public const string Parameter = "Parameter";

        public const string NomalField = "NomalField";
        public const string DBField = "DBField";

        public const string Concut = "Concut";

        public const string LinkReport = "LinkReport";

        public const string DDLInspect = "DDLInspect";

    }
}
