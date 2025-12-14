using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers; // OpenAI için gerekli başlık kütüphanesi

namespace Kaira.WebUI.Controllers
{
    public class AiFashionController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> GetOutfitSuggestion(string product)
        {
            // ---------------------------------------------------------
            // 1. OpenAI API Key ("sk-" ile başlayan kodu buraya yapıştır)
            string apiKey = "senin api keyin";
            // ---------------------------------------------------------

            if (string.IsNullOrEmpty(apiKey) || apiKey.Contains("sk-..."))
            {
                return Content("HATA: OpenAI API Key girilmemiş! Lütfen Controller dosyasını düzenleyin.");
            }

            // OpenAI API Endpoint Adresi
            string url = "https://api.openai.com/v1/chat/completions";

            // Prompt Hazırlığı
            var promptText = $"Sen bir moda uzmanısın. Kullanıcı '{product}' giymek istiyor. " +
                             $"Bu parça ile uyumlu ayakkabı, çanta ve aksesuarları içeren harika bir kombin önerisi yap. " +
                             $"Cevabı HTML formatında verme, sadece düz metin olarak, maddeler halinde ve samimi bir dille yaz.";

            // OpenAI İstek Formatı (Model ve Mesajlar)
            var requestBody = new
            {
                model = "gpt-3.5-turbo", // İstersen "gpt-4" veya "gpt-4o" yapabilirsin (Daha maliyetli olabilir)
                messages = new[]
                {
                    new { role = "system", content = "Sen yardımcı bir moda asistanısın." },
                    new { role = "user", content = promptText }
                },
                temperature = 0.7 // Yaratıcılık seviyesi
            };

            using (var client = new HttpClient())
            {
                // OpenAI Yetkilendirme (Header'a eklenmeli)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(responseString);

                        // OpenAI Cevap Yolu: choices[0].message.content
                        string content = result?.choices?[0]?.message?.content;

                        if (string.IsNullOrEmpty(content))
                        {
                            return Content("Yapay zeka boş bir cevap döndürdü.");
                        }

                        // Satır başlarını HTML <br> ile değiştirip gönder
                        return Content(content.Replace("\n", "<br/>"));
                    }
                    else
                    {
                        var errorDetails = await response.Content.ReadAsStringAsync();
                        return Content($"HATA OLUŞTU! (OpenAI)<br>Durum Kodu: {response.StatusCode}<br>Detay: {errorDetails}");
                    }
                }
                catch (System.Exception ex)
                {
                    return Content($"SİSTEM HATASI: {ex.Message}");
                }
            }
        }
    }
}