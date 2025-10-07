using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveDataScript : MonoBehaviour
{
    public static DataToSave GlobalData = new DataToSave();

    private void Awake()
    {
        string filepath = Application.persistentDataPath + "/dataSave.json";
        Debug.Log(filepath);
        if (System.IO.File.Exists(filepath))
        {
            LoadFromJson();
        }

        if (GlobalData == null)
            GlobalData = new DataToSave();
        
        if (GlobalData.level1TimeScores == null)
            GlobalData.level1TimeScores = new List<int>();
        
        if (GlobalData.level2TimeScores == null)
            GlobalData.level2TimeScores = new List<int>();
        
        if (GlobalData.fugitiveGotCaught)
        {
            // Debloquer material
        }
    }

    public void SaveToJson()
    {
        string filepath = Application.persistentDataPath + "/dataSave.json";

        string dataString = JsonUtility.ToJson(GlobalData);
        System.IO.File.WriteAllText(filepath, dataString);

    }

    public void LoadFromJson()
    {
        string filepath = Application.persistentDataPath + "/dataSave.json";

        string dataString = System.IO.File.ReadAllText(filepath);

        GlobalData = JsonUtility.FromJson<DataToSave>(dataString);
    }
    void OnApplicationQuit()
    {
        SaveToJson();
    }
}

[System.Serializable]
public class DataToSave
{
    public List<int> level1TimeScores = new List<int>();
    public List<int> level2TimeScores = new List<int>();
    public List<int> level1TargetScores = new List<int>();
    public List<int> level2TargetScores = new List<int>();
    public bool fugitiveGotCaught = false;

}
