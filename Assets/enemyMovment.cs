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

    public Vector3 startTransform;

    public float agrorange;

    [Range(0f, 360f)]
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstical;

    public Movement spawn;


    public float warningdis;
    public float stillcount;
    public Transform lasttransform;

    //public Collider collider;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        startTransform = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
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
            if (transform.position.x != playerLastSeen.x && transform.position.z != playerLastSeen.z)
            {
                navMeshAgent.destination = playerLastSeen;
            }
            else if (transform.position == playerLastSeen)
            {
                Debug.Log("bin her don this");
                playerLastSeen = new Vector3(0, 0, 0);
            }
            else
            {
                playerLastSeen = new Vector3(0, 0, 0);
            }
        }
        if(lasttransform.position == transform.position)
        {
            stillcount += Time.deltaTime;
        }
        if (stillcount >= 5)
        {
            playerLastSeen = new Vector3 (0,0,0);
            stillcount = 0;
        }
        else
        {
            stillcount = 0; 
        }
        lasttransform = transform;

        FindeVispelTargets();
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

                if(!Physics.Raycast(transform.position, dirToTarget, agrorange, obstical))
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
        Debug.Log(Vector3.Distance(transform.position, playeTransform.position));

        if (Vector3.Distance(transform.position, playeTransform.position) < 3|| transform.position.x == playeTransform.position.x && transform.position.z == playeTransform.position.z && spawn.isCrouched == true)
        {
            transform.position = startTransform;
            playerLastSeen = new Vector3(0, 0, 0);
            playeTransform.position = spawn.spawnPos;
        }
    }
}
