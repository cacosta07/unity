using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleHandler : MonoBehaviour
{
    public ParticleSystem particleSystem1;
    public MovementHandler movementHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movementHandler.velocityMagnitude > 80){
            particleSystem1.Play();
        }
    }
}
