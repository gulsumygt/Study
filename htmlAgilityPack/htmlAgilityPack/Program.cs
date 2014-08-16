using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
//htmlAgilityPack referans olarak ekledik
using HtmlAgilityPack;

namespace htmlAgilityPack
{
    class Program
    {
        static void Main(string[] args)
        {
            //url adresinden dom elementlerini load metodunu kullanara alabilmek için HtmlWeb nesnesi oluşturduk 
            var web = new HtmlWeb();
            //websitesini load metodu ile aldık
            var doc = web.Load("http://www.yildiz.edu.tr/duyurular/");
            //web sitesinden DOM elementlerini HtmlDocument formatında alabilmek için DocumentNode metodu kullandık
            //ve adresten etiketleri alabilmek için SelectNodes metodu kullandık ve linklerin XPath yolunu belirttik
            var nodes = doc.DocumentNode.SelectNodes("//div[@id='announcement_activity_title']/a/span");
            //linkleri sıralandırabilmek için counter tanımladık
            int counter = 1;
            //foreach belirttiğimiz nodes'ları tek tek alıp ekrana yazdırdık
            foreach (var node in nodes)
            {
                Console.WriteLine("{0}.{1} \n",counter,node.InnerHtml);
                counter++;
            }
            Console.ReadLine();
        }
    }
}
