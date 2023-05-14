using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // пространство имен, необходимое для работы json

namespace LavernaWeatherApplication
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string OpenWeatherKey = "dad54f331c2cc8edcd68a5987d52e744"; //API ключ
        private void button1_Click(object sender, EventArgs e)
        {
            getWeather(); // Вызов метода getWeather
        }
        private void getWeather() //Метод, реализующий основную логику приложения
        {
            using (WebClient webClient = new WebClient()) // объявление объекта класса WebClient, необходимого для работы с API
            {
                string City = Convert.ToString(textBox4.Text); // Запись названия необходимого города в переменную
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", City, OpenWeatherKey); // Запись URL адреса с названием необходимого города, и ключом API
                var json = webClient.DownloadString(url); //Запись URL адреса в формат json
                OpenWeather.root Info = JsonConvert.DeserializeObject<OpenWeather.root>(json); //Конвертация json файла и запись необходимых данных в Модель данных OpenWeather 
                double temperature = (Info.main.temp - 273.15); // Перевод температуры из градусов Кельвина в градусы Цельсия
                textBox1.Text = Math.Round(temperature,1).ToString()+ "°C"; // Вывод данных 
                textBox2.Text = Info.weather[0].description.ToString(); // Вывод данных
                textBox3.Text = Info.wind.speed.ToString(); // Вывод данных
            }
        }
    }
}
