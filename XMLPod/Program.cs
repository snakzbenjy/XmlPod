using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLPod
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc1 = XDocument.Load(@"http://www.rtl.fr/podcast/les-grosses-tetes.xml");
            //XDocument xdoc2 = XDocument.Load(@"D:\caca.txt");

            //// show title of feed in TextBlock
            //var Text = xdoc1.Element("rss").Element("channel").Element("title").Value;
            //// add each feed item to a ListBox
            //foreach (var item in xdoc1.Descendants("item"))
            //{
            //    //xdoc1.Remove(item);
            //    var d = item.Element("title").Value;
            //}

            TimeSpan tsBase = new TimeSpan(0,35,00);

            var kiki = @"http://www.itunes.com/DTDs/Podcast-1.0.dtd/";
            XNamespace itunes = xdoc1.Root.GetNamespaceOfPrefix("itunes");
            xdoc1.Element("rss")
  .Element("channel")
  .Elements("item")
  .Where(x =>
             {

                 var ss = (string)x.Element(itunes + "duration");
                 TimeSpan ts ;
                 if (TimeSpan.TryParse(ss, out ts))
                 {
                     return ts < tsBase;
                 }

                 return true;
                 
                 
             })
  .Remove();
xdoc1.Save(@"D:\caca.txt");
            //xdoc2.Save(@"D:\caca2.txt");
        }
        }
    
}
