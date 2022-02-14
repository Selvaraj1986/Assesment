using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Model;
using Report.Repository.Interfaces;
using Report.Support;

namespace HCALabReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : Controller
    {

        private readonly ILoginCredentialRepository _loginCredentialRepository;
        private IConfiguration _iconfiguration;
        public LoginController(ILoginCredentialRepository loginCredentialRepository, IConfiguration configuration)
        {
            _loginCredentialRepository = loginCredentialRepository;
            _iconfiguration = configuration;
        }
        /// <summary>
        /// Login the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Authentication")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginParameter request)
        {
            JwtMiddleware jwtMiddleware = new JwtMiddleware(_iconfiguration);
            string username = request.UserName ?? string.Empty;
            string password = request.Password ?? string.Empty;
            var response = new Dictionary<string, string>();
            var login = _loginCredentialRepository.GetAuthentication(username, password);
            if (!(request.UserName == login.UserName && request.Password == login.Password))
            {
                response.Add("Error", "Invalid username or password");
                return BadRequest(response);
            }

            var value = new string[] { username, password };
            var token = jwtMiddleware.GenerateJwtToken(username, value.ToList());
            return Ok(token);

        }

        /// <summary>
        /// To display all the credential details
        /// </summary>
        /// <returns></returns>
        [Route("GetCredentialList")]
        [HttpGet]
        public ActionResult GetCredential()
        {

            var result = _loginCredentialRepository.GetCredential();
            return this.Ok(result);
        }

        /// <summary>
        /// To display the credential details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetCredentialById")]
        [HttpGet]
        public ActionResult GetCredential(long Id)
        {
            var result = _loginCredentialRepository.GetCredential(Id);
            return this.Ok(result);
        }
        /// <summary>
        /// Add the credential details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddCredential")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage AddCredential(LoginModel model)
        {
            var status = _loginCredentialRepository.AddCredential(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Update the credential details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("ModifyCredential")]
        [HttpPut]
        public HttpResponseMessage ModifyCredential(LoginModel model)
        {
            var status = _loginCredentialRepository.ModifyCredential(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Delete the credential details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteCredential")]
        [HttpDelete]
        public HttpResponseMessage DeleteCredential(long Id)
        {
            var status = _loginCredentialRepository.DeleteCredential(Id);
            return new HttpResponseMessage(status.StatusCode);
        }
    }
}
