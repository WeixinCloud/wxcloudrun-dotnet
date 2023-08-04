using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace aspnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private const string key = "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";
        private const string url = "https://api.openai.com/v1/engines/text-davinci-002/completions";

        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MessageController>/5
        [HttpGet("{message}")]
        public async Task<string> Get(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return $"{nameof(message)}不能为空";
            }
            else
            {
                var source = "{\"messages\": [{\"role\": \"system\", \"content\": \"" + message + "\"}, {\"role\": \"user\", \"content\": \"" + message + "\"}]}";

                try
                {
                    using (HttpClient client = new())
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");
                        using (var content = new StringContent(source, Encoding.UTF8, "application/json"))
                        {
                            using (var response = await client.PostAsync(url, content))
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<string> Post([FromBody] string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return $"{nameof(message)}不能为空";
            }
            else
            {
                var source = "{\"messages\": [{\"role\": \"system\", \"content\": \"" + message + "\"}, {\"role\": \"user\", \"content\": \"" + message + "\"}]}";

                try
                {
                    using (HttpClient client = new())
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");
                        using (var content = new StringContent(source, Encoding.UTF8, "application/json"))
                        {
                            using (var response = await client.PostAsync(url, content))
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}