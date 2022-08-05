using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKomsu" in both code and config file together.
    [ServiceContract]
    public interface IKomsu
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        Komsu001.ZwebKomsuS_001[] komsu001(string Matnr);

        [OperationContract]
        Komsu002.ZwebKomsuS_002[] komsu002(string Matnr);

        [OperationContract]
        Komsu003.ZwebKomsuS_003[] komsu003(string Matnr);

        [OperationContract]
        Komsu004.ZwebKomsuS_004[] komsu004(string Matnr, Komsu004.Werks Werks);
    }
}
