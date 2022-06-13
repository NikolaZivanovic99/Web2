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
    public class AdminService
    {
        IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private SecurePassword _securePassword;
        private GenerateToken _generateToken;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _securePassword = new SecurePassword();
            _generateToken = new GenerateToken();
        }

        public List<AdminDto> GetAdmins()
        {
            List<AdminDto> admins = _mapper.Map<List<AdminDto>>(_adminRepository.GetAdmins());
            return admins;

        }

        public AdminDto GetById(long id)
        {
            AdminDto adminDto = _mapper.Map<AdminDto>(_adminRepository.GetById(id));
            if (adminDto == null)
            {
                throw new Exception();
            }
            return adminDto;
        }
        public AdminDto AddAdmin(AddUpdateAdminDto newAdmin)
        {
            Admin adminModel = _mapper.Map<Admin>(newAdmin);
            Admin user = _adminRepository.GetByKorisnickoIme(adminModel.KorisnickoIme);
            if (user != null)
            {
                throw new Exception();
            }
            string password = _securePassword.GetStringSha256Hash(newAdmin.Lozinka);
            adminModel.Lozinka = password;
            _adminRepository.AddAdmin(adminModel);

            return _mapper.Map<AdminDto>(adminModel);
        }

        public void DeleteAdmin(long id)
        {
            Admin admin = _adminRepository.GetById(id);
            if (admin == null)
            {
                throw new Exception();
            }
            _adminRepository.DeleteAdmin(admin);

        }

        public AdminDto UpdateAdmin(long id, AddUpdateAdminDto adminDto)
        {
            Admin adminMap = _mapper.Map<Admin>(adminDto);
            Admin adminModel = _adminRepository.GetById(id);
            if (adminModel == null)
            {
                throw new Exception();
            }
            adminModel = _adminRepository.GetByKorisnickoIme(adminDto.KorisnickoIme);
            if (adminModel != null)
            {
                throw new Exception();
            }
            string password = _securePassword.GetStringSha256Hash(adminMap.Lozinka);
            adminMap.Lozinka = password;
            adminMap = _adminRepository.UpdateAdmin(id, adminMap);
            return _mapper.Map<AdminDto>(adminMap);
        }

        public LoginResponse Login(LoginRequest login)
        {
            Admin admin = _adminRepository.GetByKorisnickoIme(login.KorisnickoIme);
            if (admin == null)
            {
                throw new Exception();
            }
            string password = _securePassword.GetStringSha256Hash(login.Lozinka);
            if (admin.Lozinka != password)
            {
                throw new Exception();
            }
            AdminDto adminDto = _mapper.Map<AdminDto>(admin);
            LoginResponse logReturn = new LoginResponse(adminDto, _generateToken.GenerateJwtTokenAdmin(admin));
            return logReturn;
        }
    }
}
