using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovment : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public int n;

    [SerializeField]
    private List<Transform> position;

    public bool movStart;

    public Transform fuckUP;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        /*if (n <= position.Count && !movStart)
        {
            if (n == position.Count && transform.position == position[n].position)
            {
                movStart = true;
            }
            else if (transform.position == position[n].position)
            {
                n++;
                navMeshAgent.destination = position[n].position;
            }
            
        }
        else if (n >= 0 && movStart)
        {
            if (n == 0 && transform.position == position[n].position)
            {
                movStart = false;
            }
            else if (transform.position == position[n].position)
            {
                n--;
                navMeshAgent.destination = position[n--].position;
            }
            
        }*/

        //navMeshAgent.destination = fuckUP.position;

        if (transform.position.x == position[0].position.x && transform.position.z == position[0].position.z)
        {
            n = 1;
        }
        else if (navMeshAgent.destination.x == position[1].position.x && transform.position.z == position[1].position.z)
        {
            n = 0;
        }
        navMeshAgent.destination = position[n].position;
    }
}
