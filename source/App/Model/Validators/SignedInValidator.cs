using FluentValidation;
using Solution.Core.Validation;
using Solution.App.CrossCutting.Resources;
using Solution.App.Model.Models;

namespace Solution.App.Model.Validators
{
    public sealed class SignedInValidator : Validator<SignedInModel>
    {
        public SignedInValidator() : base(Texts.LoginPasswordInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
