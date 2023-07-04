using FluentValidation;

namespace Fiorello.Services.Dtos.CategoryDtos
{

    public class CategoryPutDto
    {
        public string Name { get; set; }
    }

    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);

        }
    }
}

