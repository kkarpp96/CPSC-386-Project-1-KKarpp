using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float elapsed = 0f;

    void Update()
    {
        elapsed += Time.deltaTime;
        timerText.text = "Time: " +
        elapsed.ToString("F1");
    }
}
