using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mort : MonoBehaviour
{
    public GameObject teleporttarget;
    void Update()
    {
        if (this.transform.position.y<-5)
        {
            Debug.Log("Tombe !");
            this.transform.position = teleporttarget.transform.position;
        }
        
    }
}
