namespace Saving
{
    public interface IPlayerSaveLoad 
    {
        void Save(PlayerSaveData saveData);
        bool IsThereSave();
        PlayerSaveData Load();
    }
}