using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using VRTK;


public class returnToHisPosition : MonoBehaviour
{
    
    Vector3 posStart;
    Vector3 scaleInit;
    Vector3 scale;
    bool isGrabbed;
    bool earthIsGrabbed;
    GameObject position;

    /*Timer*/
    float startTime = 0.0f;
    bool startCount = false;

    // Speed in units per sec.
    public float speed;
    public string positionDesiree;
    public string sceneDesiree;


    // Use this for initialization
    /*
    void Start()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUngrabbed);
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);


        scaleInit = transform.localScale;
        isGrabbed = false;
        speed = 1f;
        Debug.Log("speed : " + speed);

        position = GameObject.Find(positionDesiree);
        posStart = position.transform.position;

    }


    private void ObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = false;
        transform.localScale = scaleInit;

    }

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = true;
        Debug.Log(transform.localScale.ToString());

    }




    // Update is called once per frame
    void Update()
    {


        if (isGrabbed)
        {
            if (!startCount)
            {
                startTime = Time.time;
                startCount = true;
            }

            position = GameObject.Find(positionDesiree);
            posStart = position.transform.position;
            scale.Set(transform.localScale.x + 0.001f, transform.localScale.y + 0.001f, transform.localScale.z + 0.001f);
            transform.localScale = scale;

            if (startTime + 3.0f < Time.time)
            {
                print("3 secondes depuis le grabbed !");

                SceneManager.LoadScene(sceneDesiree);
            }
        }

        if (!isGrabbed)
        {

            startTime = 0.0f;
            startCount = false;

            position = GameObject.Find(positionDesiree);
            posStart = position.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, posStart, speed * Time.deltaTime);
        }

    }
    */
}
