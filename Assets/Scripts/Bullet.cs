using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float bullet_speed = 20f;
    [SerializeField] protected Vector2 spawn_position = new Vector2(20, 0);

    [SerializeField] private GameRules gamerules;

    void Awake()
    {
        // Find gamerules script at runtime
        gamerules = GameObject.Find("GameManager").GetComponent<GameRules>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gamerules.Die();
        }
    }

    void Update()
    {
        transform.Translate(new Vector2(-1f, 0f) * Time.deltaTime * bullet_speed);
        if (transform.position.x < -20 || transform.position.x > 20)
        {
            transform.position = spawn_position;
            gameObject.SetActive(false);
        }
    }
}
