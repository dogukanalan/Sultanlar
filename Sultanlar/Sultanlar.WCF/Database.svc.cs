using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;

namespace Sultanlar.WCF
{
    public class Database : IDatabase
    {
        public List<SatisTemsilcileri> SaticilarGet()
        {
            return SatisTemsilcileri.GetObjects();
        }
    }
}
