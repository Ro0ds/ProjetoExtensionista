using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Extensoes;
public static class Localizacao
{
    public static void AdicionarLocalizacao(this IServiceCollection services)
    {
        services.AddRazorPages()
            .AddDataAnnotationsLocalization()
            .AddMvcOptions(options =>
            {
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
                    x => $"O valor '{x}' é inválido.");

                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            x => $"Campo é obrigatório.");

                options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(
                    x => $"Campo é obrigatório.");

                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
                    (x, y) => $"O valor '{x}' não é válido para o campo {y}.");

                options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(
                    x => $"O valor '{x}' não é válido.");

                options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(
                    x => $"O valor '{x}' não é válido.");
            });
    }
}