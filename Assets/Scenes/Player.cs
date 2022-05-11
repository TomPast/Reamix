using UnityEngine;
using Valve.VR;

public class Player : MonoBehaviour
{
    private Vector2 trackpad;
    private int GroundCount;
    private CapsuleCollider CapCollider;

    public SteamVR_Input_Sources MovementHand;//Set Hand To Get Input From
    public SteamVR_Input_Sources SnapHand;

    public SteamVR_Action_Vector2 TrackpadAction;
    public SteamVR_Action_Boolean JumpAction;
    public SteamVR_Action_Boolean SnapLeft;
    public SteamVR_Action_Boolean SnapRight;

    public float jumpHeight;
    public float MovementSpeed;
    public float maxSpeed = 0.0f;
    public float Deadzone;//the Deadzone of the trackpad. used to prevent unwanted walking.
    public float sensibilite = 0.1f;
    public float rotateIncrement = 45;

    public GameObject Head;
    public PhysicMaterial NoFrictionMaterial;
    public PhysicMaterial FrictionMaterial;
    private void Start()
    {
        CapCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        updateInput();
        updateCollider();
        //SnapRotation();
        calculateMovement();

    }

    public static float Angle(Vector2 p_vector2)
    {
        if (p_vector2.x < 0)
        {
            return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
        }
    }

    private void updateCollider()
    {
        CapCollider.height = Head.transform.localPosition.y;
        CapCollider.center = new Vector3(Head.transform.localPosition.x, Head.transform.localPosition.y / 2, Head.transform.localPosition.z);
    }

    private void updateInput()
    {
        trackpad = TrackpadAction.GetAxis(MovementHand);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GroundCount++;
    }
    private void OnCollisionExit(Collision collision)
    {
        GroundCount--;
    }

    private Quaternion calculateOrientation()
    {
        float rotation = Mathf.Atan2(TrackpadAction.axis.x, TrackpadAction.axis.y);
        rotation *= Mathf.Rad2Deg;

        Vector3 orientationEuler = new Vector3(0, Head.transform.localRotation.eulerAngles.y + rotation, 0);
        return Quaternion.Euler(orientationEuler);
    }

    private void SnapRotation()
    {
        float snapValue = 0.0f;
        if (SnapLeft.GetStateDown(SnapHand))
        {
            snapValue = -Mathf.Abs(rotateIncrement);
        }
        if (SnapRight.GetStateDown(SnapHand))
        {
            snapValue = Mathf.Abs(rotateIncrement);
        }
        transform.RotateAround(Head.transform.position, Vector3.up, snapValue);
    }

    private void calculateMovement()
    {
        Quaternion orientation = calculateOrientation();

        if (TrackpadAction.axis.magnitude == 0)
            MovementSpeed = 0;

        MovementSpeed += TrackpadAction.axis.magnitude * sensibilite;
        MovementSpeed = Mathf.Clamp(MovementSpeed, -maxSpeed, maxSpeed);
        Rigidbody RBody = GetComponent<Rigidbody>();
        Vector3 velocity = new Vector3(0, 0, 0);
        if (trackpad.magnitude > Deadzone)
        {//make sure the touch isn't in the deadzone and we aren't going to fast.
            CapCollider.material = NoFrictionMaterial;
            velocity = orientation * (MovementSpeed * Vector3.forward);
            if (JumpAction.GetStateDown(MovementHand) && GroundCount > 0)
            {
                float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * 9.81f);
                RBody.AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
            }
            RBody.AddForce(velocity.x * MovementSpeed - RBody.velocity.x, 0, velocity.z * MovementSpeed - RBody.velocity.z, ForceMode.VelocityChange);

            Debug.Log("Velocity" + velocity);
            Debug.Log("Movement Direction:" + orientation);
        }
        else if (GroundCount > 0)
        {
            CapCollider.material = FrictionMaterial;
        }
    }
}