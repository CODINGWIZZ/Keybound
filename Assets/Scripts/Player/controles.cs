using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controles : MonoBehaviour
{
    //movment
    public KeyCode croutch;
    public KeyCode fram;
    public KeyCode bak;
    public KeyCode venster;
    public KeyCode höger;

    //interackt
    public KeyCode interackt;

    //ficklama av/på
    public KeyCode togelFicklampa;

    //hotbar
    public KeyCode slot1;
    public KeyCode slot2;
    public KeyCode slot3;
    public KeyCode slot4;

    //mous sens
    [Range (0, 10)]
    public float sens;

    //meue
    public bool dylcticFont;
    [Range(0, 100)]
    public float fontSise;
}
