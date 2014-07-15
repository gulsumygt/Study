using MVCprojesi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCprojesi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Burada veritabanı sınıfımızdan, bir nesne oluşturuyoruz. using kullanmamızın sebebi,
            //db nesnesinin işi bittiğinde, silinmesini ve hafızada yer tutmamasını sağlamak.
            using (MVCprojesiContext db = new MVCprojesiContext())
            {
                //Bu metod, eğer veritabanımız oluşturulmamış ise, oluşturulmasını sağlıyor.
                db.Database.CreateIfNotExists();

                //Veritabanındaki makalelerin,yorumların ve üyelerin adetini alıyoruz.
                int makaleAdet = (from i in db.Makales select i).Count();
                int yorumAdet = (from i in db.Yorums select i).Count();
                int uyeAdet = (from i in db.Uyes select i).Count();

                //Veritabanına, sürekli aynı makalelerin ve yorumların eklenmemesi için
                //en az 5 adet makale ve yorum var mı diye kontrol ediyoruz.
                //Ayrıca sistemde en az 1 üye olduğunu da onaylıyoruz.
                if (makaleAdet < 5 || yorumAdet < 5 || uyeAdet < 1)
                {
                    //Bir tane örnek üye oluşturuyoruz.
                    Uye uye = new Uye() { Ad = "gülsüm", Soyad = "yiğit", EPosta = "glsm@glsm.com", ResimYol = "", UyeOlmaTarih = DateTime.Now, WebSite = "" };

                    db.Uyes.Add(uye);

                    //Makalelerimizi oluşturuyoruz. Ayrıca makalelerin, yukarıda oluşturduğumuz kullanıcı 
                    //tarafından oluşturulduğunu gösteriyoruz.
                    for (int i = 0; i < 6; i++)
                    {
                        Makale makale = new Makale()
                        {
                            Baslik = "Makale Başlığı ",
                            Icerik = "Makale İçeriği ",
                            Tarih = DateTime.Now,
                            Uye = uye
                        };

                        //Makaleleri eklemek için komutumuzu veriyoruz.
                        //SaveChanges() komutu gelene kadar veritabanına kayıt yapılmayacak.
                        db.Makales.Add(makale);
                       
                        //Yorumlarımızı oluşturuyoruz. Ayrıca yorumların, yukarıda oluşturduğumuz kullanıcı 
                        //tarafından oluşturulduğunu gösteriyor, ayrıca makalelerimize de bağlıyoruz.
                        Yorum yorum = new Yorum()
                        {
                            Icerik = "Makale  için yazılan yorum",
                            Tarih = DateTime.Now,
                            Makale = makale,
                            Uye = uye
                        };
                        
                        //Yorumları eklemek için komutumuzu veriyoruz.
                        //SaveChanges() komutu gelene kadar veritabanına kayıt yapılmayacak.
                        db.Yorums.Add(yorum);
                    }

                    //Son olarak da yaptığımız eklemelerin, veritabanına yansıtılmasını
                    //sağlamak için kaydet komutu veriyoruz.
                    db.SaveChanges();
                }
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
