using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rpmmanager : MonoBehaviour
{
    public MovementHandler movementHandler;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.GetComponent<Image>().color = new Color32(255,255,255,255);
    }

    // Update is called once per frame
    void Update()
    {
        var eulerAngles = transform.eulerAngles;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(eulerAngles.x, eulerAngles.y, (-movementHandler.rpm/22.35f)+135), 0.5f);
        if (movementHandler.ignition == false & movementHandler.isTurning == false){
            image.GetComponent<Image>().color = new Color32(255,255,255,100);
        }
        else{
            image.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
    }
}
