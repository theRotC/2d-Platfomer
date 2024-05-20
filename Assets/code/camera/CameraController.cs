 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class cameraController : MonoBehaviour
{

     [SerializeField] private GameObject player;
     [SerializeField] private float cameraOffsetX;
     
     // [Range(0, 1f)]
     [SerializeField] private float cameraSpeed;
     
    void Start()
    {
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         Vector3 cameraDirection = new Vector3(player.transform.position.x + cameraOffsetX, transform.position.y, transform.position.z);
             transform.position = Vector3.Lerp(transform.position, cameraDirection, cameraSpeed * Time.deltaTime);
    }
}
