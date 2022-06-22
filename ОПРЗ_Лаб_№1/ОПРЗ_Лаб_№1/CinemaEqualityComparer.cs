using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal
{
    class CinemaEqualityComparer: IEqualityComparer<CinemaFullInfo>
    {
        public bool Equals(CinemaFullInfo x, CinemaFullInfo y){
            if (x.Name.ToUpper() == y.Name.ToUpper() && x.Capacity == y.Capacity &&
                x.YearConstruction == y.YearConstruction && x.RankId == y.RankId)
                return true;
            return false;
        }
        public int GetHashCode(CinemaFullInfo obj){
            return obj.Capacity;
        }
    }
}
