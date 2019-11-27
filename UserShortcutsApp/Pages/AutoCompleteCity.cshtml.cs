using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserShortcutsApp.Pages
{
    public class AutoCompleteCityModel : PageModel
    {
        [BindProperty]
        private string Term { get; set; }
        private IList<string> cityList = new List<string>();
        public JsonResult OnGet()
        {
            Term = HttpContext.Request.Query["Term"];

            AddCities("Cincinnati");
            AddCities("New York");
            AddCities("Jaipur");
            AddCities("Dallas");
            AddCities("Austin");
            AddCities("San Jose");
            AddCities("San Francisco");
            AddCities("Santa Clara");
            AddCities("Chicago");
            AddCities("Fairfield");
            AddCities("Dayton");
            AddCities("Seattle");
            AddCities("Raleigh");
            AddCities("Michigan");
            AddCities("Boston");
            AddCities("Atlanta");
            AddCities("Las Vegas");
            AddCities("Log Angeles");
            AddCities("Pittsburgh");
            AddCities("Indiana");


            return new JsonResult(cityList);
        }

        private void AddCities(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName) && cityName.ToLower().Contains(Term.ToLower()))
                cityList.Add(cityName);

        }
    }
}