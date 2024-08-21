using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using OBL_Zoho.Models.Helper;
using OBL_Zoho.Services.Interfaces;

namespace OBL_Zoho.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly AppSettings _appSettings;
        private IConfiguration Configuration;

        public AppSettingsService(IOptions<AppSettings> options, IConfiguration configuration)
        {
            _appSettings = options.Value;
            Configuration = configuration;  
        }

        public string GetRefreshToken()
        {
            return this.Configuration.GetSection("AppSettings")["RefreshToken"];
            //return _appSettings.Refreshtoken;
        }

        public string GetClientId()
        {
            return this.Configuration.GetSection("AppSettings")["ClientId"];
            //return _appSettings.ClientId;
        }

        public string GetClientSecret()
        {
            return this.Configuration.GetSection("AppSettings")["ClientSecret"];
            //return _appSettings.ClientSecret;
        }
    }
}
