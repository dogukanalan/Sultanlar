using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class DepartmanProvider
    {
        internal List<departmanlar> Departmanlar() => new departmanlar().GetObjects(true);

        internal departmanlar Departman(byte DepartmanID) => new departmanlar(DepartmanID).GetObject();
    }
}
