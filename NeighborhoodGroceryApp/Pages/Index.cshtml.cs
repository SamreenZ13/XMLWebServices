using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryStore;
using Housing;


namespace NeighborhoodGroceryApp.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string housingJson = GetData("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            HousingModel[] housingData = HousingModel.FromJson(housingJson);


            string groceryJson = GetData("https://data.cityofchicago.org/resource/ce29-twzt.json");
            GroceryStoreModel[] groceryData = GroceryStoreModel.FromJson(groceryJson);


        }
        public string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);
            }
            return downloadedData;
        }
    }
}
