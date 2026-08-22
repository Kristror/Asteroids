using UnityEngine;

namespace Saving
{
    public class PlayerPrefsSaving : IPlayerSaveLoad
    {
        private const string SAVE_DATA_KEY = "SaveData";
        public void Save(PlayerSaveData saveData)
        {
            string saveString = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString(SAVE_DATA_KEY, saveString);
        }

        public bool IsThereSave()
        {
            return PlayerPrefs.HasKey(SAVE_DATA_KEY);
        }

        public PlayerSaveData Load()
        {
            string loadString = PlayerPrefs.GetString(SAVE_DATA_KEY);
            PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(loadString);

            return saveData;
        }
    }
}