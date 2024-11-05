using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafocus : MonoBehaviour
{
        public MovementHandler movementHandler;
        [SerializeField] float vel;
        public Cinemachine.CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vel = Mathf.SmoothStep(vel, movementHandler.velocityMagnitude, 0.2f);
        vcam.m_Lens.OrthographicSize = (vel/8)+5;

    }
}
