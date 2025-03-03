using System.Runtime.Serialization;
using UnityEngine;


public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float txSpawnInicial = 12f;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private float spawnMin = 3f; //tx min de spawn
    private ObjectPool enemyPool;
    private float txSpawnAtual;
    private float timer;

    void Start() //start pode funcionar como restart? 
    {
        enemyPool = new ObjectPool(prefabs, poolSize);
        timer = 0;
        txSpawnAtual = txSpawnInicial;

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= txSpawnAtual && enemyPool != null) //spawna o inimigo de acordo com a tx de spawn atual
        { //pode dar null ao parar o spawn ao colidir
            GameObject obj = enemyPool.GetFromPool();
            if (obj != null)
            {
                obj.transform.position = transform.position;
                obj.GetComponent<EnemyController>().SetSpawnerType(SpawnerType.SpawnerChao);

                txSpawnAtual = Random.Range(spawnMin, txSpawnInicial);

                timer = 0; //reseta timer 

            }
        }

        Debug.Log("Taxa de spawn atual: " + txSpawnAtual);


    }


    public void StopPoolingSpawner()
    {
        if (enemyPool != null)
        {
            enemyPool.StopPoolingPool(); //chama func de ObjectPool passando o enemy que colidiu com player
        }

    }



}
