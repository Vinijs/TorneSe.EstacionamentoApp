using FluentValidation;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Business.Validadores;

public class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome do usuário não pode ser vazio")
            .MaximumLength(100)
            .WithMessage("O nome do usuário não pode conter mais de 100 caracteres.");

        RuleFor(x => x.Login)
            .NotEmpty()
            .WithMessage("O login do usuário não pode ser vazio")
            .MaximumLength(100)
            .WithMessage("O login do usuário não pode conter mais de 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O e-mail do usuário não pode ser vazio")
            .MaximumLength(100)
            .WithMessage("O e-mail do usuário não pode conter mais de 100 caracteres.");

        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("A senha do usuário não pode ser vazio")
            .MaximumLength(100)
            .WithMessage("A senha do usuário não pode conter mais de 100 caracteres.");

        RuleFor(x => x.TipoUsuario)
            .NotEmpty()
            .WithMessage("O tipo do usuário não pode ser vazio");
    }
}
