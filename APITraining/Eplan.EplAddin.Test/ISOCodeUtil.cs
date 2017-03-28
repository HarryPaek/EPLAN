using Eplan.EplApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.EplAddin.Test
{
    public class ISOCodeUtil
    {
        public static string GetISOStringValue(MultiLangString multiLangString)
        {
            string sLang = "ko_KR";

            ISOCode isoCode = new ISOCode(sLang);
            ISOCode.Language language = isoCode.GetNumber();
            string value = multiLangString.GetString(language);


            return value.Trim();
        }
    }
}
