using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCprojesi.Data
{
    public class MVCprojesiContext:DbContext
    {
        //veri tabanında tabloları temsil edecek tüm sınıfları DbSet<> arasına yazdık.tablo olduğu için s takısı kullandık.
        public DbSet<Etiket> Etikets { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Uye> Uyes { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
    }
}