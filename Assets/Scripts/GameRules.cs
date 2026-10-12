using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameRules : MonoBehaviour
{
    public GameObject playerObject;
    [SerializeField] protected Vector2 start_pos = Vector2.zero;
    [SerializeField] private string next_level = "Level2";
    [SerializeField] private string current_level = "Level1";

    [SerializeField] private Timer timer;

    public float level_timer = 0f;

    public void Die()
    {
        playerObject.transform.position = start_pos;
    }

    public void Victory()
    {
        PlayerPrefs.SetFloat(current_level + " current", timer.elapsed);
        PlayerPrefs.Save();
        SceneManager.LoadScene(next_level);
    }
}
