using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time(int hours, int minutes, int seconds)
        {
            if (hours >= 0 && hours < 24 && minutes >= 0 && minutes < 60 && seconds >= 0 && seconds < 60)
            {
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
            }
            else
            {
                throw new ArgumentException("Неверный формат времени");
            }
        }

        public void DisplayTime()
        {
            if (hours < 6)
            {
                Console.WriteLine($"Сейчас ночь, текущее время - {hours:D2}:{minutes:D2}:{seconds:D2}");
            }
            else if (hours<12)
            {
                Console.WriteLine($"Сейчас утро, текущее время - {hours:D2}:{minutes:D2}:{seconds:D2}");
            }
            else if (hours < 18)
            {
                Console.WriteLine($"Сейчас день, текущее время - {hours:D2}:{minutes:D2}:{seconds:D2}");
            }
            else if (hours < 24)
            {
                Console.WriteLine($"Сейчас вечер, текущее время - {hours:D2}:{minutes:D2}:{seconds:D2}");
            }
        }       

        public static Time operator +(Time t1, Time t2)
        {
            int totalSeconds = t1.seconds + t2.seconds;
            int carrySeconds = totalSeconds / 60;
            totalSeconds %= 60;

            int totalMinutes = t1.minutes + t2.minutes + carrySeconds;
            int carryMinutes = totalMinutes / 60;
            totalMinutes %= 60;

            int totalHours = t1.hours + t2.hours + carryMinutes;
            totalHours %= 24;

            return new Time(totalHours, totalMinutes, totalSeconds);
        }

        public static Time operator -(Time t1, Time t2)
        {
            int totalSeconds = t1.seconds - t2.seconds;
            int carrySeconds = 0;
            if (totalSeconds < 0)
            {
                totalSeconds += 60;
                carrySeconds = -1;
            }

            int totalMinutes = t1.minutes - t2.minutes + carrySeconds;
            int carryMinutes = 0;
            if (totalMinutes < 0)
            {
                totalMinutes += 60;
                carryMinutes = -1;
            }

            int totalHours = t1.hours - t2.hours + carryMinutes;
            if (totalHours < 0)
            {
                totalHours += 24;
            }

            return new Time(totalHours, totalMinutes, totalSeconds);
        }
        public static bool operator <(Time t1, Time t2)
        {
            if (t1.hours < t2.hours)
            {
                return true;
            }
            else if (t1.hours == t2.hours)
            {
                if (t1.minutes < t2.minutes)
                {
                    return true;
                }
                else if (t1.minutes == t2.minutes)
                {
                    return t1.seconds < t2.seconds;
                }
            }
            return false;
        }

        public static bool operator >(Time t1, Time t2)
        {
            //if (!(t1 < t2))
            //{
            //    return true;
            //}
            //return false;
            //Не использовал данную конструкцию по причине того что будет возвращаться значение true при >=

            if (t1.hours > t2.hours)
            {
                return true;
            }
            else if (t1.hours == t2.hours)
            {
                if (t1.minutes > t2.minutes)
                {
                    return true;
                }
                else if (t1.minutes == t2.minutes)
                {
                    return t1.seconds > t2.seconds;
                }
            }
            return false;
        }



    }
}
