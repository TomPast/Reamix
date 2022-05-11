using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finduniveau : MonoBehaviour
{
    public string nom_du_joueur;

    private void Start()
    {
        nom_du_joueur = PlayerPrefs.GetString("nomJoueur");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "fin")
        {
            Debug.Log("Tu es arrive à la fin");
            List<string> scores = new List<string>();

            for (int i = 1; i < 6; i++)
            {
                scores.Add(PlayerPrefs.GetString(i.ToString()));
            }
            int j = 1;
            /*
            foreach (string item in scores)
            {
                string[] tmp = item.Split(' ');

                if (int.Parse(tmp[1]) < ScoringSystem.theScore * (Timer1.timer) / 10)
                {
                    Debug.Log(j.ToString() + " " + ScoringSystem.theScore);
                    PlayerPrefs.SetString(j.ToString(), nom_du_joueur + " " + Mathf.RoundToInt(ScoringSystem.theScore * (Timer1.timer) / 10));
                    decallage(j + 1, j - 1, scores);
                    break;

                }
                j++;
            }*/
            SceneManager.LoadScene("Assets/Western.unity");
        }
        else if(other.tag == "fin2")
        {
            SceneManager.LoadScene("Assets/testMenu/MenuTest.unity");
        }
        
    }
    public void decallage(int depart, int depart_liste, List<string> scores)
    {
        for (int i = depart; i < 5; i++)
        {
            PlayerPrefs.SetString(i.ToString(), scores[depart_liste]);
            depart_liste++;
        }
        SceneManager.LoadScene("Assets/Western.unity");
    }
}
