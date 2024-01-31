using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using TaskApp.Models;


namespace TaskApp.Models
{
    public class APIKeyMiddle
    {

        private readonly RequestDelegate _next;
        private readonly TaskContext _context; 

        public APIKeyMiddle(RequestDelegate next, TaskContext context)
        {
            _next = next;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string apiKey = context.Request.Headers["ApiKey"];

            if (IsValidApiKey(apiKey))
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid API key");
            }
        }

        private bool IsValidApiKey(string apiKey)
        {
            return _context.Users.Any(u => u.ApiKey == apiKey);
        }
    }
}
