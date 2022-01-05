using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject player;
    public TMP_Text txt;
    private int high;
    public float highest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x = (int)player.transform.position.y;
        if (x > high)
        {
            high = x;
            highest = player.transform.position.y;
        }
        
            txt.text = high.ToString();
    }
}
