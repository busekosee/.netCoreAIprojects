﻿

using System.Text;
using System.Text.Json;

class program
{
    static async Task Main(string[] args)
    {
        var apiKey = "api key";
        Console.WriteLine("Lütfen sorunuzu yazınız:('hava kaç derece istanbulda')");

        var prompt = Console.ReadLine();
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new {role="system",content="You are helpful assistant."},
                new {role="user",content=prompt}
            },
            max_tokens = 500

        };
        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        try
        {
            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<JsonElement>(responseString);
                var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                Console.WriteLine("Open AI'nin Cevabı:");
                Console.WriteLine(answer);

            }
            else
            {
                Console.WriteLine($"bir hata oluştu:{response.StatusCode}");
                Console.WriteLine(responseString);

            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"bir hata oluştu:{ex.Message}");
        }
    }
}

