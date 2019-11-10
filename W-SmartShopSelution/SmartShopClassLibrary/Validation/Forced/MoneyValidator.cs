using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MoneyValidator : AbstractValidator<string>
    {
        public MoneyValidator()
        {
            RuleFor(s => s)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Must(IsADecimal).WithMessage("The money should be a number !");
        }

        protected bool IsADecimal(string s)
        {
            decimal d;

            if(decimal.TryParse(s,out d))
            {
                return true;
            }
            return false;
        }

    }
}
