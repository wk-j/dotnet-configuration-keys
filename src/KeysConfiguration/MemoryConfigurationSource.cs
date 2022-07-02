namespace KeysConfiguration;

using Microsoft.Extensions.Configuration;

public class ConfigurationKeysSource : IConfigurationSource {

    public IEnumerable<KeyValuePair<string, string?>>? InitialData { get; set; }
    public string KeysSection { set; get; } = "Keys";

    public IConfigurationProvider Build(IConfigurationBuilder builder) {
        var defaultConfig = builder.Build();
        var encryptSection = defaultConfig.GetSection(KeysSection)
            .AsEnumerable()
            .Where(x => !string.IsNullOrWhiteSpace(x.Value))
            .ToDictionary(x => x.Key.Replace($"{KeysSection}:", string.Empty), x => x.Value);

        var newConfig = new Dictionary<string, string>();

        string ReplaceEncryptionKey(string value) {
            return encryptSection.Aggregate(value, (acc, kv) => acc.Replace(kv.Key, kv.Value));
        }

        var dict = defaultConfig.AsEnumerable().ToDictionary(x => x.Key, x => x.Value);

        foreach (var item in dict) {
            var key = item.Key;
            var value = item.Value;
            if (value is not null) {
                if (!string.IsNullOrWhiteSpace(value)) {
                    var newValue = ReplaceEncryptionKey(value);
                    newConfig.Add(key, newValue);
                }
            }
        }

        InitialData = newConfig;

        return new ConfigurationKeysProvider(this);
    }
}
