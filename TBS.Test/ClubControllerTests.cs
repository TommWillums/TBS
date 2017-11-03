using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TBS.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace TBS.Test
{
    //[TestClass]
    //public class ClubControllerTests
    //{
    //    [TestMethod]
    //    public void club_rest_add_new()
    //    {
    //        const string URI = "http://localhost:49738/api/Clubs";
    //        Club club = new Club() { ClubName = "TBSX Club 2", ShortName = "TBSX2", Contact = "WebAPI" };

    //        string json = JsonConvert.SerializeObject(club);
    //        var content = new StringContent(json);
    //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

    //        using (HttpClient client = new HttpClient())
    //        {
    //            client.BaseAddress = new Uri(URI);

    //            var response = client.PostAsync(URI, content).Result;

    //            Assert.AreEqual(response.IsSuccessStatusCode, true);

    //            //if (response.IsSuccessStatusCode)
    //            //    return response.Headers.Location.ToString();
    //            //else
    //            //    return response.StatusCode + " : Message - " + response.ReasonPhrase;
    //        }
    //    }
    //}
}
