using System;
using FluentValidation;
using Domain.Entities;

namespace Service.Validators
{
    public class CorrentistaValidator : AbstractValidator<Correntista>
    {
        public CorrentistaValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't find the object.");
                    });

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .NotNull().WithMessage("Nome é obrigatório");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório")
                .NotNull().WithMessage("CPF é obrigatório");

            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Endereço é obrigatório")
                .NotNull().WithMessage("Endereço é obrigatório");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório")
                .NotNull().WithMessage("Telefone é obrigatório");
        }
    }
}