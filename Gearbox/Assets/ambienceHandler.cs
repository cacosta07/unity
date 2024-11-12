using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambienceHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public MovementHandler movementHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = movementHandler.velocityMagnitude / 20;
        audioSource.pitch = (movementHandler.velocityRelative[1] + 10) / 15;
    }
}
