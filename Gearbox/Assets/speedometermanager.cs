using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedometermanager : MonoBehaviour
{
    public MovementHandler movementHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var eulerAngles = transform.eulerAngles;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(eulerAngles.x, eulerAngles.y, (-Mathf.Abs(movementHandler.velocityRelative[1]*10))+111), 0.2f);
    }
}
