using System.Collections.Generic;
using System.Linq;

using Modal;

namespace Lab1{
    public class Querys{
        readonly Dataset Dataset = new Dataset();

        public Querys(){ Dataset.RanksInit(); }

        private List<CinemaFullInfo> CreateCinameFullInfo(List<Cinema> Cinemas){
            var query = from x in Cinemas
                        join y in Dataset.Ranks on x.RankId equals y.Id
                        select new CinemaFullInfo(){
                            Name = x.Name,
                            Capacity = x.Capacity,
                            YearConstruction = x.YearConstruction,
                            RankDescription = y.RankDescription,
                            RankId = y.Id
                        };
            return query.ToList();
        }

        public List<CinemaFullInfo> AllCinema(){
            //Простая выборка елементов
            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);

            var query = from x in cinemaFullInfo_1
                        select x;

            return query.ToList();
        }

        public List<CinemaFullInfo> CapacityInCinema(){
            //Выборка отдельного поля

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);

            var query = from x in cinemaFullInfo_1
                        select new CinemaFullInfo()
                        { Name = x.Name, Capacity = x.Capacity };

            return query.ToList();
        }

        public List<CinemaFullInfo> SortCinemaForCapacity(){
            //Сортировка

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);

            var query = from x in cinemaFullInfo_1
                        where x.Capacity >= 100 && (x.RankId == 2 || x.RankId == 3)
                        select x;

            return query.ToList();
        }

        public List<CinemaFullInfo> MaxCinemaCapacityByRank(){
            //Сортировка с использованием Max

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);

            var query = (from x in cinemaFullInfo_1
                         where x.RankId == 1 && x.Capacity ==
                         (from y in cinemaFullInfo_1
                          where y.RankId == 1
                          select y).Max(y => y.Capacity)
                          select x);

            return query.ToList();
        }

        public List<CinemaFullInfo> SortCinemaForCapacityAndYear(){
            //Сотрировка с использованием методов расширения

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);

            var query = cinemaFullInfo_1.Where((x) => {
                            return x.RankId == 1;
                        }).OrderByDescending(x => x.Capacity).ThenByDescending(x => x.YearConstruction);

            return query.ToList();
        }
        public List<CinemaFullInfo> PairsCinemasForCapacity(){
            //Cross Join и Group Join

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);
            List<CinemaFullInfo> cinemaFullInfo_2 = CreateCinameFullInfo(Dataset.Cinemas_2);

            var query = cinemaFullInfo_1.Join(cinemaFullInfo_2, x => x.Capacity, y => y.Capacity,
                (x, y) => new CinemaFullInfo() { Name = x.Name + '/' + y.Name, Capacity = x.Capacity });

            return query.ToList();
        }
        public List<CinemaFullInfo> PairsCinemasForNameandCapacity(){
            //Использование Join для слаженных ключей

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);
            List<CinemaFullInfo> cinemaFullInfoForDistinct = CreateCinameFullInfo(Dataset.Cinemas_for_distinct);

            var query = from x in cinemaFullInfo_1
                        join y in cinemaFullInfoForDistinct 
                        on new { Name = x.Name.ToUpper(), Capacity = x.Capacity }
                        equals new { Name = y.Name.ToUpper(), Capacity = y.Capacity }
                        into details
                     from d in details
                     select d;

            return query.ToList();
        }
        public List<CinemaFullInfo> UniqueCinemas(){
            //Distinct - для объектов

            List<CinemaFullInfo> cinemaFullInfoForDistinct = CreateCinameFullInfo(Dataset.Cinemas_for_distinct);

            var query = (from x in cinemaFullInfoForDistinct select x).Distinct
                (new CinemaEqualityComparer());

            return query.ToList();
        }
        public List<CinemaFullInfo> CinemasInEachList(){
            //Intersect - пересечение множеств для объектов

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);
            List<CinemaFullInfo> cinemaFullInfoForDistinct = CreateCinameFullInfo(Dataset.Cinemas_for_distinct);

            List<CinemaFullInfo> query = new List<CinemaFullInfo>();

            foreach (var x in cinemaFullInfo_1.Intersect(cinemaFullInfoForDistinct,
                new CinemaEqualityComparer()))
                query.Add(x);

            return query;
        }
        public List<CinemaFullInfo> NewCinameForSumCapacity(){
            //Aggregate - агрегирование значений

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);

            var query = cinemaFullInfo_1.Aggregate(new CinemaFullInfo()
            { Name = "Свобода", YearConstruction = 2000, RankId = 1 }, (total, next) => {
                if (next.Capacity >= 100)
                    total.Capacity += next.Capacity;
                return total;
            });

            return new List<CinemaFullInfo> { query };
        }
        public List<CinemaFullInfo> CinemasNotInSecondList(){
            //Except - разница значений

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);
            List<CinemaFullInfo> cinemaFullInfoForDistinct = CreateCinameFullInfo(Dataset.Cinemas_for_distinct);

            List<CinemaFullInfo> OutputQuery = new List<CinemaFullInfo>();

            foreach (var x in cinemaFullInfo_1.Except(cinemaFullInfoForDistinct,
                new CinemaEqualityComparer()))
                OutputQuery.Add(x);

            return OutputQuery;
        }
        public List<CinemaFullInfo> GroupCinemaForRank(){
            //Группировка

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);
            List<CinemaFullInfo> cinemaFullInfo_2 = CreateCinameFullInfo(Dataset.Cinemas_2);

            var query = from x in cinemaFullInfo_1.Union(cinemaFullInfo_2)
                      group x by x.RankDescription into g
                      select new { Key = g.Key, Values = g };

            List<CinemaFullInfo> OutputQuery = new List<CinemaFullInfo>();

            foreach (var x in query)
                foreach (var y in x.Values)      
                    OutputQuery.Add(y);

            return OutputQuery;
        }
        public List<CinemaFullInfo> GroupCinemaForRankAndCapacity(){
            //Группировка - Any

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);
            List<CinemaFullInfo> cinemaFullInfo_2 = CreateCinameFullInfo(Dataset.Cinemas_2);

            var query = from x in cinemaFullInfo_1.Union(cinemaFullInfo_2)
                      group x by x.RankDescription into g
                      where g.Any(x => x.Capacity >= 200)
                      select new { Key = g.Key, Values = g };

            List<CinemaFullInfo> OutputQuery = new List<CinemaFullInfo>();

            foreach (var x in query)
                foreach (var y in x.Values)
                    OutputQuery.Add(y);

            return OutputQuery;
        }

        public List<CinemaFullInfo> ConcatCinemas(){
            //Объденение с дубликатами

            List<CinemaFullInfo> cinemaFullInfo_1 = CreateCinameFullInfo(Dataset.Cinemas_1);
            List<CinemaFullInfo> cinemaFullInfoForDistinct = CreateCinameFullInfo(Dataset.Cinemas_for_distinct);

            var query = (from x in cinemaFullInfo_1.Concat(cinemaFullInfoForDistinct).OrderBy(x => x.Name)
                         select x);

            return query.ToList();
        }

        public List<CinemaFullInfo> FirstCinema(){
            //Первый элемент в выборке

            List<CinemaFullInfo> cinemaFullInfo_2 = CreateCinameFullInfo(Dataset.Cinemas_2);

            var query = (from x in cinemaFullInfo_2 select x).First(x => x.RankId == 2);

            return new List<CinemaFullInfo> { query };
        }
        
    }
}
