using Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Interfaces
{
    public interface ILoginCredentialRepository
    {
        /// <summary>
        /// Get Credential details
        /// </summary>
        /// <returns></returns>
        LoginParameter GetAuthentication(string username, string password);
        /// <summary>
        /// To display the all Credential details
        /// </summary>
        /// <returns></returns>
        List<LoginModel> GetCredential();
        /// <summary>
        /// To display the Credential by Name
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        LoginModel GetCredential(long Id);
        /// <summary>
        /// Add the Credential details
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        HttpResponseMessage AddCredential(LoginModel loginModel);
        /// <summary>
        /// Update the Credential details
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        HttpResponseMessage ModifyCredential(LoginModel loginModel);
        /// <summary>
        /// Delete the Credential details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HttpResponseMessage DeleteCredential(long Id);
    }
}
