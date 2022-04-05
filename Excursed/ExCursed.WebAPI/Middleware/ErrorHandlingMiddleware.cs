﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ExCursed.BLL.Exceptions;

namespace ExCursed.WebAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            int status = 
                (exception as CustomHttpException)?.StatusCode ?? (int)HttpStatusCode.InternalServerError;

            string statusText = exception.Message;
            string result;

            if (env.IsEnvironment("Development"))
            {
                string stackTrace = exception.StackTrace;
                result = JsonSerializer.Serialize(new { statusText, status, stackTrace });
            }
            else
            {
                result = JsonSerializer.Serialize(new { statusText, status });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status;
            return context.Response.WriteAsync(result);
        }
    }
}
