using FluentValidation;

namespace SuperHeroProject.Entities.Dto
{
    public class SuperHeroDtoValidator : AbstractValidator<SuperHeroDto>
    {
        public SuperHeroDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz !").MaximumLength(50).WithMessage("En fazla 50 karakter girilmelidir !");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş bırakılamaz !").MaximumLength(50).WithMessage("En fazla 50 karakter girilmelidir !");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Ad alanı boş bırakılamaz !").MaximumLength(50).WithMessage("En fazla 50 karakter girilmelidir !");
        }
    }

    public class PlaceDtoValidator : AbstractValidator<PlaceDto>
    {
        public PlaceDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz !").MaximumLength(50).WithMessage("En fazla 50 karakter girilmelidir !");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Ad alanı boş bırakılamaz !").MaximumLength(50).WithMessage("En fazla 50 karakter girilmelidir !");
        }
    }
}
