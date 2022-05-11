using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    // Récupère les meilleurs scores dans la mémoire et les affiche
    public GameObject ScoreText;
    void Start()
    {
        Text txt = ScoreText.GetComponent<Text>();
        txt.text = "Meilleur Score\n\n";
        if (PlayerPrefs.HasKey("1"))
        {
            txt.text += "1."+PlayerPrefs.GetString("1")+"\n\n";
        }
        else
        {
            txt.text += "1. NONE"+"\n\n";
        }
        if (PlayerPrefs.HasKey("2"))
        {
            txt.text += "2."+PlayerPrefs.GetString("2")+ "\n\n";
        }
        else
        {
            txt.text += "2. NONE" + "\n\n";
        }
        if (PlayerPrefs.HasKey("3"))
        {
            txt.text += "3."+PlayerPrefs.GetString("3")+ "\n\n";
        }
        else
        {
            txt.text += "3. NONE" + "\n\n";
        }
        if (PlayerPrefs.HasKey("4"))
        {
            txt.text += "4." + PlayerPrefs.GetString("4") + "\n\n";
        }
        else
        {
            txt.text += "4. NONE" + "\n\n";
        }
        if (PlayerPrefs.HasKey("5"))
        {
            txt.text += "5." + PlayerPrefs.GetString("5") + "\n\n";
        }
        else
        {
            txt.text += "5. NONE" + "\n\n";
        }
    }
}
