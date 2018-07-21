using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFellow : MonoBehaviour {
    
    public Transform Player;
    void Start()
    {
       
           Player = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x, Player.position.y, transform.position.z), Time.deltaTime * 3.0f);
    }
}
