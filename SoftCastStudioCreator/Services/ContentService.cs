using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
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
        public async Task<List<Conteudo>> GetConteudosByCriadorAsync(int criadorId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Conteudos/criador/{criadorId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Conteudo>>(jsonResponse) ?? new List<Conteudo>();
                }
                return new List<Conteudo>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao obter conteúdos: {ex.Message}");
                return new List<Conteudo>();
            }
        }

        public async Task<Conteudo> GetConteudoAsync(int conteudoId)
        {
            try
            {
                // Defina o endpoint correto para a sua API
                var response = await _httpClient.GetAsync($"api/Conteudos/conteudo/{conteudoId}");

                if (response.IsSuccessStatusCode)
                {
                    // Desserializa o conteúdo retornado pela API para um objeto
                    var conteudo = await response.Content.ReadFromJsonAsync<Conteudo>();
                    return conteudo;
                }
                else
                {
                    // Lidar com falha na requisição
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Logar erro ou tratar de outra forma
                throw new Exception("Erro ao obter o conteúdo", ex);
            }
        }

        public async Task<bool> EditarConteudo(Conteudo conteudo)
        {
            try
            {
                // Suponha que você tenha um método para obter o criador logado
                var criadorLogado = _userService.GetCriadorAtual(); // Obtenha o criador logado
                if (criadorLogado != null)
                {
                    conteudo.CriadorID = criadorLogado.ID; // Associe o ID do criador ao conteúdo
                }
                else
                    {
                        Console.WriteLine("Erro: Criador não encontrado.");
                        return false; // Não é possível editar sem associar o criador
                    }
                
                var response = await _httpClient.PutAsJsonAsync($"api/Conteudos/{conteudo.ID}", conteudo);

                // Verifica se a resposta foi bem-sucedida
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log de erro para facilitar o rastreamento
                Console.WriteLine($"Erro ao editar conteúdo: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletarConteudo(int conteudoId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Conteudos/{conteudoId}");

                // Verifica se a resposta foi bem-sucedida
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Lidar com exceções aqui, se necessário
                Console.WriteLine($"Erro ao deletar conteúdo: {ex.Message}");
                return false;
            }
        }

    }
}