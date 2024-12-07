using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private GameObject myEnemy, myPlayer;
    private NavMeshAgent navMeshEnemy;
    void Start()
    {
        myPlayer = GameObject.Find("Player");
        myEnemy=this.gameObject;
        navMeshEnemy = myEnemy.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshEnemy.destination = myPlayer.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(myPlayer);
        }
    }
}

