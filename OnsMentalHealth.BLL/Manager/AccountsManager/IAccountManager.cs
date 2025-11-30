using OnsMentalHealth.BLL.DTOs.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.AccountsManager
{
    public interface IAccountManager
    {
        // Register and Login  
        public Task<string> RegistrationAsync (RegisterDTO registerDTO);  // add reg
        public Task<string> LoginAsync ( LoginDTO loginDTO); // add login
        Task<bool> UpdateRegisterAsync(UpdateRegisterDto updateRegisterDto ); // update
        Task<bool> DeleteRegisterAsync(string Email);                      // delete 
        Task<IEnumerable<UserReadDTO>> GetAllUserRegisterationAsync();  // to get all users from db  




        // Roles 
        Task<bool> CreateRoleAsync(CreateRolesDTO createRolesDTO); // to create roles
        Task<bool> AssigneRolesToUsersAsync(AssigneRolesDTOtoUsers assigneRolesDTO); // to connect user to thers roles
        Task<IEnumerable<RoleReadDTO>> GetAllRoles(); // to get all roles 
        Task<bool> UpdateRole(UpdateRoleDto updateRoleDto);
        Task<bool> DeleteRole(string id);






    }
}
