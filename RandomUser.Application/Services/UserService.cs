using AutoMapper;
using RandomUser.Domain.DTOs;
using RandomUser.Domain.Entities;
using RandomUser.Domain.Repositories;
using RandomUser.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Application.Services {
    public class UserService : IUserService {

        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) { 
            _userRepository = userRepository;
            _mapper = mapper;            
        }

        public IEnumerable<UserDTO> GetUserDTO() {
            var users = _userRepository.Get();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public IEnumerable<User> Get() {
            var users = _userRepository.Get();
            return users;
        }

        public User Get(int id) {
            var user = _userRepository.Get(id);
            return user;
        }

        public void Update(User user) {
            _userRepository.Update(user);
        }
    }
}
