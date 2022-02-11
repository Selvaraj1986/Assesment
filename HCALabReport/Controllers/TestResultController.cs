using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Model;
using Report.Repository.Interfaces;

namespace HCALabReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestResultController : Controller
    {
        private readonly ITestResultRepository _testResultRepository;

        public TestResultController(ITestResultRepository testResultRepository)
        {
            _testResultRepository = testResultRepository;
        }
        /// <summary>
        /// To display the all test result
        /// </summary>
        /// <returns></returns>
        [Route("GetTestResult")]
        [HttpGet]
        public ActionResult GetTestResult()
        {
            var result = _testResultRepository.GetTestResult();
            return this.Ok(result);
        }
        /// <summary>
        /// To display the test result by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetTestResultById")]
        [HttpGet]
        public ActionResult GetTestResultById(long Id)
        {
            var result = _testResultRepository.GetTestResult(Id);
            return this.Ok(result);
        }
        /// <summary>
        /// Add the test result info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddTestResult")]
        [HttpPost]
        public HttpResponseMessage AddTestResult(TestResultModel model)
        {
            var status = _testResultRepository.AddTestResult(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// update the test result 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("ModifyTestResult")]
        [HttpPut]
        public HttpResponseMessage ModifyTestResult(TestResultModel model)
        {
            var status = _testResultRepository.ModifyTestResult(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Delete the test result by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteTestResult")]
        [HttpDelete]
        public HttpResponseMessage DeleteTestResult(long Id)
        {
            var status = _testResultRepository.DeleteTestResult(Id);
            return new HttpResponseMessage(status.StatusCode);
        }
    }
}
