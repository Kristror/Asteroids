using UnityEngine;

namespace Saving
{
    public class PlayerPrefsSaving : IPlayerSaveLoad
    {
        string SaveDataKey = "SaveData";
        public void Save(PlayerSaveData saveData)
        {
            string saveString = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString(SaveDataKey, saveString);
        }

        public bool IsThereSave()
        {
            return PlayerPrefs.HasKey(SaveDataKey);
        }

        public PlayerSaveData Load()
        {
            string loadString = PlayerPrefs.GetString(SaveDataKey);
            PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(loadString);

            return saveData;
        }
    }
}