using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.Donors.DTO;

namespace TaawonMVC.Web.Models.Reporting
{
    public class ReportingViewModel
    {
        public IEnumerable<GetDonorsOutput> Donors { get; set; }
    }
}