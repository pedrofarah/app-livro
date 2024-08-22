using FluentValidation;
using livro.api.domain.Dto;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Validations
{
    public class LivroDeleteServiceValidator : AbstractValidator<LivroDeleteDto>
    {
        public LivroDeleteServiceValidator(IDefaultDataModule dataModule)
        {
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Informe o id do livro.");
            RuleFor(x => x).Must(x => IdExiste(x, dataModule)).WithMessage("Livro não localizado.");
        }

        private bool IdExiste(
            LivroDeleteDto livroDelete,
            IDefaultDataModule dataModule
        )
        {
            return dataModule.LivroRepository
                .ListNoTracking(x => x.Id.Equals(livroDelete.Id)).ToList()
                .Count() > 0;
        }
    }
}
