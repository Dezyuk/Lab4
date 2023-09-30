using System;

namespace Lab4
{
    internal class Time
    {
        private const byte MAX_HOUR_IN_DAY = 24;
        private const byte MAX_MINUTES_IN_HOUR = 60;
        private const byte MAX_SECONDS_IN_MINUTES = 60;
        private const int MAX_SECONDS_IN_DAY = 86399;
        private byte _hours;
        private byte _minutes;
        private byte _seconds;

        private byte Hours
        {
            get => _hours;
            set => _hours = value < MAX_HOUR_IN_DAY ? value : throw new FormatException("Неверный формат времени");
        }
        private byte Minutes
        {
            get => _minutes;
            set => _minutes = value < MAX_MINUTES_IN_HOUR ? value : throw new FormatException("Неверный формат времени");
        }
        private byte Seconds
        {
            get => _seconds;
            set => _seconds = value < MAX_SECONDS_IN_MINUTES ? value : throw new FormatException("Неверный формат времени");
        }


        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        //Возврат строки с информацией про время  
        public string DisplayTime()
        {
            string result = Hours < MAX_HOUR_IN_DAY / 4 ? "ночь" : Hours < MAX_HOUR_IN_DAY / 2 ? "утро" : Hours < (3 * (MAX_HOUR_IN_DAY / 4)) ? "день" : "вечер";
            return $"Сейчас {result}, текущее время - {Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        }
        //Метод перевода времени в секунды
        private static int ConvertTimeToSeconds(Time t)
        {
            return ((t.Hours * MAX_MINUTES_IN_HOUR) + t.Minutes) * MAX_SECONDS_IN_MINUTES + t.Seconds;
        }
        //Метод перевода секунд в время (использую явное приведение к типу byte)
        private static Time ConvertSecondsToTime(int s)
        {
            byte seconds = (byte)(s % MAX_SECONDS_IN_MINUTES);
            s /= MAX_SECONDS_IN_MINUTES;
            byte minutes = (byte)(s % MAX_MINUTES_IN_HOUR);
            s /= MAX_MINUTES_IN_HOUR;
            byte hours = (byte)s;
            return new Time(hours, minutes, seconds);
        }

        public static Time operator +(Time t1, Time t2)
        {
            return ConvertSecondsToTime((ConvertTimeToSeconds(t1) + ConvertTimeToSeconds(t2)) % MAX_SECONDS_IN_DAY);
        }

        public static Time operator -(Time t1, Time t2)
        {
            return ConvertSecondsToTime(ConvertTimeToSeconds(t1) < ConvertTimeToSeconds(t2) ? MAX_SECONDS_IN_DAY + (ConvertTimeToSeconds(t1) - ConvertTimeToSeconds(t2)) : ConvertTimeToSeconds(t1) - ConvertTimeToSeconds(t2));
        }
        public static bool operator <(Time t1, Time t2)
        {
            return (ConvertTimeToSeconds(t1) < ConvertTimeToSeconds(t2));
        }

        public static bool operator >(Time t1, Time t2)
        {
            return (ConvertTimeToSeconds(t1) > ConvertTimeToSeconds(t2));
        }



    }
}
