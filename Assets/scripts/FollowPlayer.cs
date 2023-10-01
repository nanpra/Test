using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //takes reference variable data type
    public GameObject player;

    //placing the camera perfectly behind the car
    //takes vector varible data type with 3 vectors
    public Vector3 follow=new Vector3(0,4,-8);

    // Update is called once per frame
    //lateupdate->no shittering
    void LateUpdate()
    {
        transform.position = player.transform.position + follow;
    }
}
