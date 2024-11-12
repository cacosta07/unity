using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public MovementHandler movementHandler;
    public IEnumerator Starter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = (movementHandler.rpm) / 6000;
        audioSource.pitch = (movementHandler.rpm+3000) / 7500;
    }
}
