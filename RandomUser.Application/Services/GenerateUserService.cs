using AutoMapper;
using Newtonsoft.Json;
using RandomUser.Domain.DTOs;
using RandomUser.Domain.Entities;
using RandomUser.Domain.Repositories;
using RandomUser.Domain.Services;
using RandomUser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Application.Services {
    public class GenerateUserService : IGenerateUserService {

        private static readonly HttpClient client = new HttpClient();
        private readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;

        public GenerateUserService(IMapper mapper, IUserRepository userRepository) {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task GenerateUser() {

            var response = await client.GetStringAsync("https://randomuser.me/api/");
            var randomUserResponseDTO = JsonConvert.DeserializeObject<RandomUserResponseDTO>(response);
            var user = _mapper.Map<User>(randomUserResponseDTO?.Results.ToList()[0]);
            _userRepository.Insert(user);
            //if (resultsDTO?.Users?.ToList().Count > 0) {
            //}
        }

    }
}
