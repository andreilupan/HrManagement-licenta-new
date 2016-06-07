using System;
using System.Linq;
using System.Web.Mvc;

namespace HRManagement.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : Controller
    {
        DataAccess.HrContext dbContext;
        public ReportsController(DataAccess.HrContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Reports
        [HttpGet]
        [Route("population2")]
        public ActionResult GetPopulation2()
        {
            var groupedByAge = dbContext.Employees.ToList().GroupBy(x => DateTime.Now.Subtract(x.DateOfBirth).TotalDays / 365);

            var model = new[] {
            new {
                Description = "0 - 20 years",
                Values = groupedByAge.Where(x => x.Key <= 20).SelectMany(x => x).Count()
            },new
            {
                Description = "20 - 40 years",
                Values = groupedByAge.Where(x => x.Key <= 40 && x.Key > 20).SelectMany(x => x).Count()
            }, new
            {
                Description = "40 - 60 years",
                Values = groupedByAge.Where(x => x.Key <= 60 && x.Key > 40).SelectMany(x => x).Count()
            }
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [Route("population")]
        public ActionResult GetPopulation()
        {
            var model = new[] { new
            {
                City = "Satu Mare",
                PopulationPerMonth = new[] {
                    12.4,
                    23.5,
                    32.9,
                    43.5,
                    12.4,
                    43.6,
                    22.4,
                    23.2,
                    22.4,
                    33.1,
                    12.0,
                    23.5
                }
            },
            new {
                City = "Cluj",
                PopulationPerMonth = new[] {
                    32.9,
                    43.6,
                    22.4,
                    23.2,
                    22.4,
                    12.4,
                    12.4,
                    23.5,
                    33.1,
                    43.5,
                    12.0,
                    23.5,

                }
            },
            new {
                City = "Baia Mare",
                PopulationPerMonth = new[] {
                    12.4,
                    23.5,
                    43.5,
                    43.6,
                    12.4,
                    22.4,
                    23.2,
                    23.5,
                        22.4,
                    33.1,
                    32.9,
                    12.0,
                }
            }
            };


            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}