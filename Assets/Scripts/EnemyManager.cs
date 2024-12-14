using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private GameObject myEnemy, myPlayer; // myEnemy is the enemy object, myPlayer is the player object
    private NavMeshAgent navMeshEnemy; // navMeshEnemy is the NavMeshAgent component of the enemy object

    void Start()
    {
        // find the player object and the enemy object
        myPlayer = GameObject.Find("Player");
        myEnemy = this.gameObject;
        navMeshEnemy = myEnemy.GetComponent<NavMeshAgent>();

        // if the enemy is a waiting wolf, disable the NavMeshAgent component for 10 seconds
        if (myEnemy.tag == "WaitingWolf")
        {
            navMeshEnemy.enabled = false;
            StartCoroutine(WaitBeforeContinue());
        }
        else
        {
            navMeshEnemy.enabled = true;
        }
    }
    void Update()
    {
        // if the enemy is not a waiting wolf and the NavMeshAgent component is enabled, set the destination of the enemy to the player
        if (navMeshEnemy.enabled && myPlayer != null)
        {
            navMeshEnemy.destination = myPlayer.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision) // if the enemy collides with the player, destroy the player object and load the game over scene
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log($"Wolf collided with player");
            Destroy(collision.gameObject); 
            SceneManager.LoadScene(9);
        }
    }

    private IEnumerator WaitBeforeContinue() // wait for 10 seconds before enabling the NavMeshAgent component
    {
        yield return new WaitForSeconds(10f);
        navMeshEnemy.enabled = true;
    }
}

