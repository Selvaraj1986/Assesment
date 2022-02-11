using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Model;
using Report.Repository.Interfaces;

namespace HCALabReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeOfTestController : Controller
    {
        private readonly ITypeOfTestRepository _typeOfTestRepository;

        public TypeOfTestController(ITypeOfTestRepository typeOfTestRepository)
        {
            _typeOfTestRepository = typeOfTestRepository;
        }
        /// <summary>
        /// To display the all type of test
        /// </summary>
        /// <returns></returns>
        [Route("GetTestTypes")]
        [HttpGet]
        public ActionResult GetTestTypes()
        {
            var result = _typeOfTestRepository.GetTestTypes();
            return this.Ok(result);
        }
        /// <summary>
        /// To display the type of test by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetTestTypesById")]
        [HttpGet]
        public ActionResult GetTestTypesById(long Id)
        {
            var result = _typeOfTestRepository.GetTestTypes(Id);
            return this.Ok(result);
        }
        /// <summary>
        /// Add the type of test master info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddTestTypes")]
        [HttpPost]
        public HttpResponseMessage AddTestTypes(TypeOfTestModel model)
        {
            var status = _typeOfTestRepository.AddTestTypes(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Update the type of test info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("ModifyTestTypes")]
        [HttpPut]
        public HttpResponseMessage ModifyTestTypes(TypeOfTestModel model)
        {
            var status = _typeOfTestRepository.ModifyTestTypes(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Delete the type of test by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteTestTypes")]
        [HttpDelete]
        public HttpResponseMessage DeleteTestTypes(long Id)
        {
            var status = _typeOfTestRepository.DeleteTestTypes(Id);
            return new HttpResponseMessage(status.StatusCode);
        }
    }
}
