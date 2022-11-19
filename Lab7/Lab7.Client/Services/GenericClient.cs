using Lab7.Models;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Lab7.Client.Services
{
    public sealed class GenericClient<TModel> : IGenericClient<TModel> where TModel : class, IModel
    {
        private readonly HttpClient _client;

        public GenericClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var responce = await _client.GetAsync(typeof(TModel).Name);

            if (!responce.IsSuccessStatusCode)
            {
                throw new Exception(responce.StatusCode.ToString());
            }

            var entities = await responce.Content.ReadFromJsonAsync<IEnumerable<TModel>>();

            return entities;
        }

        public async Task<TModel> GetAsync(int id)
        {
            var responce = await _client.GetAsync(typeof(TModel).Name + '/' + id.ToString());

            if (!responce.IsSuccessStatusCode)
            {
                throw new Exception(responce.StatusCode.ToString());
            }

            return await responce.Content.ReadFromJsonAsync<TModel>();
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            var responce = await _client.PostAsJsonAsync(typeof(TModel).Name, model);

            if (!responce.IsSuccessStatusCode)
            {
                throw new Exception(responce.StatusCode.ToString());
            }

            return await responce.Content.ReadFromJsonAsync<TModel>();
        }

        public async Task<TModel> UpdateAsync(int id, TModel model)
        {
            var responce = await _client.PutAsJsonAsync(typeof(TModel).Name + '/' + id.ToString(), model);

            if (!responce.IsSuccessStatusCode)
            {
                throw new Exception(responce.StatusCode.ToString());
            }

            return await responce.Content.ReadFromJsonAsync<TModel>();
        }

        public async Task DeleteAsync(int id)
        {
            var responce = await _client.DeleteAsync(typeof(TModel).Name + '/' + id.ToString());

            if (!responce.IsSuccessStatusCode)
            {
                throw new Exception(responce.StatusCode.ToString());
            }
        }
    }
}
