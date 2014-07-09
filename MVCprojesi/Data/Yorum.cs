using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojesi.Data
{
    public class Yorum
    {
        public int YorumId { get; set; }

        [Required(ErrorMessage = "Lütfen yorumunuzu giriniz.")]
        public string Icerik { get; set; }

        [Required(ErrorMessage = "Lütfen yorumun yapılma tarihini giriniz.")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen yorum yapılma tarihini, doğru bir şekilde giriniz.")]
        public DateTime Tarih { get; set; }
        //her yorum bir makaleye ait olabilir.Burada makale ile yorumu bağladık.
        public virtual Makale Makale { get; set; }
        //her yorumu sadece bir kişi yapabilir
        public virtual Uye Uye { get; set; }
    }
}