using FluentValidation;
using livro.api.domain.Dto;
using livro.api.persistence.Interfaces;

namespace livro.api.domain.Validations
{
    public class LivroCreateServiceValidator : AbstractValidator<LivroCreateDto>
    {
        public LivroCreateServiceValidator(IDefaultDataModule dataModule)
        {
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Titulo).NotEmpty().WithMessage("Informe o título do livro.");
            RuleFor(x => x.Autor).NotEmpty().WithMessage("Informe o autor do livro.");
            RuleFor(x => x.Genero).NotEmpty().WithMessage("Informe o gênero do livro.");
            RuleFor(x => x.Ano).GreaterThan(0).WithMessage("Informe o ano de publicação do livro.");
            RuleFor(x => x).Must(x => LivroEAutorInexistente(x, dataModule)).WithMessage("Livro já cadastrado.");
        }

        private bool LivroEAutorInexistente(
            LivroCreateDto livroCreate,
            IDefaultDataModule dataModule
        )
        {
            return dataModule.LivroRepository
                .ListNoTracking(x => x.Titulo.Equals(livroCreate.Titulo) && x.Autor.Equals(livroCreate.Autor)).ToList()
                .Count() == 0;
        }
    }
}
