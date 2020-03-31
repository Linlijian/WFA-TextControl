using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_TextControl.Extensions
{
    public class baseDA
    {
        private baseDTO _DTO = null;
        public baseDTO DTO
        {
            get
            {
                if (_DTO == null)
                {
                    _DTO = new baseDTO();
                }
                return _DTO;
            }
        }

        protected virtual baseDTO DoSetting(baseDTO DTO)
        {
            return DTO;
        }

        public baseDTO Setting(baseDTO dto)
        {
            switch (dto.Model.ExecuteType)
            {
                case ExampleType.DDLInspect:
                    return DDLInspect(dto);
                case ExampleType.SingleText:
                    return SingleText(dto);
                case ExampleType.Parameter:
                    return Parameter(dto);
                case ExampleType.LinkReport:
                    return LinkReport(dto);
                case ExampleType.Concut:
                    return Concut(dto);
                case ExampleType.ConcutA:
                    return ConcutA(dto);
            }

            return dto;
        }
        private baseDTO DDLInspect(baseDTO dto)
        {
            dto.Model.FirstLoop = true;
            dto.Model.TextArea = dto.Model.StringText.Replace("<option value=\"", "@").Replace(">", "@").Replace("</option", "Q").Split('@');
            dto.Model.TextFindAll = Array.FindAll(dto.Model.TextArea, element => element.EndsWith("Q", StringComparison.Ordinal));
            //vales
            //model.FirstLoop = true;
            //model.StringText = txtDDLFrom.Text;
            //model.TextArea = model.StringText.Replace("\r\n", "").Replace("value=\"", "@").Replace(">", "\r\n").Replace("\"", "@\r\n").Split(null);
            //model.TextFindAll = Array.FindAll(model.TextArea, element => element.StartsWith("@", StringComparison.Ordinal));

            return dto;
        }
        private baseDTO SingleText(baseDTO dto)
        {
            dto.Model.FirstLoop = true;
            dto.Model.TextArea = dto.Model.StringText.Replace("\r\n", "").Replace(",", "").Split(null);
            dto.Model.TextFindAll = Array.FindAll(dto.Model.TextArea, element => element.StartsWith("@", StringComparison.Ordinal));

            return dto;
        }
        private baseDTO Parameter(baseDTO dto)
        {
            dto.Model.FirstLoop = true;
            if (dto.Model.OutputCase == 1)
            {
                dto.Model.TextArea = dto.Model.StringText.Replace("\r\n", " ").Split(null);
                dto.Model.TextFindAll = dto.Model.TextArea;
            }
            else
            {
                dto.Model.TextArea = dto.Model.StringText.Replace("\r\n", "").Replace(",", "").Replace("[", "").Replace("]", "").Split(null);
                dto.Model.TextFindAll = dto.Model.TextArea.Where(a => !a.IsNullOrEmpty()).ToArray();
            }

            return dto;
        }
        private baseDTO Concut(baseDTO dto)
        {
            dto.Model.FirstLoop = true;
            dto.Model.TextArea = dto.Model.StringText.Replace("\r\n", "").Replace("\t", "").Replace(",", "").Replace("[", "").Replace("]", "").Split(null);
            dto.Model.TextFindAll = dto.Model.StringText.Replace("\r\n", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("\t", "")
                .Split(dto.Model.spearator, StringSplitOptions.RemoveEmptyEntries);
            return dto;
        }
        private baseDTO ConcutA(baseDTO dto)
        {
            dto.Model.FirstLoop = true;
            dto.Model.TextArea = dto.Model.StringText.Replace("\r\n", " ").Split(null);
            dto.Model.TextFindAll = dto.Model.TextArea;
            return dto;
        }
        private baseDTO LinkReport(baseDTO dto)
        {
            dto.Model.FirstLoop = true;
            dto.Model.TextArea = dto.Model.StringText.Split(dto.Model.spearator_report_p, StringSplitOptions.RemoveEmptyEntries);
            if (dto.Model.TextArea.Count() > 0)
            {
                dto.Model.TextFindAll = dto.Model.TextArea[1]
                                        .Replace(dto.Model.persen20, "")
                                        .Split(dto.Model.operator_and, StringSplitOptions.RemoveEmptyEntries);
            }
            return dto;
        }

    }
}
