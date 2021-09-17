namespace Sqlzor.Api
{
    public interface IAppSettingsService
    {
        public string ConnectionStringsFile { get; }

        public string InitialQueryText { get; }
    }
}
