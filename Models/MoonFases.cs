using System;

namespace HomeWork_3_WPF.Models
{
    public enum Fases
    {
        New_Moon,
        Waxing_Crescent,
        First_Quarter,
        Waxing_Gibbous,
        Full_Moon,
        Waning_Gibbous,
        Third_Quarter,
        Waning_Crescent,
        End_Moon_Month
    }
    public class MoonFases
    {
        public int MoonDay { get; set; }
        public String MoonFase { get; set; }

        public MoonFases()
        {
                MoonDay = 0;
                MoonFase = string.Empty;
        }


        public MoonFases(int moonDay)
        {
            MoonDay = moonDay;
            if (MoonDay == 0)
                MoonDay = 30;
            if (MoonDay == 1)
                MoonFase = Fases.New_Moon.ToString();
            else if (MoonDay > 1 && MoonDay < 7)
                MoonFase = Fases.Waxing_Crescent.ToString();
            else if (MoonDay > 6 && MoonDay < 9)
                MoonFase = Fases.First_Quarter.ToString();
            else if (MoonDay > 8 && MoonDay < 14)
                MoonFase = Fases.Waxing_Gibbous.ToString();
            else if (MoonDay > 13 && MoonDay < 17)
                MoonFase = Fases.Full_Moon.ToString();
            else if (MoonDay > 16 && MoonDay < 22)
                MoonFase = Fases.Waning_Gibbous.ToString();
            else if (MoonDay > 21 && MoonDay < 24)
                MoonFase = Fases.Third_Quarter.ToString();
            else if (MoonDay > 23 && MoonDay < 30)
                MoonFase = Fases.Waning_Crescent.ToString();
            else
                MoonFase = Fases.End_Moon_Month.ToString();
        }

        public MoonFases(DateTime date)
        {
            int day = date.Day;
            int month = date.Month;
            int moonDay = date.Year % 19 + 1;
            MoonDay = ((moonDay * 11) - 14 + day + month) % 30;
            if (MoonDay == 0)
                MoonDay = 30;
            if (MoonDay == 1)
                MoonFase = Fases.New_Moon.ToString();
            else if (MoonDay > 1 && MoonDay < 7)
                MoonFase = Fases.Waxing_Crescent.ToString();
            else if (MoonDay > 6 && MoonDay < 9)
                MoonFase = Fases.First_Quarter.ToString();
            else if (MoonDay > 8 && MoonDay < 14)
                MoonFase = Fases.Waxing_Gibbous.ToString();
            else if (MoonDay > 13 && MoonDay < 17)
                MoonFase = Fases.Full_Moon.ToString();
            else if (MoonDay > 16 && MoonDay < 22)
                MoonFase = Fases.Waning_Gibbous.ToString();
            else if (MoonDay > 21 && MoonDay < 24)
                MoonFase = Fases.Third_Quarter.ToString();
            else if (MoonDay > 23 && MoonDay < 30)
                MoonFase = Fases.Waning_Crescent.ToString();
            else
                MoonFase = Fases.End_Moon_Month.ToString();
        }
    }
}
