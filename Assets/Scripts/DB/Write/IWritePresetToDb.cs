namespace Pallada.DB
{
    public interface IWritePresetToDb : IDbInsertAndGetRowId<PresetDbEntry>
    {
        int Write(PresetDbEntry preset);
    }
}