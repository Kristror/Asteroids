using UnityEngine;

namespace Saving
{
    public class PlayerPrefsSaving : IPlayerSaveLoad
    {
        public void Save(PlayerSaveData saveData)
        {
            string saveString = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString("SaveData", saveString);
        }

        public bool IsThereSave()
        {
            return PlayerPrefs.HasKey("SaveData");
        }

        public PlayerSaveData Load()
        {
            string loadString = PlayerPrefs.GetString("SaveData");
            PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(loadString);

            return saveData;
        }
    }
}