using Hanssens.Net;
using Library.MVC.Contracts;

namespace Library.MVC.Services;

public class LocalStorageService : ILocalStorageService
{
    private LocalStorage _storage;

    public LocalStorageService()
    {
        var cfg = new LocalStorageConfiguration()
        {
            Filename = "LIBRARY",
            AutoLoad = true,
            AutoSave = true,
        };
        _storage = new LocalStorage(cfg);
    }
    
    public void ClearStorage(List<string> keys)
    {
        foreach (var key in keys)
        {
            _storage.Remove(key);
        }
    }

    public bool Exists(string key)
    {
        return _storage.Exists(key);
    }

    public T GetStorageValue<T>(string key)
    {
        return _storage.Get<T>(key);
    }

    public void SetStorageValue<T>(string key, T value)
    {
        _storage.Store(key,value);
        _storage.Persist();
    }
}