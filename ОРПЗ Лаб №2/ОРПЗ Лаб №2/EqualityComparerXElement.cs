using System.Collections.Generic;
using System.Xml.Linq;

namespace Lab2 {
    public class EqualityComparerXElement : IEqualityComparer<XElement> {
        public bool Equals(XElement x, XElement y) {
            return x.Element("name").Value == y.Element("name").Value &&
                x.Element("capacity").Value == y.Element("capacity").Value &&
                x.Element("yearConstruction").Value == y.Element("yearConstruction").Value &&
                x.Element("rankId").Value == y.Element("rankId").Value;
        }

        public int GetHashCode(XElement obj){
            return obj.Element("capacity").Value.GetHashCode();
        }
    }
}
