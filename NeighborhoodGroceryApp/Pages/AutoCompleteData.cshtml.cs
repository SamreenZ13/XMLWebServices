using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryStore;
using Housing;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace NeighborhoodGroceryApp.Pages
{
    public class AutoCompleteDataModel : PageModel
    {
        [BindProperty]
        private string Term { get; set; }
        private IList<string> communityList = new List<string>();
        public JsonResult OnGet()
        {
            Term = HttpContext.Request.Query["Term"];
            string housingJson = GetData("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            HousingModel[] housingData = HousingModel.FromJson(housingJson);

            //get the community list data for autopopulate
            communityList = housingData.Where(i => !string.IsNullOrEmpty(i.CommunityArea) && i.CommunityArea.ToLower().Contains(Term.ToLower()))
                                       .Select(i => i.CommunityArea).Distinct().ToList();
            return new JsonResult(communityList);
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