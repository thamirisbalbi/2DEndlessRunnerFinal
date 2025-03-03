using UnityEngine;
using System.Collections.Generic;

public class ObjectPool
{
    private GameObject[] prefabs;
    private Queue<GameObject> queue;
    private int poolSize;
    private bool poolingEnabled = true;

    public ObjectPool(GameObject[] prefabs, int poolSize) //mais de um prefab
    {
        this.prefabs = prefabs;
        this.poolSize = poolSize;
        InitializePool();
    }

    public ObjectPool(GameObject prefab, int poolSize)
    {
        this.prefabs = new GameObject[] { prefab }; //no caso de ser apenas um prefab
        this.poolSize = poolSize;
        queue = new Queue<GameObject>();
        InitializePool();
    }
    private void InitializePool()
    {
        queue = new Queue<GameObject>();

        for (int i = 0; i < this.poolSize; i++)
        {
            //Escolhe prefab aleatorio do array
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

            GameObject obj = Object.Instantiate(randomPrefab);
            obj.SetActive(false);
            queue.Enqueue(obj);
            //objetivo: fila instanciada aleatoriamente a partir dos dois prefabs
        }
    }//restart: se getFrompool() daqui == null -> no spawner controller, apago os elementos da pool por metodo implementado aqui no obj pool para apagar a pool, e talvez no spawnercontroller(ou por ex numa função de gameover ou algo do tipo), eu chamo outra nova pool, com novos obj
     //pensando que: em cada classe, os obj serao criados mas a criacao de outros também eh englobada nessa classe, sem precisar 

    public GameObject GetFromPool()
    {//chamando de novo mesma pool: se toda a pool ta nao enable e obj nao ativo: stopPoolingPool foi chamado e pode retornar null aqui
        GameObject obj = queue.Peek();


        if (!poolingEnabled) // obs para depois: se a pool tá ativa , e o obj não ativo, obj é retirado da pool e ativado (start e restart)
            return null;
        if (!obj.activeSelf && poolingEnabled)
        {
            queue.Dequeue(); //se nao ativo, remove do inicio da fila
            queue.Enqueue(obj); //coloca obj no fim da fila
            obj.SetActive(true); //coloca obj como ativo 
            return obj;
        }

        return null;
        //no enemy colision if getfrompool null -> então a pool já foi interrompida e pode ser excluída 

    } //
    public void StopPoolingPool(GameObject gameObj) //considerando o obj ativo em cena
    {
        poolingEnabled = false;
        foreach (GameObject obj in queue)
        {
            if (obj.activeSelf && obj != gameObj)
                obj.SetActive(false); //inativa todos, menos o que esta na tela e sofreu a colisão
        }

    } //mas quando inicializar de novo o getFromPool já ira colocar como ativa a pool (pensar nisso ao implementar restart)

    public void StopPoolingPool() //nao considerando obj ativo em cena
    {
        poolingEnabled = false;
        foreach (GameObject obj in queue)
        {
            if (obj.activeSelf)
                obj.SetActive(false);
        }

    }





    // obj.GetComponent<EnemyController>().getEnemySpeed();  -> velocidade player
    //se obj ativo e colidir, seta a velocidade do enemy para zero, (função de pegar o último da fila ativo e setar sua velocidade para zero)


}