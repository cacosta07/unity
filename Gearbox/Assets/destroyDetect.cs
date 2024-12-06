using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDetect : MonoBehaviour
{
    public ParticleSystem particleSystem1;
    public MovementHandler movementHandler;
    public Sprite idle;
    public Sprite[] frames;
    public Sprite[] brokenSprites;

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
        }else if (animType == myEnum.person)
        {
            StartCoroutine (PlayAnim());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player" && !destroyed && movementHandler.velocityMagnitude > 2){
        if (animType == myEnum.basic){
            destroyed = true;
            spriteRenderer.sprite = brokenSprites[0];
            particleSystem1.Play();
            yield break;
        }
        if (animType == myEnum.loop){
            destroyed = true;
            spriteRenderer.sprite = brokenSprites[0];
            particleSystem1.Play();
            yield break;
        }
        if (animType == myEnum.person){
            destroyed = true;
            spriteRenderer.sprite = brokenSprites[0];
            particleSystem1.Play();
            yield return new WaitForSeconds(1.5f);
            spriteRenderer.sprite = brokenSprites[1];
        }
        if (animType == myEnum.randomBreakSprite){
            destroyed = true;
            spriteRenderer.sprite = brokenSprites[Random.Range(0, brokenSprites.Length)];
            particleSystem1.Play();
            yield break;
        }
    }
    }
    IEnumerator PlayAnim(){
        while (!destroyed){
            if (frames.Length == 0){
                yield break;
            }
            for (int i = 0; i < frames.Length; i++){
                spriteRenderer.sprite = frames[i];
                yield return new WaitForSeconds(.3f);
                if (destroyed){
                    yield break;
                }
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
