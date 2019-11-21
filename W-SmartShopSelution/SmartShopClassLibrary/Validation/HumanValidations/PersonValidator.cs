using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public  class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Enter the {PropertyName}")
                .NotEmpty().WithMessage("Enter The  {PropertyName}");
            RuleFor(P => P)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(IsTheNationalNumberUnique).WithMessage("This National Number is Used Before !");

        }

        /// <summary>
        /// Checks if the national Number unique
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        protected bool IsTheNationalNumberUnique(PersonModel person)
        {
            return Person.IsTheNationalNumberUnique(person);
        }
    }
}
