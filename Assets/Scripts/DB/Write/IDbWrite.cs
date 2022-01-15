namespace Pallada.DB
{
    public interface IDbWrite<T>
    {
        public void Write(T data);
    }
}