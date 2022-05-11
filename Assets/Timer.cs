using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float timer = 20;
    public int timerint;
    public Text timerText;
    public int nb_minute;
    public string nom_du_joueur = "player";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerint = Mathf.RoundToInt(timer);

        timerText.text = "Temps restant : " + formatTimer(timerint);
        // PlayerPrefs.SetString("Player1", "Tom "+ScoringSystem.theScore);
        if (timerint > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timerint == 0)
        {
            Debug.Log("je suis la");
            List<string> scores = new List<string>();

            for (int i = 1; i < 6; i++)
            {
                scores.Add(PlayerPrefs.GetString(i.ToString()));
            }
            int j = 1;
            foreach (string item in scores)
            {
                string[] tmp = item.Split(' ');

                if (int.Parse(tmp[1]) < ScoringSystem.theScore)
                {
                    Debug.Log(j.ToString() + " " + ScoringSystem.theScore);
                    PlayerPrefs.SetString(j.ToString(), nom_du_joueur + ScoringSystem.theScore);
                    decallage(j + 1, j - 1, scores);
                    break;

                }
                j++;

            }

        }
    }
    public void decallage(int depart, int depart_liste, List<string> scores)
    {
        for (int i = depart; i < 5; i++)
        {
            PlayerPrefs.SetString(i.ToString(), scores[depart_liste]);
            depart_liste++;
        }
        SceneManager.LoadScene("Scenes/Menu/Menu");
    }
    string formatTimer(int timer)
    {
        nb_minute = 0;
        while (timer > 60)
        {
            timer /= 60;
            nb_minute++;
        }
        return nb_minute.ToString() + " : " + timer.ToString();

    }
}
