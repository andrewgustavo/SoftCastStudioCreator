using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;
using SoftCastStudioCreator.Models;

namespace SoftCastStudioCreator.Services
{
    public class ContentService
    {
        private readonly HttpClient _httpClient;
        private readonly UserService _userService;

        public ContentService(HttpClient httpClient, UserService userService)
        {
            _httpClient = httpClient;
            _userService = userService;
        }

        public async Task<bool> CreateContentAsync(Conteudo conteudo)
        {
            try
            {
                // Suponha que você tenha um método para obter o criador logado
                var criadorLogado = _userService.GetCriadorAtual(); // Obtenha o criador logado
                if (criadorLogado != null)
                {
                    conteudo.CriadorID = criadorLogado.ID; // Associe o ID do criador ao conteúdo
                }

                var conteudoJson = JsonSerializer.Serialize(conteudo);
                var content = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Conteudos", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                Debug.WriteLine("Erro ao criar conteúdo: " + ex.Message);
                return false;
            }
        }
    }
}