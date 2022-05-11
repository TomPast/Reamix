using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Text buttonText;
    // Start is called before the first frame update
    public void Click()
    {
        buttonText.text = "Ta cliqué enculé !";
    }
}
