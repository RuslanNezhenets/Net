using System.Linq;
using System.Xml.Linq;

namespace Lab2{
    public class FileReader {
        public XDocument ReadCinemas(string fileName, bool full = false){
            XDocument file = XDocument.Load(fileName);

            XDocument output = new XDocument(new XElement("cinemas"));

            foreach (XElement node in file.Root.Elements("cinema")){
                XElement Name = new XElement("name",
                                node.Element("name") == null ? "Нет названия" :
                                node.Element("name").Value);
                XElement Capacity = new XElement("capacity",
                            node.Element("capacity") == null ? 0 :
                            int.Parse(node.Element("capacity").Value));
                XElement YearConstruction = new XElement("yearConstruction",
                            node.Element("yearConstruction") == null ? 1970 :
                            int.Parse(node.Element("yearConstruction").Value));
                XElement RankId = new XElement("rankId",
                            node.Element("rankId") == null ? 0 :
                            int.Parse(node.Element("rankId").Value));

                if (full){
                    XElement RankDescription = new XElement("rankDescription",
                            node.Element("rankDescription") == null ? "Без описания" :
                            node.Element("rankDescription").Value);
                    output.Root.Add(new XElement("cinema", Name, Capacity, YearConstruction,
                        RankId, RankDescription));
                } else {
                    output.Root.Add(new XElement("cinema", Name, Capacity, YearConstruction, RankId));
                }
            }

            return output;
        }

        public XDocument ReadRanks(string fileName) {
            XDocument file = XDocument.Load(fileName);

            XDocument output = new XDocument(new XElement("ranks"));

            int maxId = file.Root.Elements("rank").Max(x => int.Parse(x.Element("id").Value));

            foreach (XElement node in file.Root.Elements("rank")) {
                XElement Id = new XElement("id",
                            node.Element("id") == null ? maxId + 1 :
                            int.Parse(node.Element("id").Value));
                XElement RankDescription = new XElement("rankDescription",
                                node.Element("rankDescription") == null ? "Без описания" :
                                node.Element("rankDescription").Value);

                output.Root.Add(new XElement("rank", Id, RankDescription));
            }
            XElement id = new XElement("id", "0");
            XElement rankDescription = new XElement("rankDescription", "Без описания");
            output.Root.Add(new XElement("rank", id, rankDescription));

            return output;
        }
    }
}
