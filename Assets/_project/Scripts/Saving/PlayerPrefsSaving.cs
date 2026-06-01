using UnityEngine;

namespace Saving
{
    public class PlayerPrefsSaving : IPlayerSaveLoad
    {
        private const string _saveDataKey = "SaveData";
        public void Save(PlayerSaveData saveData)
        {
            string saveString = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString(_saveDataKey, saveString);
        }

        public bool IsThereSave()
        {
            return PlayerPrefs.HasKey(_saveDataKey);
        }

        public PlayerSaveData Load()
        {
            string loadString = PlayerPrefs.GetString(_saveDataKey);
            PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(loadString);

            return saveData;
        }
    }
}