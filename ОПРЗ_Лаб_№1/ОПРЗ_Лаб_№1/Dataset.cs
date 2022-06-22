using System.Collections.Generic;
using System.Linq;

using Modal;

namespace Lab1{
    class Dataset{
        public List<Cinema> Cinemas_1 = new List<Cinema>(){
            new Cinema(){Name = "Планета кино", Capacity = 50, YearConstruction = 2018, RankId = 1},
            new Cinema(){Name = "Салют", Capacity = 75, YearConstruction = 2012, RankId = 1},
            new Cinema(){Name = "Кадр", Capacity = 75, YearConstruction = 2014, RankId = 1},
            new Cinema(){Name = "Kinoman", Capacity = 150, YearConstruction = 2020, RankId = 3},
            new Cinema(){Name = "Кинодром 2", Capacity = 100, YearConstruction = 2008, RankId = 2},
            new Cinema(){Name = "Киевская Русь", Capacity = 100, YearConstruction = 2015, RankId = 1},
            new Cinema(){Name = "Магнат", Capacity = 80, YearConstruction = 2021, RankId = 1},
            new Cinema(){Name = "Лейпциг", Capacity = 200, YearConstruction = 2018, RankId = 2},
        };

        public List<Cinema> Cinemas_2 = new List<Cinema>(){
            new Cinema(){Name = "Проминь", Capacity = 90, YearConstruction = 2018, RankId = 3},
            new Cinema(){Name = "Батерфляй кантри", Capacity = 100, YearConstruction = 2012, RankId = 2},
            new Cinema(){Name = "Старт", Capacity = 150, YearConstruction = 2014, RankId = 1},
            new Cinema(){Name = "Спутник", Capacity = 200, YearConstruction = 2020, RankId = 3},
            new Cinema(){Name = "Жовтень", Capacity = 75, YearConstruction = 2008, RankId = 2},
        };

        public List<Cinema> Cinemas_for_distinct = new List<Cinema>(){
            new Cinema(){Name = "Проминь", Capacity = 90, YearConstruction = 2018, RankId = 2},
            new Cinema(){Name = "Kinoman", Capacity = 150, YearConstruction = 2020, RankId = 1},
            new Cinema(){Name = "Старт", Capacity = 150, YearConstruction = 2014, RankId = 1},
            new Cinema(){Name = "Лейпциг", Capacity = 200, YearConstruction = 2018, RankId = 2},
            new Cinema(){Name = "Старт", Capacity = 150, YearConstruction = 2014, RankId = 1},
            new Cinema(){Name = "Магнат", Capacity = 80, YearConstruction = 2021, RankId = 1},
            new Cinema(){Name = "Проминь", Capacity = 90, YearConstruction = 2018, RankId = 2},
        };

        public List<Rank> Ranks = new List<Rank>();
        private int CounterId(){
            if (Ranks.Count + 1 > 1)
                return Ranks.Max(x => x.Id) + 1;
            else return 1;
        }

        public void RanksInit(){
            Ranks.Add(new Rank() { Id = CounterId(), RankDescription = "Для просмотра видеофильмов" });
            Ranks.Add(new Rank() { Id = CounterId(), RankDescription = "Для просмотра широкоформатных фильмов" });
            Ranks.Add(new Rank() { Id = CounterId(), RankDescription = "Наявность стереоформатного оборудывания" });
        }

    }
}
