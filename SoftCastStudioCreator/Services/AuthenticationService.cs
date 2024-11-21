using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SoftCastStudioCreator.Models;

namespace SoftCastStudioCreator.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        private Criador _criadorAtual;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(CriadorLogin login)
        {            
                var json = JsonSerializer.Serialize(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Criadores/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    // Exemplo: armazenar o token, se necessário
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return true; // Login bem-sucedido
                }

                return false; // Login falhou
            }        
        }
    }
