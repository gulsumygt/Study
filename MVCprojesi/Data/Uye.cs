using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojesi.Data
{
    public class Uye
    {
        public int UyeId { get; set; }
        [Required(ErrorMessage = "lütfen adınızı yazınız")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "Adınız 3-50 karakter uzunluğunda olabilir.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "lütfen soyadınızı giriniz")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "soyadınız 3-50 karakter uzunluğunda olabilir")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "lütfen e-posta adresinizi giriniz")]
        [DataType(DataType.EmailAddress,ErrorMessage = "lütfen e-posta adresini geçerli bir formatta giriniz")]
        public string EPosta { get; set; }
        //Required attribute kullanmadığımız için kullanıcı burayı boş geçebilecek
        [DataType(DataType.Url,ErrorMessage = "lütfen web sitesi adresinizi geçerli bir formatta giriniz")]
        public string WebSite { get; set; }
        [DataType(DataType.ImageUrl,ErrorMessage = "lütfen resim yolunuzu doğru bir şekilde giriniz")]
        public string ResimYol { get; set; }
        [Required(ErrorMessage = "Lütfen üye olma tarihini giriniz.")]
        //Girilen tarihin, geçerli bir tarih ve saat formatında girilmesini sağlıyoruz.
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen üye olma tarihini, doğru bir şekilde giriniz.")]
        public DateTime UyeOlmaTarih { get; set; }
        //bir üye birden fazla makale yazabilir bu yüzden liste oluşturduk
        public virtual List<Makale> Makales { get; set; }
        public virtual List<Yorum> Yorums { get; set; } 
    }
}