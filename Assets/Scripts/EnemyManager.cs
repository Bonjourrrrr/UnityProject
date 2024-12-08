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

        if (myEnemy.tag == "WaitingWolf" && isWaiting == false)
        {
            navMeshEnemy.enabled = false;
            StartCoroutine(WaitBeforeContinue());
            isWaiting = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
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
        yield return new WaitForSeconds(15);
        navMeshEnemy.enabled = true;
        isWaiting = false;
    }
}

