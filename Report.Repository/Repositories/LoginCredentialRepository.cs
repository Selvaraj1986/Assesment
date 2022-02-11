using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Report.Entity;
using Report.Entity.DBContextModel;
using Report.Model;
using Report.Repository.Interfaces;
using Report.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repositories
{
    public class LoginCredentialRepository : ILoginCredentialRepository
    {

        private readonly DBContext _dbContext;
        private IConfiguration _iconfiguration;
        public LoginCredentialRepository(DBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _iconfiguration = configuration;
        }

        /// <summary>
        /// Get the credential details
        /// </summary>
        /// <returns></returns>
        public LoginParameter GetAuthentication(string username, string password)
        {
            var credentialDetail = new LoginParameter();
            try
            {
                credentialDetail = (from login in _dbContext.LoginCredentials
                                    where login.UserName == username && login.Password == password
                                    select new LoginParameter
                                    {                                    
                                        UserName = login.UserName,
                                        Password = login.Password
                                    }).FirstOrDefault() ?? new LoginParameter();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return credentialDetail;

        }
        /// <summary>
        /// To Display the all credential details
        /// </summary>
        /// <returns></returns>
        public List<LoginModel> GetCredential()
        {
            var credentialDetails = new List<LoginModel>();
            try
            {
                credentialDetails = (from login in _dbContext.LoginCredentials
                                     select new LoginModel
                                     {
                                         UserId = login.UserId,
                                         UserName = login.UserName,
                                         Password = login.Password
                                     }).ToList();

            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return credentialDetails;

        }
        /// <summary>
        /// To display the credential details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public LoginModel GetCredential(long Id)
        {
            var credentialDetail = new LoginModel();
            try
            {
                credentialDetail = (from login in _dbContext.LoginCredentials
                                    where login.UserId == Id
                                    select new LoginModel
                                    {
                                        UserId = login.UserId,
                                        UserName = login.UserName,
                                        Password = login.Password
                                    }).FirstOrDefault() ?? new LoginModel();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return credentialDetail;
        }
        /// <summary>
        /// Add the credential details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResponseMessage AddCredential(LoginModel model)
        {
            try
            {
                var exist = _dbContext.LoginCredentials.Find(model.UserId);
                if (exist != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.Found);
                }

                LoginCredential login = new LoginCredential()
                {
                    UserId = model.UserId,
                    UserName = model.UserName,
                    Password = model.Password
                };
                _dbContext.LoginCredentials.Add(login);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        /// <summary>
        /// Update the credentail details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResponseMessage ModifyCredential(LoginModel model)
        {
            try
            {
                var exist = _dbContext.LoginCredentials.Find(model.UserId);
                if (exist == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                LoginCredential login = new LoginCredential()
                {
                    UserId = model.UserId,
                    UserName = model.UserName,
                    Password = model.Password
                };

                var local = _dbContext.Set<LoginCredential>().Local.FirstOrDefault(entry => entry.UserId.Equals(model.UserId));
                // check if local is not null 
                if (local != null)
                {
                    // detach
                    _dbContext.Entry(local).State = EntityState.Detached;
                }
                // set Modified model in your entry
                _dbContext.Entry(login).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        /// <summary>
        /// Delete the credential details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteCredential(long Id)
        {
            try
            {
                var credential = _dbContext.LoginCredentials.Find(Id);
                if (credential == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                _dbContext.LoginCredentials.Remove(credential);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

