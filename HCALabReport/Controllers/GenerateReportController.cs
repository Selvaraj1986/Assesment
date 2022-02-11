using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Repository.Interfaces;

namespace HCALabReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenerateReportController : Controller
    {
        private readonly IGenerateReportRepository _generateReportRepository;

        public GenerateReportController(IGenerateReportRepository generateReportRepository)
        {
            _generateReportRepository = generateReportRepository;
        }
        /// <summary>
        /// To display the all consolidate report 
        /// </summary>
        /// <returns></returns>
        [Route("GetGenerateReports")]
        [HttpGet]
        
        public ActionResult GetGenerateReports()
        {
            var result = _generateReportRepository.GetGenerateReports();
            return this.Ok(result);
        }
        /// <summary>
        /// To display the consolidate report by Id
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("GetGenerateReportsByDate")]
        [HttpGet]
        public ActionResult GetGenerateReportsByDate(DateTime startDate,DateTime endDate)
        {
            var result = _generateReportRepository.GetGenerateReports(startDate,endDate);
            return this.Ok(result);
        }
    }
}