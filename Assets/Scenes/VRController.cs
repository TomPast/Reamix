using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRController : MonoBehaviour
{
    public float gravity = 30.0f;
    public float sensibilite = 0.1f;
    public float maxSpeed = 1.0f;

    public SteamVR_Action_Boolean jumpAction = null;
    public SteamVR_Action_Vector2 moveValue = null;

    public float jumpHeight;

    private float speed = 0.0f;

    private CharacterController characterController = null;
    private Transform cameraRig = null;
    private Transform head = null;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        cameraRig = SteamVR_Render.Top().origin;
        head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleHead();
        HandleHeight();
        CalculateMovement();
  
    }

    void HandleHead()
    {
        Vector3 oldPosition = cameraRig.position;
        Quaternion oldRotation = cameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, head.rotation.eulerAngles.y, 0.0f);

        cameraRig.position = oldPosition;
        cameraRig.rotation = oldRotation;
    }

    private void CalculateMovement()
    {
        Quaternion orientation = calculateOrientation();
        Vector3 movement = Vector3.zero;

        if (moveValue.axis.magnitude == 0)
            speed = 0;

   
        
        speed += moveValue.axis.magnitude * sensibilite;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        movement += orientation * (speed * Vector3.forward);      
        movement.y -= gravity * Time.deltaTime;

        characterController.Move(movement*Time.deltaTime);
    }

    void HandleHeight()
    {
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        characterController.height = headHeight;

        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        newCenter.x = head.localPosition.x;
        newCenter.z = head.localPosition.z;

        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;


        characterController.center = newCenter;
    }

    private Quaternion calculateOrientation()
    {
        float rotation = Mathf.Atan2(moveValue.axis.x, moveValue.axis.y);
        rotation *= Mathf.Rad2Deg;

        Vector3 orientationEuler = new Vector3(0, head.eulerAngles.y + rotation, 0);
        return Quaternion.Euler(orientationEuler);
    }
}
