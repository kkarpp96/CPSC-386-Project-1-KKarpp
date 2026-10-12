using UnityEngine;
using TMPro;
using UnityEngine.U2D.IK;

public class TimeScores : MonoBehaviour
{
    public TMP_Text scores_text;
    public TMP_Text high_score_text;

    void Start()
    {
        float level1_score = PlayerPrefs.GetFloat("Level1 current", 999f);
        float level2_score = PlayerPrefs.GetFloat("Level2 current", 999f);
        float level3_score = PlayerPrefs.GetFloat("Level3 current", 999f);
        float total = level1_score + level2_score + level3_score;

        scores_text.text = "Level 1: " + level1_score.ToString("F2") +
                           "\nLevel 2: " + level2_score.ToString("F2") +
                           "\nLevel 3: " + level3_score.ToString("F2") +
                           "\nTotal:     "   + total.ToString("F2");

        high_score_text.text = "High Score: " + PlayerPrefs.GetFloat("high score", 999.0f).ToString("F2");
        if (total < PlayerPrefs.GetFloat("high score", 999f))
        {
            PlayerPrefs.SetFloat("high score", total);
            PlayerPrefs.Save();
            // scores_text.text += "\nHigh Score!";
            high_score_text.text = "   High Score!";
        }
    }
}
