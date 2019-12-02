using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Housing;
using System.Net;

namespace NeighborhoodGroceryApp.Controllers
{
    [Route("api/Neighbor")]
    [ApiController]
    public class NeighborController : ControllerBase
    {
        [HttpGet]
        [Route("GetHousingData/{communityArea}")]
        public ActionResult<HousingModel[]> GetHousingData(string communityArea)
        {
            if (string.IsNullOrWhiteSpace(communityArea))
                return NotFound();
            //calling the GetData method and passing the Housing JSON URL
            string housingJson = GetData("https://data.cityofchicago.org/resource/s6ha-ppgi.json");
            HousingModel[] housingData = HousingModel.FromJson(housingJson);
            housingData = housingData.Where(i => i.CommunityArea.Equals(communityArea, StringComparison.CurrentCultureIgnoreCase)).ToArray();
            return housingData;
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