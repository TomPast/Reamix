using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    // Start is called before the first frame update
    //public AudioSource audio;
    //public AudioClip bruitage;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "collectable")
        {
            ScoringSystem.theScore += 1;
            Destroy(other.gameObject);
        }
        
        //audio.PlayOneShot(bruitage, 0.1f);
    }
}
