namespace OBL_Zoho.Services.Interfaces
{
    public interface IAppSettingsService
    {
        string GetRefreshToken();
        string GetClientId();
        string GetClientSecret();
    }
}
