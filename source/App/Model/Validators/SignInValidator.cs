using FluentValidation;
using Solution.Core.Validation;
using Solution.App.CrossCutting.Resources;
using Solution.App.Model.Models;

namespace Solution.App.Model.Validators
{
    public sealed class SignInValidator : Validator<SignInModel>
    {
        public SignInValidator() : base(Texts.LoginPasswordInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
