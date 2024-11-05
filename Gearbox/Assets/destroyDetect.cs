using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDetect : MonoBehaviour
{
    public ParticleSystem particleSystem1;
    public MovementHandler movementHandler;
    public Sprite idle;
    public Sprite broken;
    public SpriteRenderer spriteRenderer;
    bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
        spriteRenderer.sprite = idle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player" && !destroyed)
    {
        if (movementHandler.velocityMagnitude > 2){
            destroyed = true;
            spriteRenderer.sprite = broken;
            particleSystem1.Play();
        }
    }
    }
}
