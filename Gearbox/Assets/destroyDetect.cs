using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDetect : MonoBehaviour
{
    public ParticleSystem particleSystem1;
    public MovementHandler movementHandler;
    public Sprite idle;
    public Sprite frame0;
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite broken0;
    public Sprite broken1;
    public Sprite broken2;

    public myEnum animType = new myEnum();  // this public var should appear as a drop down
    public SpriteRenderer spriteRenderer;
    bool destroyed;




    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
        spriteRenderer.sprite = idle;
        if (animType == myEnum.loop){
            StartCoroutine (PlayAnim());
        }
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
            spriteRenderer.sprite = broken0;
            particleSystem1.Play();
            yield return new WaitForSeconds(2f);
            spriteRenderer.sprite = broken1;
        }
    }
    }
    IEnumerator PlayAnim(){
        while (!destroyed){
            if (frame0 != null){
                spriteRenderer.sprite = frame0;
                yield return new WaitForSeconds(.3f);
            }
            if (frame1 != null){
            spriteRenderer.sprite = frame1;
            yield return new WaitForSeconds(.3f);
            }
            if (frame2 != null){
            spriteRenderer.sprite = frame2;
            yield return new WaitForSeconds(.3f);
            }
            if (frame3 != null){
            spriteRenderer.sprite = frame3;
            yield return new WaitForSeconds(.3f);
            }
        }
    }
    public enum myEnum // your custom enumeration
    {
       basic, 
       loop, 
       person,
       randomBreakSprite
    };
}
