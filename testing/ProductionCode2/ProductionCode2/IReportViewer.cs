namespace ProductionCode
{
    public interface IReportViewer
    {
        int BlockCount { get; set; }
        int UsedSize { get; set; }

        void PrepareData(string dir);
    }
}