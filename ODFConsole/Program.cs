using System;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace ODFConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var file = ZipFile.Open("t_acc_1_o.odt", ZipArchiveMode.Read))
            {
                //To get the content of ODF
                var result = file.GetEntry("content.xml");

                //To check the content exist
                if (result != null)
                {
                    XmlDocument document = new XmlDocument();
                    //XmlReader reader = XmlReader.Create(result.Open());
                    document.Load(result.Open());

                    var resu = document.GetElementsByTagName("table:table-row");

                    foreach (XmlNode row in resu)
                    {
                        var child = row.ChildNodes;

                        foreach (XmlNode col in child)
                        {
                            Console.WriteLine(col.InnerText);
                        }
                    }

                }

            }
        }
    }
}
