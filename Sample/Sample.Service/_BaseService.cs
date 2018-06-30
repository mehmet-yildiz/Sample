

namespace Sample.Service
{
    public class BaseService<T> where T : new()
    {
        public T Get(long id)
        {
            return new T();
        }
    }
}
