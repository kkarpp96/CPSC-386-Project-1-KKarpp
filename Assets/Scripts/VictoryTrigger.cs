using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] private GameRules gamerules;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gamerules.Victory();
        }
    }
}
