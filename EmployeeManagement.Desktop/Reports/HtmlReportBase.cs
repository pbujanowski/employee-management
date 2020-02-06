using System;

namespace EmployeeManagement.Desktop.Reports
{
    public abstract class HtmlReportBase
    {
        public virtual string HtmlSource { get; set; }
        public abstract string Code { get; }

        public virtual void SaveToPdf(string outputPath)
        {
            try
            {
                PrepareBeforeGenerating();

                //var pdf = Pdf
                //    .From(HtmlSource)
                //    .OfSize(PaperSize.A4)
                //    .WithoutOutline()
                //    .Portrait()
                //    .Comressed()
                //    .Content();
                //File.WriteAllBytes(outputPath, pdf);
                AddOrUpdateReportInDatabase();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public abstract void PrepareBeforeGenerating();

        public abstract void LoadDefaultTemplateAsync();

        public abstract void AddOrUpdateReportInDatabase();
    }
}