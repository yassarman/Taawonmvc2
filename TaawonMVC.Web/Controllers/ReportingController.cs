using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.Donors;
using TaawonMVC.Web.Models.Reporting;
using TaawonMVC.Web.Reporting.Dataset;
using TaawonMVC.Web.Reporting.Dataset.ProjectTableAdapters;

namespace TaawonMVC.Web.Controllers
{
    public class ReportingController : Controller
    {
        private readonly IDonorsAppService _donorsAppService;

        public ReportingController(IDonorsAppService donorsAppService)
        {
            _donorsAppService = donorsAppService;

        }
        // GET: Reporting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectRptView()
        {
            var donors = _donorsAppService.getAllDonors();

            var ReportingViewModel = new ReportingViewModel
            {
              Donors = donors
            };

            return View("ProjectRptView", ReportingViewModel);

        }

        public ActionResult projectRpt()
        {
            var donor = Request["Donors"];
            var year = Request["year"];
            var reportViewer = new ReportViewer()
            {
                ProcessingMode = ProcessingMode.Local,
                SizeToReportContent = true,
               // Width = Unit.Percentage(100),
                //Height = Unit.Percentage(100),
            };

            Project.ViewProjectDataTable  PD= new Project.ViewProjectDataTable( );
            ViewProjectTableAdapter PA = new ViewProjectTableAdapter();

            PA.Fill(PD);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"ReportFolder\ProjectRpt.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ProjectDataset", (object)PA));
                

           

            ViewBag.ReportViewer = reportViewer;
            return null;
        }
    }
}