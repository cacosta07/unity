using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceKeys;
    public AudioSource audioSourceStall;
    [SerializeField] bool holdIgnitionValue = false;
    public MovementHandler movementHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = (movementHandler.rpm) / 6000;
        audioSource.pitch = (movementHandler.rpm+3000) / 7500;
        if (holdIgnitionValue == true && movementHandler.ignition == false){
            audioSourceStall.Play();
        }
        holdIgnitionValue = movementHandler.ignition;
    }
}
