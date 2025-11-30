using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnsMentalHealth.BLL.DTOs.AccountDto;
using OnsMentalHealth.BLL.Manager.AccountsManager;

namespace OnsMentalHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public UserAccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {

            // Use AccountManager to handle login and token generation
            var token = await _accountManager.LoginAsync(loginDTO); // call LoginAsync method from IAccountManager
            if (token != null) // if token is generated successfully
                return Ok(token); // return token to client

            return Unauthorized(); // if login fails return 401 Unauthorized 
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            // Use AccountManager to handle registration and token generation
            var token = await _accountManager.RegistrationAsync(registerDTO); // call RegisterAsync method from IAccountManager
            if (token != null) // if token is generated successfully
                return Ok(token); // return token to client

            return BadRequest("Registration failed"); // if registration fails return 400 Bad Request
        }


        [HttpPut("UpdateRegister")]
        public async Task<IActionResult> UpdateRegister(UpdateRegisterDto updateRegisterDto)
        {

            // Use AccountManager to handle registration and token generation
            var status = await _accountManager.UpdateRegisterAsync(updateRegisterDto); // call RegisterAsync method from IAccountManager
            if (status != null) //
                return Ok(new { message = "User updated successfully" }); // if transaction done

            return BadRequest(new { message = "User updated Faild" }); // not
        }



        [HttpDelete("DeleteRegister")]
        public async Task<IActionResult> DeleteRegisterAsync([FromQuery] string Email)
        {
            // Use AccountManager to handle registration and token generation
            var status = await _accountManager.DeleteRegisterAsync(Email); // call RegisterAsync method from IAccountManager
            if (status) //
                return Ok(new { message = "User Deleted successfully" }); // if transaction done

            return BadRequest(new { message = "User Deleted Faild" }); // not
        }


        [HttpGet("GetAllUsersRegisters")]
        public async Task<IActionResult> GetAllUser()
        {
            // Use AccountManager to handle registration and token generation
            var users = await _accountManager.GetAllUserRegisterationAsync(); // call RegisterAsync method from IAccountManager
            return Ok(users);
        }














        // Roles
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRolesDTO createRoleDTO)
        {
            // Use AccountManager to handle registration and token generation
            var status = await _accountManager.CreateRoleAsync(createRoleDTO); // call RegisterAsync method from IAccountManager
            if (status) //
                return Ok(new { message = "Role Created successfully" }); // if transaction done

            return BadRequest(new { message = "Role Faild to be Created" }); // not
        }



        [HttpPost("GetAllAssigneRolesToUsers")]
        public async Task<IActionResult> AssigneRolesToUsers(AssigneRolesDTOtoUsers assigneRolesDTO)
        {
            // Use AccountManager to handle registration and token generation
            var users = await _accountManager.AssigneRolesToUsersAsync(assigneRolesDTO); // call RegisterAsync method from IAccountManager
            return Ok(users);
        }



        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            // Use AccountManager to handle registration and token generation
            var Roles = await _accountManager.GetAllRoles(); // call RegisterAsync method from IAccountManager
            return Ok(Roles);
        }



        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            // Use AccountManager to handle registration and token generation
            var status = await _accountManager.UpdateRole(updateRoleDto); // call RegisterAsync method from IAccountManager
            if (status) //
                return Ok(new { message = "Role updated successfully" }); // if transaction done

            return BadRequest(new { message = "Role updated Faild" }); // not
        }


        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromQuery] string id)
        {
            // Use AccountManager to handle registration and token generation
            var status = await _accountManager.DeleteRole(id); // call RegisterAsync method from IAccountManager
            if (status) //
                return Ok(new { message = "Role Deleted successfully" }); // if transaction done

            return BadRequest(new { message = "Role Deleted Faild" }); // not
        }

    }
}
