using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;


namespace WebAPI.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        
        public string Token { get; set; }
    }
}