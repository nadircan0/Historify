namespace Historify.Application.SubServices;

public interface IStorageService : IStorage
{
    public string StorageName { get; }
}
