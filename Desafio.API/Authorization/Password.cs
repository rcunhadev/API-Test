using FluentValidation;

namespace Desafio.API
{
    public class Password
    {
         public string Pass { get; set; }
    }

    public class AbstractValidatorPassword : AbstractValidator<Password>
    {
        public AbstractValidatorPassword()
        {
            RuleFor(x => x.Pass).NotEmpty()
                          .NotNull()                          
                          .Matches("[a-z]").WithMessage("'{PropertyName}' É necessário conter uma ou mais letras minúsculas.")
                          .Matches("[A-Z]").WithMessage("'{PropertyName}' É necessário conter uma ou mais letras maiúsculas.")
                          .WithMessage("'{PropertyName}'  É necessário conter um dos caracteres: @, #, !, _, -, .")
                          .Matches(@"\b(@|#|_|-|!)\b")
                          .MinimumLength(15);
                         
        }

    }


    public class RequestParam
    {
        public string Request { get; set; }
    }

    public class ResponseParam
    {
        public string Response { get; set; }
    }



}
