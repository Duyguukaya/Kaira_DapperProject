using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Kaira.WebUI.Controllers
{
    public class AiFashionController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> GetOutfitSuggestion(string product)
        {
            // 1. OpenAI API Anahtarın (Burayı appsettings.json'dan çekmek daha güvenlidir)
            var apiKey = "sk-proj-Senin-Api-Keyin-Buraya-Gelecek";

            // 2. Yapay Zekaya Gönderilecek Prompt (Komut)
            var prompt = $"Kullanıcı şu kıyafet parçasına sahip: '{product}'. " +
                         $"Sen profesyonel bir moda danışmanısın. " +
                         $"Bu parça ile giyilebilecek, renk uyumu harika olan, ayakkabı ve aksesuar dahil " +
                         $"kısa, net ve maddeler halinde şık bir kombin önerisi yap. " +
                         $"Cevabın Türkçe olsun ve samimi bir dil kullan.";

            // 3. API İsteği Hazırlığı
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo", // veya "gpt-4"
                    messages = new[]
                    {
                        new { role = "system", content = "Sen yardımsever bir moda asistanısın." },
                        new { role = "user", content = prompt }
                    },
                    max_tokens = 300
                };

                var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                // 4. API'ye İstek At
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseString);
                    string content = result.choices[0].message.content;

                    // Cevaptaki yeni satırları HTML <br> etiketiyle değiştir ki düzgün gözüksün
                    return Content(content.Replace("\n", "<br/>"));
                }
                else
                {
                    return Content("Üzgünüm, şu an moda sunucularına erişemiyorum. Lütfen biraz sonra tekrar dene.");
                }
            
        }
}
