using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float RPM;
    private float turnspeed=50.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    public int horsePower=0;
    [SerializeField] GameObject centreOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI RPMtext;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // Update is called once per frame
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centreOfMass.transform.position;
    }
    void FixedUpdate()
    {
        //to move front and back
        forwardInput=Input.GetAxis("Vertical");

        //to move left and right
        horizontalInput=Input.GetAxis("Horizontal");

        if(IsOnGround())
        {
            //we will move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            //rotate while turning the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);  //conversion to kmph
            speedometerText.SetText(("Speed : " + speed + "kmph"));

            RPM = (speed % 30) * 40;
            RPMtext.SetText("RPM : " + RPM);
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
