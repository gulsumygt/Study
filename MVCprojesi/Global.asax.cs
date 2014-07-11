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
                //Buraya örnek olması açısından 6 adet makale ekleyelim.
                
                /* makaleleri her çalıştırdığımızda eklememei için yorum satırı haline getirdik.
                //Makaleden nesne oluşturuyoruz.
                  for(int i=1;i<=6;i++){
                  Makale makale = new Makale();
                  makale.Baslik = "Makale Başlığı";
                  makale.Icerik ="Makale İçeriği";
                  makale.Tarih = DateTime.Now;
                      //veri tabanında makaleleri eklemek için ekleme komutu veriyoruz
                      db.Makales.Add(makale);
                  }
                  //SaveChanges() komutu gelene kadar veritabanına kaydedilmeyecek.
                  //Son olarak ta yaptığımız eklemelerin, veritabanına yansıtılmasını
                  //sağlamak için kaydet komutu veriyoruz.
                db.SaveChanges();
                 */
               
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
