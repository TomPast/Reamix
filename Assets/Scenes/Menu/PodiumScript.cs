using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PodiumScript : MonoBehaviour
{
    public int Place;
    public GameObject PanelText;
    // Start is called before the first frame update
    void Start()
    {
        Text txt = PanelText.GetComponent<Text>();
        if (PlayerPrefs.HasKey("Player" + Place.ToString()))
        {
            txt.text = PlayerPrefs.GetString("Player"+Place.ToString());
        }
    }
}
