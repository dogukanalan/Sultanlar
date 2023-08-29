using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;
using Sultanlar.DbObj.Internet;

namespace Sultanlar.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddCors();
            services.AddMemoryCache();
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();
            app.UseCors(
                //options => options.WithOrigins("http://www.happyfamily.com.tr").AllowAnyMethod()
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders(new string[] { "auth", "yeniticket", "yeniticket2" })
            );

            app.UseMvc();
        }

        public static bool ValidateTicket(HttpContext context, out string cookie, out string localst)
        {
            cookie = string.Empty;
            localst = string.Empty;

            if (context != null)
            {
                string headerTicketEnc = context.Request.Headers["STicket"];
                string cookieTicketEnc = context.Request.Headers["sulLogin"];
                string cookieRTicket = context.Request.Headers["sulLoginR"];
                string musteriid = context.Request.Headers["sulMus"];
                string eposta = context.Request.Headers["sulEposta"];
                string uygulama = context.Request.Headers["sulUyg"];
                string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
                int auth = 1;
                
                if (string.IsNullOrEmpty(headerTicketEnc))
                {
                    auth = 4;
                    return false;
                    throw new System.Security.SecurityException("empty ticket");
                }

                if (string.IsNullOrEmpty(cookieTicketEnc))
                {
                    auth = 4;
                    return false;
                    throw new System.Security.SecurityException("empty cookie");
                }



                string headerTicket = DateTime.Now.AddSeconds(-1).ToString();
                try
                {
                    headerTicket = Sifreleme.Decrypt(headerTicketEnc);
                }
                catch (Exception)
                {
                    return false;
                }

                string cookieTicket = string.Empty;
                try
                {
                    cookieTicket = Sifreleme.Decrypt("ri8jtDmDQca=", cookieTicketEnc);
                }
                catch (Exception)
                {
                    return false;
                }



                if (string.Compare(headerTicket, cookieTicket, false) != 0)
                {
                    auth = 2;
                    return false;
                    throw new System.Security.SecurityException("not logged");
                }

                if (Convert.ToDateTime(headerTicket) < DateTime.Now)
                {
                    auth = 3;
                    return false;
                    throw new System.Security.SecurityException("expires");
                }

                if (context.Request.Path.Value.IndexOf("/internet/satici") == -1 && context.Request.Path.Value.IndexOf("/internet/mesaj/GetMesajCount") == -1)
                {
                    var body = new StreamReader(context.Request.Body);
                    if (context.Request.Method == "POST")
                    {
                        if (body.BaseStream.CanSeek)
                            body.BaseStream.Seek(0, SeekOrigin.Begin);
                    }
                    var requestBody = body.ReadToEnd();
                    
                    loglar.DoInsert(
                        Convert.ToInt32(musteriid),
                        DateTime.Now,
                        context.Request.Host.Host,
                        context.Request.Path,
                        context.Request.Method,
                        context.Request.QueryString.Value,
                        requestBody,
                        auth,
                        headerTicketEnc,
                        cookieTicket,
                        cookieRTicket,
                        eposta,
                        uygulama,
                        ip
                        );
                }

                DateTime yeni = cookieRTicket == "true" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : DateTime.Now.AddMinutes(60);
                string yeniticket = Sifreleme.Encrypt(yeni.ToString());
                string yeniticket2 = Sifreleme.Encrypt("ri8jtDmDQca=", yeni.ToString());
                localst = yeniticket;
                cookie = yeniticket2;
            }
            else
            {
                return false;
                throw new System.Security.SecurityException("not authorized");
            }

            return true;
        }

        public static bool ValidateTicketOut(HttpContext context)
        {
            if (context != null)
            {
                string cookieTicket = context.Request.Headers["komsu"];
                string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();

                if (string.IsNullOrEmpty(cookieTicket))
                {
                    return false;
                    throw new System.Security.SecurityException("empty ticket");
                }



                if (string.Compare("tsoft", cookieTicket, false) != 0)
                {
                    return false;
                    throw new System.Security.SecurityException("not logged");
                }
            }
            else
            {
                return false;
                throw new System.Security.SecurityException("not authorized");
            }

            return true;
        }
    }

    public class Yetkili : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string cookie = string.Empty;
            string localst = string.Empty;
            if (Startup.ValidateTicket(context.HttpContext, out cookie, out localst))
            {
                context.HttpContext.Response.Headers.Add("auth", "logged");
                context.HttpContext.Response.Headers.Add("yeniticket", localst);
                context.HttpContext.Response.Headers.Add("yeniticket2", cookie);
            }
            else
            {
                try
                {
                    //context.HttpContext.Response.Clear();
                    //context.HttpContext.Response.StatusCode = 401;
                    context.HttpContext.Response.Headers.Add("auth", "notlogged");
                    context.Result = new BadRequestObjectResult(context.ModelState) { StatusCode = 200 };
                    //byte[] body = System.Text.Encoding.UTF8.GetBytes("{ \"something\": \"wrong\" }");
                    //context.HttpContext.Response.Body.Write(body, 0, body.Length);
                    //context.HttpContext.Response.Body.Close();
                    //context.HttpContext.Response.Body.Flush();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "webapi startup");
                }
            }
        }
    }

    public class Yetkisiz : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            loglar.DoInsert(
                        0,
                        DateTime.Now,
                        context.HttpContext.Request.Host.Host,
                        context.HttpContext.Request.Path,
                        context.HttpContext.Request.Method,
                        context.HttpContext.Request.QueryString.Value,
                        "",
                        4,
                        "",
                        "",
                        "",
                        "",
                        "",
                        context.HttpContext.Connection.RemoteIpAddress.ToString()
                        );
        }
    }

    public class YetkiliOut : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (Startup.ValidateTicketOut(context.HttpContext))
            {
                context.HttpContext.Response.Headers.Add("auth", "logged");
            }
            else
            {
                try
                {
                    context.HttpContext.Response.Headers.Add("auth", "notlogged");
                    context.Result = new BadRequestObjectResult(context.ModelState) { StatusCode = 200 };
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "webapi startup");
                }
            }
        }
    }
}
