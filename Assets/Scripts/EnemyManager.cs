using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private GameObject myEnemy, myPlayer;
    private NavMeshAgent navMeshEnemy;

    void Start()
    {
        myPlayer = GameObject.Find("Player");
        myEnemy = this.gameObject;
        navMeshEnemy = myEnemy.GetComponent<NavMeshAgent>();

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
        if (navMeshEnemy.enabled && myPlayer != null)
        {
            navMeshEnemy.destination = myPlayer.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log($"Wolf collided with player");
            Destroy(collision.gameObject); 
            SceneManager.LoadScene(8);
        }
    }

    private IEnumerator WaitBeforeContinue()
    {
        yield return new WaitForSeconds(10f);
        navMeshEnemy.enabled = true;
    }
}

