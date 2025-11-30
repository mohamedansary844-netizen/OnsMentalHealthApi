using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnsMentalHealth.BLL.DTOs.AccountDto;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.AccountsManager
{
    public class AccountManager : IAccountManager
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;


        public AccountManager (Microsoft.AspNetCore.Identity.UserManager<User> userManager , IConfiguration configuration , Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager) 
        {

            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
         
            var finduser = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (finduser == null)
            {
                return "Not Found"; 
            }

            // check password
            var isPasswordValid = await _userManager.CheckPasswordAsync(finduser, loginDTO.Password); 
            if (!isPasswordValid)
            {
                return "invalid password"; // invalid password
            }

            // generate token

            var userClaims = await _userManager.GetClaimsAsync(finduser); // get claims of the user from database
            var roles = await _userManager.GetRolesAsync(finduser);

            foreach (var role in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            string token = GenerateTokenMethod(userClaims.ToList()); // generate token
            return token;


        }

        public async Task<string> RegistrationAsync(RegisterDTO registerDTO)
        {
            //1 mapping RegisterDTO to User entity
            User user = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Birthday = registerDTO.Birthday,
                Gender = registerDTO.Gender,
            };

            // 2 using UserManager to create user in the database
            var registeredUser = await _userManager.CreateAsync(user, registerDTO.Password);

            // 3 check if the user is created successfully
            if (registeredUser.Succeeded)
            {
                var claim = new Claim(ClaimTypes.Name, user.UserName);
                await _userManager.AddClaimAsync(user, claim);
                return "User Registered Successfully";
            }
            else
            {
                var errors = string.Join(", ", registeredUser.Errors.Select(e => e.Description));
                return "User Registration Failed: " + errors;
            }
        }

                   // generate token method
        private string GenerateTokenMethod(List<Claim> claims)
        {

            // secret key & algorithm
            string securitykey = _configuration.GetValue<string>("SecurityKey")
                ?? throw new Exception("Security key not found in configuration");
            var securitykeyByte = Encoding.UTF8.GetBytes(securitykey);           // convert secret key to byte array
            SecurityKey securityKey = new SymmetricSecurityKey(securitykeyByte); // create security key
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // create signing credentials using HMAC SHA256 algorithm


           
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken // Token Generation
                (
                claims: claims,
                expires: DateTime.Now.AddMinutes(100),
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler(); // write token to string & return to client
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken); // string


            return token;
        }





      



    

        public async Task<bool> CreateRoleAsync(CreateRolesDTO createRolesDTO)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = createRolesDTO.RoleName,
                NormalizedName = createRolesDTO.RoleName.ToUpper()
            };

            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<bool> AssigneRolesToUsersAsync(AssigneRolesDTOtoUsers assigneRolesDTO)
        {
            // Claims here is place to put it not with token in register

            var user = await _userManager.FindByIdAsync(assigneRolesDTO.UserId);
            var role = await _roleManager.FindByIdAsync(assigneRolesDTO.RoleId);

            if (user == null || role == null)
                return false;

            var result = await _userManager.AddToRoleAsync(user, role.Name!);

            if (result.Succeeded)
            {
                var claim = new Claim(ClaimTypes.Role, role.Name!);
                await _userManager.AddClaimAsync(user, claim);

                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRegisterAsync(UpdateRegisterDto updateRegisterDto)
        {
            //var existingDoctor = _doctorReposatory.GetDoctorById(doctor.Id); // Retrieve existing doctor from the database to track changes
            var existingRegis = await _userManager.FindByEmailAsync(updateRegisterDto.Email);
            if (existingRegis == null)
                return false;

            existingRegis.UserName = updateRegisterDto.Username;
            existingRegis.Email = updateRegisterDto.Email;
            await _userManager.RemovePasswordAsync(existingRegis);
            await _userManager.AddPasswordAsync(existingRegis, updateRegisterDto.Password);

            await _userManager.UpdateAsync(existingRegis);

            return true;
        }

        public async Task<bool> DeleteRegisterAsync(string Email)
        {

            var exist = await _userManager.FindByEmailAsync(Email);
            if (exist == null)
                return false;
            var res = await _userManager.DeleteAsync(exist);
            if (res.Succeeded)
                return true;
            return false;
        }


        public async Task<IEnumerable<UserReadDTO>> GetAllUserRegisterationAsync()
        {
            var users = _userManager.Users.Select(w => new UserReadDTO
            {
                Id = w.Id,
                Name = w.UserName,
                Email = w.Email ,
                Gender = w.Gender
            }).ToList();

            return await Task.FromResult(users); 
        }

        public async Task<IEnumerable<RoleReadDTO>> GetAllRoles()
        {
            var roles = _roleManager.Roles.Select(q => new RoleReadDTO()
            {
                Id = q.Id,
                Name = q.Name

            }).ToList();

            return await Task.FromResult(roles);
        }

        public async Task<bool> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var uprole = await _roleManager.FindByIdAsync(updateRoleDto.Id);
            if (uprole == null)
                return false;

            uprole.Name = updateRoleDto.RoleName;

            var res = await _roleManager.UpdateAsync(uprole);
            return true;
        }

        public async Task<bool> DeleteRole(string id)
        {
            var delrole = await _roleManager.FindByIdAsync(id);
            if (delrole == null)
                return false;
            var res = await _roleManager.DeleteAsync(delrole);
            if (res.Succeeded)
                return true;
            return false;
        }
    }
}
