

namespace Historify.Infrastructure.Abstractions
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
