using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;

namespace EmployeeManagement.Desktop.Reports
{
    public class WorkTimeRecordsReport : HtmlReportBase
    {
        private readonly Report report;
        private readonly IReportService<Report> reportService = new ReportService();
        private readonly IReportTemplateService<ReportTemplate> reportTemplateService = new ReportTemplateService();
        private ReportTemplate reportTemplate;

        public override string HtmlSource { get => report.HtmlSource; set => report.HtmlSource = value; }

        public override string Code => nameof(WorkTimeRecordsReport);

        public override void PrepareBeforeGenerating()
        {
            throw new NotImplementedException();
        }

        public async override void LoadDefaultTemplateAsync()
        {
            this.reportTemplate = await reportTemplateService.GetTemplateByCodeAsync(Code);
            HtmlSource = reportTemplate.Value;
        }

        public override void AddOrUpdateReportInDatabase()
        {
            reportService.AddOneAsync(report);
        }

        public WorkTimeRecordsReport(Report report)
        {
            this.report = report;
        }
    }
}