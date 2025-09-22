using EShopper.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace EShopper.WebUI.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync("comment", createCommentDto);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _httpClient.DeleteAsync($"comment?id={id}");
        }

        public async Task<GetByIdCommentDto> GetCommentByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"comment/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdCommentDto>();
            return values;
        }

        public async Task<List<ResultCommentDto>> GetCommentByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"getcommendbyproductid/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        public async Task<List<ResultCommentDto>> GetCommentsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comment");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }
        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync("comment", updateCommentDto);
        }
    }
}
