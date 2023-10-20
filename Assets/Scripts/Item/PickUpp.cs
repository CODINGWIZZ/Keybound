using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpp : MonoBehaviour
{
    [SerializeField] Items items;
    public GameObject gameObject;
    public KeyCode interackt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interackt))
        {
            
            Destroy(gameObject);
        }
    }
}
