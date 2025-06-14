﻿using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "api key";
        string audioFilePath = "Mesafeler.mp3";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            var form = new MultipartFormDataContent();
            var audioContent = new ByteArrayContent(File.ReadAllBytes(audioFilePath));
            audioContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mpeg");
            form.Add(audioContent, "file", Path.GetFileName(audioFilePath));
            form.Add(new StringContent("whisper-1"), "model");

            Console.WriteLine("ses dosyası ileniyor,bekleyiniz..");
            //istek atalım openai
            var response = await client.PostAsync("https://api.openai.com/v1/audio/transcriptions", form);
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Transkript:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"hata:  {response.StatusCode}");
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
        }
    }
}
