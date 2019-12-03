using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NeighborhoodGroceryApp.Pages
{
    public class ArtistSongsModel : PageModel
    {
        public ActionResult OnGet()
        {
            string artistString = GetData("https://concertfit20191109074437.azurewebsites.net/api");
            Empty[] artistJSON = Empty.FromJson(artistString);
            ViewData["artistdata"] = artistJSON.ToList();
            return Page();
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