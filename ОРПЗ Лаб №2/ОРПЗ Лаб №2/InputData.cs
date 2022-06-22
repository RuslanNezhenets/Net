using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Lab2{
    class InputData{
        public void InputCinema(string FileName, Cinema cinema){
            if (!File.Exists(FileName)){
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(FileName, settings)){
                    writer.WriteStartElement("cinemas");
                        writer.WriteStartElement("cinema");
                        writer.WriteElementString("name", cinema.Name);
                        writer.WriteElementString("capacity", cinema.Capacity.ToString());
                        writer.WriteElementString("yearConstruction", cinema.YearConstruction.ToString());
                        writer.WriteElementString("rankId", cinema.RankId.ToString());
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            } else {
                XDocument xDocument = XDocument.Load(FileName);
                XElement root = xDocument.Element("cinemas");
                IEnumerable<XElement> rows = root.Descendants("cinema");
                XElement firstRow = rows.Last();
                firstRow.AddAfterSelf(
                    new XElement("cinema",
                    new XElement("name", cinema.Name),
                    new XElement("capacity", cinema.Capacity.ToString()),
                    new XElement("yearConstruction", cinema.YearConstruction.ToString()),
                    new XElement("rankId", cinema.RankId.ToString()))
                    );
                xDocument.Save(FileName);
            }
        }

        public void InputRank(string FileName, string RankDescription) {
            if (!File.Exists(FileName)){
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(FileName, settings)){
                    writer.WriteStartElement("ranks");
                        writer.WriteStartElement("rank");
                        writer.WriteElementString("id", "1");
                        writer.WriteElementString("rankDescription", RankDescription);
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            } else {
                XDocument xDocument = XDocument.Load(FileName);
                XElement root = xDocument.Element("ranks");
                IEnumerable<XElement> rows = root.Descendants("rank");
                int id = rows.Count() + 1;
                XElement firstRow = rows.Last();
                firstRow.AddAfterSelf(
                    new XElement("rank",
                    new XElement("id", id),
                    new XElement("rankDescription", RankDescription))
                    );
                xDocument.Save(FileName);
            }
        }

        public void CreateCinemaFullInfo(string Cinemas, string CinemasFullInfo) {
            FileReader reader = new FileReader();

            XDocument cinemas = reader.ReadCinemas(Cinemas);
            XDocument ranks = reader.ReadRanks("Ranks.xml");

            List<int> ranksIds = ranks.Root.Elements("rank")
                .Select(x => int.Parse(x.Element("id").Value)).ToList();

            foreach (XElement cinema in cinemas.Root.Elements("cinema")) {
                if (!ranksIds.Any(x => x == int.Parse(cinema.Element("rankId").Value)))
                    cinema.Element("rankId").Value = 0.ToString();
                foreach (XElement rank in ranks.Root.Elements("rank")) {
                    if (cinema.Element("rankId").Value == rank.Element("id").Value) {
                        cinema.Element("rankId").AddAfterSelf
                            (new XElement("rankDescription", rank.Element("rankDescription").Value));
                    }
                }
            }
            cinemas.Save(CinemasFullInfo);
        }
    }
}
