using System.Text;
using System.Text.Json;
using SoftCastStudioCreator.Models;

namespace SoftCastStudioCreator.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private Criador _criadorAtual;
        private AuthenticationService _authService;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método de registro de criador (já existente)
        public async Task<bool> RegisterCriadorAsync(Criador criador)
        {
            var json = JsonSerializer.Serialize(criador);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Criadores/Register", content);

            if (response.IsSuccessStatusCode)
            {
                _criadorAtual = criador; // Armazena o criador após o cadastro bem-sucedido
                return true;
            }

            return false;
        }

        // Método para obter o criador atual (já existente)
        public Criador GetCriadorAtual()
        {
            return _criadorAtual;
        }

        // Novo método para buscar o criador por email
        public async Task<Criador> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("O email não pode ser nulo ou vazio.", nameof(email));

            var response = await _httpClient.GetAsync($"api/Criadores/{email}");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Criador>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            throw new HttpRequestException($"Erro ao buscar o usuário: {response.StatusCode}");
        }

        // Novo método para armazenar o criador atual manualmente
        public void SetUser(Criador criador)
        {
            _criadorAtual = criador ?? throw new ArgumentNullException(nameof(criador));
        }
    }
}
