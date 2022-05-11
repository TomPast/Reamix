using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telport : MonoBehaviour
{
    public Transform teleporttarget;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = teleporttarget.transform.position;
    }
}
