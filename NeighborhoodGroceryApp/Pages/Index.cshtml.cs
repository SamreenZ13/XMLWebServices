using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodGroceryApp.Models;

namespace NeighborhoodGroceryApp.Pages
{
    public class IndexModel : PageModel
    {
        public JsonResult OnGet()
        {
            string housingJson = GetData("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            HousingModel[] housingData = HousingModel.FromJson(housingJson);
            ViewData["housingData"] = housingData;

            string groceryJson = GetData("https://data.cityofchicago.org/resource/ce29-twzt.json");
            GroceryStoreModel[] groceryData = GroceryStoreModel.FromJson(groceryJson);
            ViewData["groceryData"] = groceryData;

            return new JsonResult(groceryData);
        }
        public string GetData(string endpoint)
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadString(endpoint);
            }
        }
    }
}
