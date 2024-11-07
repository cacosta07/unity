using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiShake : MonoBehaviour
{

    public MovementHandler movementHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 position = transform.position;
        transform.position = new Vector3(position[0] + Mathf.Sin(movementHandler.velocityMagnitude), position[1] + Mathf.Sin(movementHandler.velocityMagnitude), transform.position.z);
    }
}
