using AutoMapper;
using DataLayer.Model;
using DataLayer.RepositoriesInterface;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserService
    {
        IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private SecurePassword _securePassword;
        private GenerateToken _generateToken;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _securePassword = new SecurePassword();
            _generateToken = new GenerateToken();
        }

        public List<UserDto> GetAllUsers() 
        {
            List<UserDto> userModels = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());
            return userModels;

        }

        public UserDto GetById(long id) 
        {
            UserDto userDto= _mapper.Map<UserDto>(_userRepository.GetById(id));
            if (userDto == null) 
            {
                throw new Exception();
            }
            return userDto;
        }
        public UserDto AddUser(AddUpdateUserDto newUser)
        {
            UserModel stud = _mapper.Map<UserModel>(newUser);
            UserModel user = _userRepository.GetByKorisnickoIme(stud.KorisnickoIme);
            if (user != null)
            {
                throw new Exception();
            }
            string password = _securePassword.GetStringSha256Hash(newUser.Lozinka);
            stud.Lozinka = password;
            _userRepository.AddUser(stud);

            return _mapper.Map<UserDto>(stud);
        }

        public void DeleteUser(long id) 
        {
            UserModel user = _userRepository.GetById(id);
            if (user == null) 
            {
                throw new Exception();
            }
            _userRepository.DeleteUser(user);
            
        }

        public UserDto UpadateUser(long id, AddUpdateUserDto userDto) 
        {
            UserModel userMap = _mapper.Map<UserModel>(userDto);
            UserModel userModel = _userRepository.GetById(id);
            if (userModel == null) 
            {
                throw new Exception();
            }
            userModel = _userRepository.GetByKorisnickoIme(userDto.KorisnickoIme);
            if (userModel != null) 
            {
                throw new Exception();
            }
            string password = _securePassword.GetStringSha256Hash(userMap.Lozinka);
            userMap.Lozinka = password;
            userMap = _userRepository.UpdateUser(id,userMap);
            return _mapper.Map<UserDto>(userMap);
        }

        public LoginResponse Login(LoginRequest login) 
        {
            UserModel user = _userRepository.GetByKorisnickoIme(login.KorisnickoIme);
            if (user == null)
            {
                throw new Exception();
            }
            string password = _securePassword.GetStringSha256Hash(login.Lozinka);
            if (user.Lozinka != password)
            {
                throw new Exception();
            }
            UserDto userDto = _mapper.Map<UserDto>(user);
            LoginResponse logReturn = new LoginResponse(userDto, _generateToken.GenerateJwtTokenUser(user));
            return logReturn;
        }
    }
}
