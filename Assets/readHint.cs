using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readHint : MonoBehaviour
{
    public Transform player;
    public float distanse;
    public bool canRead;

    public controles controles;

    Vector2 book2d;
    Vector2 player2d;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player2d = new Vector2(player.position.x, player.position.z);
        book2d = new Vector2(transform.position.x, transform.position.z);

        if (Vector2.Distance(player2d, book2d) <= distanse && Input.GetKeyDown(controles.interackt))
        {
            Debug.Log("asdflökjf");
        }
    }
}
