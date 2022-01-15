using Pallada.Preset.SO;

namespace Pallada.DB
{
    public interface IDbGetMedian<T>
    {
        public T Read(PresetData preset);
    }
}