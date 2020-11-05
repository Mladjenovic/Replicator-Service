using Global_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Data.Services
{
    public class GetDataSet
    {
        public static int GetDatasetForCode(Code code1, Code code2)
        {
            if (code1 == Code.CODE_ANALOG && code2 == Code.CODE_DIGITAL)
                return 1;
            else if (code1 == Code.CODE_CUSTOM && code2 == Code.CODE_LIMITSET)
                return 2;
            else if (code1 == Code.CODE_SINGLENODE && code2 == Code.CODE_MULTIPLENODE)
                return 3;
            else if (code1 == Code.CODE_CONSUMER && code2 == Code.CODE_SOURCE)
                return 4;
            else
                return 0;
        }
    }
}
