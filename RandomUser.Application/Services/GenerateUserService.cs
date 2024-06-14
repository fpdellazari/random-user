using Newtonsoft.Json;
using RandomUser.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Application.Services {
    public class GenerateUserService {

        private static readonly HttpClient client = new HttpClient();

        public GenerateUserService() { }
        public async Task GenerateUser() {
            try {
                var response = await client.GetStringAsync("https://api.randomuser.me/");
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(response);

            } catch (HttpRequestException e) {
                throw;
            }

        }

    }
}
