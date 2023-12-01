using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_FontAsset normal;
    public TMP_FontAsset dyslecktick;

    public controles controles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controles.dylcticFont)
        {
            text.font = dyslecktick;
        }
        else
        {
            text.font = normal;
        }
        text.fontSize = controles.fontSise;
    }
}
