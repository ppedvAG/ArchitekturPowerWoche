using FluentValidation;
using MoviNext.Model;

namespace MoviNext.ValidationService
{
    public class UmrichterValidator : AbstractValidator<Umrichter>
    {
        public UmrichterValidator()
        {
            RuleFor(x => x.Spannung).LessThan(1000).GreaterThan(0);
            RuleFor(x => x.Frequenz).LessThan(1000).GreaterThan(0);
            RuleFor(x => x.Leistung).LessThan(1000).GreaterThan(0);
            RuleFor(x => x.Version).GreaterThan(0);
            RuleFor(x => x.Steuerung).NotNull();
        }
    }
}
