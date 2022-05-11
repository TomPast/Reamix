using UnityEngine;
using Valve.VR;

public class Interactable : MonoBehaviour
{
    public int touchCount;//how many objects are currently in contact
    public SteamVR_Input_Sources Hand;//keep track of the active/first hand
    public bool gripped;
    public bool SecondGripped;
    void start()
    {
        if (gameObject.tag != "Grabbable")
        {
        }
    }
    private void OnCollisionEnter(Collision collision)//on a collison update touchcount
    {
        touchCount++;
    }
    private void OnCollisionExit(Collision collision)
    {
        touchCount--;
    }
}