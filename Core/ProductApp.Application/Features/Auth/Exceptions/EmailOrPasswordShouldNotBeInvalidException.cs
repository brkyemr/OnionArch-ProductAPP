using ProductApp.Application.Bases;

namespace ProductApp.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullancı adı veya şifre yanlıştır."){}  
    } 
}