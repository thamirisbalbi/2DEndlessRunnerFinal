using UnityEngine;
public enum SpawnerType
{
    SpawnerChao,
    SpawnerDy,
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpawnerType spawnerType;

    public void SetSpawnerType(SpawnerType type) { spawnerType = type; }
    public SpawnerType GetSpawnerType() { return spawnerType; }

    public float GetEnemySpeed() { return speed; } //getter speed
    public void SetEnemySpeed(float value) { speed = value; }

    void FixedUpdate()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        if (transform.position.x <= -17)
        {
            gameObject.SetActive(false);

        }
    }
}
