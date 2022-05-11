using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initplayerpref : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 1; i < 6; i++)
        {
            PlayerPrefs.SetString(i.ToString(), "player 0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
