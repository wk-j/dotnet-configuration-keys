namespace KeysConfiguration;

using Microsoft.Extensions.Configuration;

public static class ConfigurationBuilderExtensions {
    public static IConfigurationBuilder AddKeysConfiguration(
        this IConfigurationBuilder builder, string sectionName = "Keys") {
        return builder.Add(new KeysConfigurationSource {
            KeysSection = sectionName
        });
    }
}
