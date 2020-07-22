using UnityEngine;

public class SaveManager : MonoBehaviour
{

 
    [Header("Save Information")] 
    public bool saveExists;
    public int saveFileVersion;
    public string playerName;

    private void Start()
    {
        // If no save file exists, create save and return.
        if (!saveExists) return;
        saveExists = PlayerPrefs.HasKey("SaveFileVersion");
        saveFileVersion = PlayerPrefs.GetInt("SaveFileVersion");
        playerName = PlayerPrefs.GetString("PlayerName");
    }

    private void CreateSave()
    {
        saveFileVersion = 0;
        playerName = "Tester";
        PlayerPrefs.SetInt("SaveFileVersion", saveFileVersion);
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }
    
    // Shortcut to simply saving the PlayerPrefs.
    private void Save() {PlayerPrefs.Save();}
    
    private void ResetSave()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Load()
    {
        if (!saveExists)
        {
            Debug.Log("No save file exists.");
            return;
        }
        PlayerPrefs.GetInt("SaveFileVersion", saveFileVersion);
        PlayerPrefs.GetString("PlayerName", playerName);
    }
}
