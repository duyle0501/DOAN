using System.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ShopAoQuan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication()
            .AddFacebook(facebookOptions => {
                 // Đọc cấu hình
                 IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                 facebookOptions.AppId = facebookAuthNSection["AppId"];
                 facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                 // Thiết lập đường dẫn Facebook chuyển hướng đến
                 facebookOptions.CallbackPath = "/dang-nhap-tu-facebook";
             });
        }
    }
}
