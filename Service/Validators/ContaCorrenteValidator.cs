using System;
using FluentValidation;
using Domain.Entities;

namespace Service.Validators
{
    public class ContaCorrenteValidator : AbstractValidator<ContaCorrente>
    {
        public ContaCorrenteValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't find the object.");
                    });

            RuleFor(c => c.Saldo)
                .NotNull().WithMessage("Saldo não pode ser nulo");

            RuleFor(c => c.LimiteCredito)
                .GreaterThanOrEqualTo(0).WithMessage("Limite de crédito não pode ser negativo")
                .NotNull().WithMessage("Limite de crédito não pode ser nulo");
        }
    }
}