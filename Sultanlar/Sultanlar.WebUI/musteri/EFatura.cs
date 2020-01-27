using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sultanlar.WebUI.musteri
{
    public class EFatura : IDisposable
    {
        // Alanlar
        public string _LT;
        public string _BOLGE;
        public string _GRP;
        public string _EKP;
        public string _ABRNO;
        public string _AMBAR;
        public string _AY;
        public string _HAFTA;
        public string _FATTAR;
        public string _FATNO;
        public string _FATVD;
        public string _TUR;
        public string _TURACK;
        public string _FTUR;
        public string _SLSREF;
        public string _SATKOD;
        public string _SATTEM;
        public string _TEDEKP;
        public string _TEDSLSREF;
        public string _TEDSATTEM;
        public string _IL;
        public string _ILCE;
        public string _MTACIKLAMA;
        public string _GMREF;
        public string _MUSKOD;
        public string _MUSTERI;
        public string _SMREF;
        public string _SUBKOD;
        public string _SUBE;
        public string _SEVKKOD;
        public string _SEVKADRES;
        public string _REYKOD;
        public string _REYON;
        public string _ANAGRP;
        public string _GRPKOD;
        public string _GRUP;
        public string _TEDGRP;
        public string _TEDKISAMAL;
        public string _BARCODE;
        public string _ITEMREF;
        public string _MALKOD;
        public string _MALZEME;
        public string _KOLI;
        public string _KDV;
        public string _BRM;
        public string _ADT;
        public string _ISK1;
        public string _ISK2;
        public string _ISK3;
        public string _ISK4;
        public string _ISK5;
        public string _ISKALT;
        public string _BRUTT;
        public string _ISKT;
        public string _NETT;
        public string _KDVT;
        public string _NETKDVT;

        // Constracter lar
        public EFatura(string LT, string BOLGE, string GRP, string EKP, string ABRNO, string AMBAR, string AY, string HAFTA, string FATTAR,
            string FATNO, string FATVD, string TUR, string TURACK, string FTUR, string SLSREF, string SATKOD, string SATTEM, string TEDEKP,
            string TEDSLSREF, string TEDSATTEM, string IL, string ILCE, string MTACIKLAMA, string GMREF, string MUSKOD, string MUSTERI,
            string SMREF, string SUBKOD, string SUBE, string SEVKKOD, string SEVKADRES, string REYKOD, string REYON, string ANAGRP,
            string GRPKOD, string GRUP, string TEDGRP, string TEDKISAMAL, string BARCODE, string ITEMREF, string MALKOD, string MALZEME,
            string KOLI, string KDV, string BRM, string ADT, string ISK1, string ISK2, string ISK3, string ISK4, string ISK5, string ISKALT, string BRUTT,
            string ISKT, string NETT, string KDVT, string NETKDVT)
        {
            this._LT = LT;
            this._BOLGE = BOLGE;
            this._GRP = GRP;
            this._EKP = EKP;
            this._ABRNO = ABRNO;
            this._AMBAR = AMBAR;
            this._AY = AY;
            this._HAFTA = HAFTA;
            this._FATTAR = FATTAR;
            this._FATNO = FATNO;
            this._FATVD = FATVD;
            this._TUR = TUR;
            this._TURACK = TURACK;
            this._FTUR = FTUR;
            this._SLSREF = SLSREF;
            this._SATKOD = SATKOD;
            this._SATTEM = SATTEM;
            this._TEDEKP = TEDEKP;
            this._TEDSLSREF = TEDSLSREF;
            this._TEDSATTEM = TEDSATTEM;
            this._IL = IL;
            this._ILCE = ILCE;
            this._MTACIKLAMA = MTACIKLAMA;
            this._GMREF = GMREF;
            this._MUSKOD = MUSKOD;
            this._MUSTERI = MUSTERI;
            this._SMREF = SMREF;
            this._SUBKOD = SUBKOD;
            this._SUBE = SUBE;
            this._SEVKKOD = SEVKKOD;
            this._SEVKADRES = SEVKADRES;
            this._REYKOD = REYKOD;
            this._REYON = REYON;
            this._ANAGRP = ANAGRP;
            this._GRPKOD = GRPKOD;
            this._GRUP = GRUP;
            this._TEDGRP = TEDGRP;
            this._TEDKISAMAL = TEDKISAMAL;
            this._BARCODE = BARCODE;
            this._ITEMREF = ITEMREF;
            this._MALKOD = MALKOD;
            this._MALZEME = MALZEME;
            this._KOLI = KOLI;
            this._KDV = KDV;
            this._BRM = BRM;
            this._ADT = ADT;
            this._ISK1 = ISK1;
            this._ISK2 = ISK2;
            this._ISK3 = ISK3;
            this._ISK4 = ISK4;
            this._ISK5 = ISK5;
            this._ISKALT = ISKALT;
            this._BRUTT = BRUTT;
            this._ISKT = ISKT;
            this._NETT = NETT;
            this._KDVT = KDVT;
            this._NETKDVT = NETKDVT;
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}