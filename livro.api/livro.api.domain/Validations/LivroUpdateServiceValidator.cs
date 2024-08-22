using FluentValidation;
using livro.api.domain.Dto;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Validations
{
    public class LivroUpdateServiceValidator : AbstractValidator<LivroUpdateDto>
    {
        public LivroUpdateServiceValidator(IDefaultDataModule dataModule)
        {
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Informe o id do livro.");
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("Informe o título do livro.");
            RuleFor(x => x.Autor).NotEmpty().WithMessage("Informe o autor do livro.");
            RuleFor(x => x.Genero).NotEmpty().WithMessage("Informe o gênero do livro.");
            RuleFor(x => x.Ano).GreaterThan(0).WithMessage("Informe o ano de publicação do livro.");
            RuleFor(x => x).Must(x => IdExiste(x, dataModule)).WithMessage("Livro não localizado.");
            RuleFor(x => x).Must(x => LivroNaoDuplicado(x, dataModule)).WithMessage("Livro já cadastrado.");
        }

        private bool IdExiste(
            LivroUpdateDto livroUpdate,
            IDefaultDataModule dataModule
        )
        {
            return dataModule.LivroRepository
                .ListNoTracking(x => x.Id.Equals(livroUpdate.Id)).ToList()
                .Count() > 0;
        }

        private bool LivroNaoDuplicado(
            LivroUpdateDto livroUpdate,
            IDefaultDataModule dataModule
        )
        {
            return dataModule.LivroRepository
                .ListNoTracking(x => !x.Id.Equals(livroUpdate.Id) && (x.Titulo.Equals(livroUpdate.Titulo) && x.Autor.Equals(livroUpdate.Autor))).ToList()
                .Count() == 0;
        }
    }
}
