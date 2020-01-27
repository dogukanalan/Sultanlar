using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;

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
            services.AddMvc();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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

                if (string.IsNullOrEmpty(headerTicketEnc))
                {
                    return false;
                    throw new System.Security.SecurityException("empty ticket");
                }

                if (string.IsNullOrEmpty(cookieTicketEnc))
                {
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
                    return false;
                    throw new System.Security.SecurityException("not logged");
                }

                if (Convert.ToDateTime(headerTicket) < DateTime.Now)
                {
                    return false;
                    throw new System.Security.SecurityException("expires");
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
}
