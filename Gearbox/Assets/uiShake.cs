using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiShake : MonoBehaviour
{

    public MovementHandler movementHandler;
    [SerializeField] Vector3 FixedPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(FixedPosition[0] + Mathf.Sin(movementHandler.velocityMagnitude), FixedPosition[1], transform.position.z);
    }
}
