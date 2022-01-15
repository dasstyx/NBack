namespace Pallada.DB
{
    public interface IDbInsertAndGetRowId<T>
    {
        public int Write(T value);
    }
}