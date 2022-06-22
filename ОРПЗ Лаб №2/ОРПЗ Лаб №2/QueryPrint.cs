using System;
using System.Linq;
using System.Xml.Linq;

namespace Lab2 {
    class QueryPrint {
        private Queries queries = new Queries();
        private OutputData Output = new OutputData();
        public void AllCinema() {
            var query = queries.QueryAllCinema();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void CinemaCapacity() {
            var query = queries.QueryCinemaCapacity();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void Where() {
            var query = queries.QueryWhere();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void ByMaxCapacity() {
            var query = queries.QueryByMaxCapacity();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void CapacityYearSort() {
            var query = queries.QueryCapacityYearSort();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void CrossJoin() {
            var query = queries.QueryCrossJoin();
            foreach (XElement node in query) {
                Output.PrintCinema(node.Elements("cinema").First());
                Console.WriteLine("=============================");
                Output.PrintCinema(node.Elements("cinema").Last());
                Output.PrintLine();
            }
        }

        public void NameCapacityJoin() {
            var query = queries.QueryNameCapacityJoin();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void QueryUniqueCinemas() {
            var query = queries.QueryUniqueCinemas();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void CinemasIntersect() {
            var query = queries.QueryCinemasIntersect();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void QueryCinemasAggregate() {
            var query = queries.QueryAllCinema();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void CinemasExcept() {
            var query = queries.QueryCinemasExcept();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void GroupByRank() {
            var query = queries.QueryGroupByRank();

            Output.PrintDictionary(query);
        }

        public void RankCapacityGroup() {
            var query = queries.QueryRankCapacityGroup();
            Output.PrintDictionary(query);
        }

        public void Concat() {
            var query = queries.QueryConcat();
            foreach (XElement node in query) {
                Output.PrintCinema(node);
                Output.PrintLine();
            }
        }

        public void First() {
            var query = queries.QueryFirst();
            Output.PrintCinema(query);
            Output.PrintLine();
        }
    }
}
