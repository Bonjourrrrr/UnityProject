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
    private bool isWaiting = false;

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

    // Update is called once per frame
    void Update()
    {
        if (navMeshEnemy.enabled)
        {
            navMeshEnemy.destination = myPlayer.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log($"Wolf collided with player");
            Destroy(myPlayer);
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator WaitBeforeContinue()
    {
        yield return new WaitForSeconds(5);
        navMeshEnemy.enabled = true;
    }
}

