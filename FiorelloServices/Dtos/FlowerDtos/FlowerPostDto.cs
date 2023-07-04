using Fiorello.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Fiorello.Services.Dtos.FlowerDtos
{
    public class FlowerPostDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImageFile { get; set; }

    }
    public class FlowerPostDtoValidator : AbstractValidator<FlowerPostDto>
    {
        public FlowerPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.ImageFile).NotNull();
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ImageFile != null)
                {
                    if (x.ImageFile.Length > 2097152)
                    {
                        context.AddFailure(nameof(x.ImageFile), "ImageFile must be equal or less than 2mb");
                    }

                    if (x.ImageFile.ContentType != "image/jpeg" && x.ImageFile.ContentType != "image/png")
                    {
                        context.AddFailure(nameof(x.ImageFile), "Image file must be jpeg or png");
                    }
                }
            });
        }
    }
}
