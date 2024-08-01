using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WinePour : MonoBehaviour
{

    public GameObject wineStream;
    public Transform wineBottle;
    public Transform bottleTop;

    private bool isPouring = true;
    private bool pourCheck;

    public float topBottle;
    public float midBottle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        topBottle = bottleTop.position.y;
        midBottle = wineBottle.position.y;
        pourCheck = midBottle > topBottle;

        if (isPouring != pourCheck)
        {
           isPouring = pourCheck;
           wineStream.SetActive(isPouring);
        }
        else
        {
            
        }
       


    }
}
