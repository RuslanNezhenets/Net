using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lab2{
    public enum FilesName {
        cinemas1 = 0,
        cinemas2 = 1,
        cinemasDistinct = 2
    }
    public class Queries{
        private FileReader _reader = new FileReader();
        private Dictionary<FilesName, string> File = new Dictionary<FilesName, string>{
            { FilesName.cinemas1, "Cinemas_1_FullInfo.xml" },
            { FilesName.cinemas2, "Cinemas_2_FullInfo.xml" },
            { FilesName.cinemasDistinct, "Cinemas_for_distinct_FullInfo.xml" }
        };

        public Queries(){
            InputData data = new InputData();
            data.CreateCinemaFullInfo("Cinemas_1.xml", File[FilesName.cinemas1]);
            data.CreateCinemaFullInfo("Cinemas_2.xml", File[FilesName.cinemas2]);
            data.CreateCinemaFullInfo("Cinemas_for_distinct.xml", File[FilesName.cinemasDistinct]);
        }

        public List<XElement> QueryAllCinema(){
            //Простая выборка елементов
            XDocument xdoc = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            var query = xdoc.Element("cinemas").Elements("cinema");

            return query.ToList();
        }

        public List<XElement> QueryCinemaCapacity(){
            //Выборка отдельного поля

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);

            var query = Cinemas_1.Element("cinemas").Elements("cinema")
                .Select(p => new XElement("cinema",
                new XElement("name", p.Element("name").Value),
                new XElement("capacity", int.Parse(p.Element("capacity").Value))));

            return query.ToList();
        }

        public List<XElement> QueryWhere(){
            //Выборка по кол-ву мест

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);

            var query = Cinemas_1.Element("cinemas").Elements("cinema")
                .Where(p => int.Parse(p.Element("capacity").Value) >= 100);

            return query.ToList();
        }

        public List<XElement> QueryByMaxCapacity(){
            //Сортировка с использованием Max

            XDocument Cinemas = _reader.ReadCinemas(File[FilesName.cinemas1], true);

            var query = (from x in Cinemas.Root.Elements("cinema")
                         where int.Parse(x.Element("rankId").Value) == 1 &&
                         int.Parse(x.Element("capacity").Value) ==
                         (from y in Cinemas.Root.Elements("cinema")
                          where int.Parse(y.Element("rankId").Value) == 1
                          select y).Max(y => int.Parse(y.Element("capacity").Value))
                         select x);

            return query.ToList();
        }

        public List<XElement> QueryCapacityYearSort(){
            //Сотрировка с использованием методов расширения

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);

            var query = Cinemas_1.Element("cinemas").Elements("cinema")
                .OrderByDescending(p => int.Parse(p.Element("capacity").Value))
                .ThenByDescending(p => int.Parse(p.Element("yearConstruction").Value));

            return query.ToList();
        }

        public List<XElement> QueryCrossJoin(){
            //Cross Join

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            XDocument Cinemas_2 = _reader.ReadCinemas(File[FilesName.cinemas2], true);

            var query = from x in Cinemas_1.Root.Elements("cinema")
                        join y in Cinemas_2.Root.Elements("cinema")
                        on x.Element("capacity").Value equals y.Element("capacity").Value
                        select new XElement("pair", x, y);

            return query.ToList();
        }

        public List<XElement> QueryNameCapacityJoin(){
            //Использование Join для слаженных ключей

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            XDocument Cinemas_2 = _reader.ReadCinemas(File[FilesName.cinemasDistinct], true);

            var query = from x in Cinemas_1.Root.Elements("cinema")
                        join y in Cinemas_2.Root.Elements("cinema")
                        on new { Name = x.Element("name").Value,
                            Capacity = int.Parse(x.Element("capacity").Value) }
                        equals new { Name = y.Element("name").Value,
                            Capacity = int.Parse(y.Element("capacity").Value) }
                        into details
                        from d in details
                        select new XElement("cinema",
                        new XElement("name", d.Element("name").Value),
                        new XElement("capacity", d.Element("capacity").Value));

            return query.ToList();
        }

        public List<XElement> QueryUniqueCinemas(){
            //Distinct - для объектов

            XDocument Cinemas = _reader.ReadCinemas(File[FilesName.cinemasDistinct], true);

            var query = Cinemas.Root.Elements("cinema").Distinct(new EqualityComparerXElement());

            return query.ToList();
        }

        public List<XElement> QueryCinemasIntersect(){
            //Intersect - пересечение множеств для объектов

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            XDocument Cinemas_2 = _reader.ReadCinemas(File[FilesName.cinemasDistinct], true);

            var query = Cinemas_1.Root.Elements("cinema").Intersect(Cinemas_2.Root.Elements("cinema"),
                new EqualityComparerXElement());

            return query.ToList();
        }
        public List<XElement> QueryCinemasAggregate(){
            //Aggregate - агрегирование значений

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);

            var query = Cinemas_1.Root.Elements("cinema").Aggregate(new XElement("cinema", 
                new XElement("name", "Свобода"),
                new XElement("capacity", 0),
                new XElement("yearConstruction", 2000)), (total, next) => {
                    if (int.Parse(next.Element("capacity").Value) >= 100){
                        int value = int.Parse(total.Element("capacity").Value);
                        value += int.Parse(next.Element("capacity").Value);
                        total.Element("capacity").Value = value.ToString();
                    }
                    return total;
                });

            return new List<XElement> { query };
        }
        public List<XElement> QueryCinemasExcept(){
            //Except - разница значений

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            XDocument Cinemas_2 = _reader.ReadCinemas(File[FilesName.cinemasDistinct], true);

            var query = Cinemas_1.Root.Elements("cinema").Except(Cinemas_2.Root.Elements("cinema"),
                new EqualityComparerXElement());

            return query.ToList();
        }
        public Dictionary<string, List<XElement>> QueryGroupByRank(){
            //Группировка

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            XDocument Cinemas_2 = _reader.ReadCinemas(File[FilesName.cinemas2], true);

            var query = Cinemas_1.Root.Elements("cinema").Union(Cinemas_2.Root.Elements("cinema"))
                .GroupBy(x => x.Element("rankDescription").Value);


            return query.ToDictionary(x => x.Key, x => x.ToList());
        }

        public Dictionary<string, List<XElement>> QueryRankCapacityGroup() {
            //Группировка - Any

            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            XDocument Cinemas_2 = _reader.ReadCinemas(File[FilesName.cinemas2], true);

            var query = Cinemas_1.Root.Elements("cinema").Union(Cinemas_2.Root.Elements("cinema"))
                .GroupBy(x => x.Element("rankDescription").Value)
                .Where(g => g.Any(j => int.Parse(j.Element("capacity").Value) >= 200));

            return query.ToDictionary(x => x.Key, x => x.ToList());
        }
        public List<XElement> QueryConcat(){
            //Concat - общее с дубликатами
            XDocument Cinemas_1 = _reader.ReadCinemas(File[FilesName.cinemas1], true);
            XDocument Cinemas_2 = _reader.ReadCinemas(File[FilesName.cinemasDistinct], true);

            var query = Cinemas_1.Root.Elements("cinema")
                         .Concat(Cinemas_2.Root.Elements("cinema")).OrderBy(x => x.Element("name").Value);

            return query.ToList();
        }

        public XElement QueryFirst(){
            //Первый элемент в выборке

            XDocument Cinemas = _reader.ReadCinemas(File[FilesName.cinemas2], true);

            var query = Cinemas.Root.Elements("cinema").First(x => x.Element("rankId").Value == "2");

            return query;
        }
    }
}
