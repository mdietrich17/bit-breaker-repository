using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mime;
using System.Web.Script.Serialization;
using SimplySeniors.DAL;


namespace SimplySeniors.Models
{
    public partial class WeatherAPI : System.Web.UI.Page
    {
        private ProfileContext db = new ProfileContext();
        protected void GetWeatherInfo(object sender, EventArgs e)
        {
            string appId = "4368f653168e32c12db5f1d5b9842a63";
        
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&units=imperial&cnt=1&APPID={1}",  txtCity.Text.Trim(), appId);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                //lblCity_Country.Text = weatherInfo.city.name + "," + weatherInfo.city.country;
                lblCity_Country.Text = weatherInfo.city.name + "," + weatherInfo.city.country;
                imgCountryFlag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.city.country.ToLower());
                lblDescription.Text = weatherInfo.list[0].weather[0].description;
                imgWeatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);
                lblTempMin.Text = string.Format("{0}°F", Math.Round(weatherInfo.list[0].main.temp_min, 1));
                lblTempMax.Text = string.Format("{0}°F", Math.Round(weatherInfo.list[0].main.temp_max, 1));
                lblTempCurrent.Text = string.Format("{0}°F", Math.Round(weatherInfo.list[0].main.temp, 1));
                lblHumidity.Text = weatherInfo.list[0].main.humidity.ToString();
                tblWeather.Visible = true;

            }
        }

        public class WeatherInfo
        {
            public City city { get; set; }
            public List<List> list { get; set; }
        }

        public class City
        {
            public string name { get; set; }
            public string country { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double humidity { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }

        public class Weather
        {
            public string description { get; set; }
            public string icon { get; set; }
            public string main { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int degrees { get; set;  }
        }

        public class List
        {
            public Main main { get; set; }
      
            public List<Weather> weather { get; set; }
        }
    }
}