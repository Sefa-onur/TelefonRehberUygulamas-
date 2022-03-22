﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRU.Entities
{
    public class RehberKayit
    {
        public Guid ID { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string telefonI { get; set; }
        public string telefonII { get; set; }
        public string telefonIII { get; set; }
        public string adres { get; set; }
        public string emailadres { get; set; }
        public string aciklama { get; set; }
        public string website { get; set; }


        public override string ToString()
        {
            return $"{isim} {soyisim}";
        }
    }
}
