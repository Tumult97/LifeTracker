using Newtonsoft.Json;

namespace LifeTracker.Tests.Helpers;

public class UnitTestDataHelper
{
    public static IEnumerable<T>? GetDataFromJsonFilePath<T>(params string[] pathSegments) where T: class
    {
        var jsonFilePath = Path.Combine(new[] { Directory.GetCurrentDirectory() }.Concat(pathSegments).ToArray());
        var fileContents = File.ReadAllText(jsonFilePath);
        return JsonConvert.DeserializeObject<IEnumerable<T>>(fileContents);
    }

    // public static FakeRepositoryBase<T> GetFakeRepositoryWithJsonDataFromPath<T>(Func<T, int> identitySelector, params string[] pathSegments) where T : class
    // {
    //     var fileData = GetDataFromJsonFilePath<T>(pathSegments);
    //
    //     var repository = new FakeRepositoryBase<T>(identitySelector);
    //     repository.SetItems(fileData);
    //
    //     return repository;
    // }
}