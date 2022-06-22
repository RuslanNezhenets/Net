namespace Modal{
    public class CinemaFullInfo: Cinema{
        public string RankDescription { get; set; }

        public override string ToString(){
            string output = "";
            if (Name != null)
                output += ("Кинотеатр: " + Name);
            if (Capacity != 0)
                output += ("\nКоличество мест: " + Capacity);
            if (YearConstruction != 0)
                output += ("\nГод создания: " + YearConstruction);
            if (RankDescription != null)
                output += ("\nРанг кинотеатра: " + RankDescription);
            return output;
        }
    }
}
