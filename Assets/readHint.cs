using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class readHint : MonoBehaviour
{
    public Transform player;
    public float distanse;
    public bool canRead;

    public controles controles;

    Vector2 book2d;
    Vector2 player2d;

    public controles kontroles;
    public Movement movement;
    public Footstep footstep;
    public MouseMovement mouseMovement;
    public HeadbobSystem headbob;
    public FlachlightScript flachlight;

    public Image image;
    public TextMeshProUGUI hint;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        hint.enabled = false;
        image.enabled = false;
        movement.enabled = true;
        mouseMovement.enabled = true;
        footstep.enabled = true;
        headbob.enabled = true;
        flachlight.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        player2d = new Vector2(player.position.x, player.position.z);
        book2d = new Vector2(transform.position.x, transform.position.z);

        if (Vector2.Distance(player2d, book2d) <= distanse && Input.GetKeyDown(controles.interackt))
        {
            if (Input.GetKeyDown(kontroles.interackt) || Input.GetKeyDown(KeyCode.Escape))
            {
                hint.enabled = !hint.enabled;
                image.enabled = !image.enabled;
                movement.enabled = !movement.enabled;
                mouseMovement.enabled = !mouseMovement.enabled;
                footstep.enabled = !footstep.enabled;
                headbob.enabled = !headbob.enabled;
                flachlight.enabled = !flachlight.enabled;


            }
        }
    }
}
