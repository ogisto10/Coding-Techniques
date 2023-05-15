using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_DevSi
{
    public static class data
    {
        public static string dbcon()
        {
            string stringCon = " Server = localhost ; Database = codification ; Uid = root ; pwd = '' ";
            return stringCon;
        }


    }
}
