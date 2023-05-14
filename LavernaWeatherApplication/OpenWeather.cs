using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LavernaWeatherApplication
{
    internal class OpenWeather // Класс, хранящий в себе получаемую от API информацию
    {
        public class weather // описание
        {
            public string description { get; set; }
        }
        public class main // температура
        {
            public double temp { get; set; }
        }
        public class wind // скорость ветра
        {
            public double speed { get; set; }
        }
        public class root // совокупность данных
        {
            public List<weather> weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }

        }
    }
}
