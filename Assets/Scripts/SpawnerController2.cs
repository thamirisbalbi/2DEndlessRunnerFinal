using UnityEngine;

public class SpawnerController2 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [SerializeField] private float spawnTime = 10;
    [SerializeField] private int poolSize = 5;

    private ObjectPool enemyPool;
    [SerializeField] private float timer;


    void Start()
    {
        enemyPool = new ObjectPool(prefab, poolSize);
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            GameObject obj = enemyPool.GetFromPool();
            if (obj != null)
            {
                float randomY = Random.Range(minRange, maxRange);
                obj.transform.position = new Vector3(transform.position.x, randomY, 0);
                float dy = Random.Range(minRange, maxRange);
                obj.transform.Translate(0, dy, 0);

                obj.GetComponent<EnemyController>().SetSpawnerType(SpawnerType.SpawnerDy);

                timer = 0;
                Debug.Log("Random y: " + dy);
            }
        }
    }

    public void StopPoolingSpawner2()
    {
        if (enemyPool != null)
        {
            enemyPool.StopPoolingPool(); //chama func de ObjectPool passando o enemy que colidiu com player
        }

    }
}
