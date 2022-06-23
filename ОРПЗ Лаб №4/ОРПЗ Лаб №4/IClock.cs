namespace Modals {
    public interface IClock {
        Time Time { get; }
        void AddHour();
        void AddMinute();
        void AddSecond();
    }
}
