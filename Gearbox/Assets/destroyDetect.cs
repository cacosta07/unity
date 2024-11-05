using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDetect : MonoBehaviour
{
    public ParticleSystem particleSystem1;
    public MovementHandler movementHandler;
    public Sprite wave1;
    public Sprite wave2;
    public Sprite broken1;
    public Sprite broken2;

    public SpriteRenderer spriteRenderer;
    bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
        spriteRenderer.sprite = wave1;
        StartCoroutine (PlayAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player" && !destroyed)
    {
        if (movementHandler.velocityMagnitude > 2){
            destroyed = true;
            spriteRenderer.sprite = broken1;
            particleSystem1.Play();
            yield return new WaitForSeconds(2f);
            spriteRenderer.sprite = broken2;
        }
    }
    }
    IEnumerator PlayAnim(){
        while (!destroyed){
            yield return new WaitForSeconds(.3f);
            spriteRenderer.sprite = wave1;
            yield return new WaitForSeconds(.3f);
            spriteRenderer.sprite = wave2;
        }
    }
}
