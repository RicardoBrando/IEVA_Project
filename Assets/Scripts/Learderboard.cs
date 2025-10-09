using System.Linq;
using TMPro;
using UnityEngine;

public class Learderboard : MonoBehaviour
{

    public TMP_Text level1Table;
    public TMP_Text level2Table;


    private void Update()
    {
        if (SaveDataScript.GlobalData.level1TimeScores != null)
        {
            string finalText = "Tutorial Map\n";
            foreach (int score in SaveDataScript.GlobalData.level1TimeScores.Take(20).Reverse())
            {
                finalText += score.ToString() + "/1900" + "\n";
            }
            level1Table.SetText(finalText);
        }

        if (SaveDataScript.GlobalData.level2TimeScores != null)
        {
            string finalText = "Real Map\n";
            foreach (int score in SaveDataScript.GlobalData.level2TimeScores.Take(20).Reverse())
            {
                finalText += score.ToString() + "/1500" + "\n" ;
            }
            level2Table.SetText(finalText);
        }
    }


}

