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
        public void OnGet(string communityAreaName)
        {
           
            //calling the GetData method and passing the Housing JSON URL
            string housingJson = GetData("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            HousingModel[] housingData = HousingModel.FromJson(housingJson);

            //calling the GetData method and passing the Grocery JSON URL
            string groceryJson = GetData("https://data.cityofchicago.org/resource/ce29-twzt.json");
            GroceryStoreModel[] groceryData = GroceryStoreModel.FromJson(groceryJson);

            housingData = housingData.Where(i => i.CommunityArea.Equals(communityAreaName, StringComparison.CurrentCultureIgnoreCase)).ToArray();
            groceryData = groceryData.Where(i => i.CommunityAreaName.Equals(communityAreaName, StringComparison.CurrentCultureIgnoreCase)).ToArray();
            ViewData["HousingDetails"] = housingData;

            ViewData["groceryStoreDetails"] = groceryData;


        }
        //GetData method is created to read the data from two JSONs. A single method, so that it can be used.
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
