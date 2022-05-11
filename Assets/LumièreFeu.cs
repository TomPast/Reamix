using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LumièreFeu : MonoBehaviour
{
    // Interpolate light color between two colors back and forth
    float duration = 1.0f;


    public Light lt;

    void Start()
    {
        //lt = GetComponent<Light>();
    }

    void Update()
    {
        // set light color
        lt.intensity = Random.Range(0.0f, 5.0f);

        float t = Mathf.PingPong(Time.time, duration) / duration;
        Color color0 = Color.red;
        Color color1 = Color.blue;
        lt.color = Color.Lerp(color0,color1, t);
    }
}
