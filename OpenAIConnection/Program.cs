using Newtonsoft.Json;
using System.Text;

var apiKey = "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"; // Zastąp swoim kluczem API
var apiUrl = "https://api.openai.com/v1/chat/completions";

using var client = new HttpClient();
client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

var requestBody = new
{
    model = "gpt-3.5-turbo", // Możesz użyć "gpt-3.5-turbo" lub innego modelu
    messages = new[]
    {
            new { role = "system", content = "You are a helpful assistant." },
            new { role = "user", content = "Hello, how can I use OpenAI API?" }
        },
    max_tokens = 100,
    temperature = 0.7
};

var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

var response = await client.PostAsync(apiUrl, content);
var responseString = await response.Content.ReadAsStringAsync();

Console.WriteLine(responseString);
