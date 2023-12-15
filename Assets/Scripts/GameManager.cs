using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public controles globalControlls;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}
