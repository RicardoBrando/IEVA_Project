using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;
using ColorUtility = UnityEngine.ColorUtility;

public class SaveDataScript : MonoBehaviour
{
    public static DataToSave GlobalData = new DataToSave();
    public static SaveDataScript instance;

    private string BronzeColor = "#B87333";
    private string SilverColor = "#C0C0C0";
    private string GoldColor = "#FFD700";
    public static Color CurrentColor;

    public int targetPoints;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        string filepath = Application.persistentDataPath + "/dataSave.json";
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
        

        if (GlobalData.fugitiveGotCaughtLevel2)
        {
            ColorUtility.TryParseHtmlString(GoldColor, out CurrentColor);
        }
        else if (GlobalData.fugitiveGotCaughtLevel1)
        {
            ColorUtility.TryParseHtmlString(SilverColor, out CurrentColor);
        }
        else
        {
            ColorUtility.TryParseHtmlString(BronzeColor, out CurrentColor);
        }
        targetPoints = 0;
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

}

[System.Serializable]
public class DataToSave
{
    public List<int> level1TimeScores = new List<int>();
    public List<int> level2TimeScores = new List<int>();

    public bool fugitiveGotCaughtLevel1 = false;
    public bool fugitiveGotCaughtLevel2 = false;

}
