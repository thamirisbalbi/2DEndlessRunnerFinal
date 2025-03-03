using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EnemyCollider : MonoBehaviour
{
    // public static event Action<GameObject> OnPlayerCollision; //evento que passa gameobj

    [SerializeField] private SpawnerType spawnerType;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            EnemyController enemy = this.gameObject.GetComponent<EnemyController>();
            
            if (enemy != null && enemy.GetEnemySpeed() != 0)
            {
                enemy.SetEnemySpeed(0); //zera vel do enemy que colidiu com player
                Debug.Log("Enemy zerado");
            }

            FindAnyObjectByType<SpawnerController>().StopPoolingSpawner();
            FindAnyObjectByType<SpawnerController2>().StopPoolingSpawner2(); // ao colidir desativa todos da pool 
            // obs: tentei fazer com que o colidido não fosse desativado de imediato, mas o codigo ficou sujo e decidi optar pelo mais simples;
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);//carrega cena de game over no mesmo instante da colisao
            //botão de restart no hub, ou cena de restart para voltar a spawnar a pool quando game over, além do score


        }



    }
}

