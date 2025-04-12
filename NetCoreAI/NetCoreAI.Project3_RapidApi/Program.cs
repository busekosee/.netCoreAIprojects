using NetCoreAI.Project3_RapidApi.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

var client = new HttpClient();
List<ApiSeriesViewModel> apiSeriesViewModels = new List<ApiSeriesViewModel>();  var request = new HttpRequestMessage
 {
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
    Headers =
    {
        { "x-rapidapi-key", "9ad478c191msh87d7b0cd03fade3p1c37e6jsn6d4c25bd72b2" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
  };
 using (var response = await client.SendAsync(request))
 {
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    apiSeriesViewModels = JsonConvert.DeserializeObject<List<ApiSeriesViewModel>>(body);
    foreach(var series in apiSeriesViewModels)
    {
        Console.WriteLine(series.rank + "-" + series.title + "-film puanı:" + series.rating+
            "yapım yılı:" + series.year);

    }

   
  }
Console.ReadLine();
