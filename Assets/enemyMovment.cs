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

    public Vector3 playerLastSeen;
    public Transform playeTransform;

    public Transform startTransform;

    public float agrorange;

    [Range(0f, 360f)]
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstical;

    public Movement spawn;

    public float warningdis;

    public Collider collider;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        startTransform = transform;
    }

    private void Update()
    {
        if (playerLastSeen == new Vector3(0, 0, 0))
        {
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
        else
        {
            if (transform.position != playerLastSeen)
            {
                navMeshAgent.destination = playeTransform.position;
            }
            else
            {
                playerLastSeen = new Vector3(0, 0, 0);
            }
        }

        FindeVispelTargets();
        warning(transform.position, playerLastSeen, warningdis, targetMask);
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public void FindeVispelTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, agrorange, targetMask);

        for(int i = 0; i <targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget)< angle / 2)
            {
                float disTotarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, dirToTarget, disTotarget, obstical))
                {
                    Debug.Log("I see you");
                    playerLastSeen = playeTransform.position;
                    YouDide();

                }
            }
        }
    }

    public void YouDide()
    {
        if (Vector3.Distance(transform.position, playeTransform.position) < 1.5 || transform.position.x == playeTransform.position.x && transform.position.z == playeTransform.position.z && spawn.isCrouched == true)
        {
            transform.position = startTransform.position;
            playerLastSeen = new Vector3(0, 0, 0);
            playeTransform.position = spawn.spawnPos;
        }
    }

    public void warning(Vector3 orgin, Vector3 diraction, float maxdis, int layermask)
    {
        if (Physics.Raycast(orgin, diraction, maxdis, layermask))
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
    }
}
