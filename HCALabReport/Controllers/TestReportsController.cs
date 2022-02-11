using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Model;
using Report.Repository.Interfaces;

namespace HCALabReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestReportsController : Controller
    {
        private readonly ITestReportRepository _testReportRepository;

        public TestReportsController(ITestReportRepository testReportRepository)
        {
            _testReportRepository = testReportRepository;
        }
        /// <summary>
        /// To display the all test report 
        /// </summary>
        /// <returns></returns>
        [Route("GetTestReports")]
        [HttpGet]
        public ActionResult GetTestReports()
        {
            var result = _testReportRepository.GetTestReports();
            return this.Ok(result);
        }
        /// <summary>
        /// To display the test report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetTestReportsById")]
        [HttpGet]
        public ActionResult GetTestReportsById(long Id)
        {
            var result = _testReportRepository.GetTestReports(Id);
            return this.Ok(result);
        }
        /// <summary>
        /// Add the test report details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddTestReport")]
        [HttpPost]
        public HttpResponseMessage AddTestReport(TestReportModel model)
        {
            var status = _testReportRepository.AddTestReport(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Update the test report detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("ModifyTestReport")]
        [HttpPut]
        public HttpResponseMessage ModifyTestReport(TestReportModel model)
        {
            var status = _testReportRepository.ModifyTestReport(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Delete the test report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteTestReport")]
        [HttpDelete]
        public HttpResponseMessage DeleteTestReport(long Id)
        {
            var status = _testReportRepository.DeleteTestReport(Id);
            return new HttpResponseMessage(status.StatusCode);
        }
    }
}
