using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    Rigidbody2D rb;
 
    [SerializeField] Vector2 position;
    public bool isTurning = false;
    public float velocityMagnitude;
    public int gear;
    public int absGear;
    public bool ignition = false;
    public float rpm;
    public float ratio;
    public float transmissionEfficiency;
    public float engineForce;
    public float traction;
    public float throttle;
    public float brake;
    public float steering;
    public Vector2 velocityRelative;
    public AudioHandler audioHandler;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        velocityMagnitude = rb.velocity.magnitude;
        traction = Mathf.Clamp01(-Mathf.Abs(rb.angularVelocity/1000)+1);
        velocityRelative = transform.InverseTransformDirection(rb.velocity);
        absGear = Mathf.Abs(gear);

        throttle = Mathf.Clamp01(Input.GetAxis("Throttle"));
        brake = Mathf.Clamp01(Input.GetAxis("Brake"));
        steering = -Input.GetAxis("Horizontal");

        rb.AddForce(transform.up * engineForce);
        rb.AddForce(transform.right * (-velocityRelative[0]) * traction);
        rb.AddTorque(steering * Mathf.Clamp(velocityRelative[1], -4f, 4f) * (6f+(Input.GetAxis("Jump")*8)));
        //rb.AddTorque(-steering * Mathf.Clamp(velocityRelative[1],-1.5f,0));

        if (velocityRelative[1] > 0){
            rb.AddForce((-transform.up * (Mathf.Clamp01(brake)) * traction) * (velocityRelative[1]*.8f));
            traction = traction - (Input.GetAxis("Jump")*.8f);
        }

        ///////////////////////////////
        
        rpm *= transmissionEfficiency;
  
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.V)){
            if (ignition == false && isTurning == false){
                StartCoroutine(Starter());
            }
            else{
                ignition = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X)){
            gear += 1;
        }

        if (Input.GetKeyDown(KeyCode.Z)){
            gear -= 1;
        }

        gear = Mathf.Clamp(gear, -1, 5);

        if (ignition == true){
            //rpm += 2.25f * (((Mathf.Clamp01(throttle)*((3.5f)+absGear/1.7f))))+1;
            //rpm += (2.35f * (absGear*2)+1) * ((Mathf.Clamp01(throttle)*6)*((1/(absGear+1)))*100)+1;
            //rpm *= ((throttle+1)*(1.04f-transmissionEfficiency));
            rpm += 400 * throttle * (rpm/4000) / (absGear+1);
            rpm += Random.Range(-3 * (rpm/2000), 3 * (rpm/2000));
            engineForce = (Mathf.Clamp(rpm-700, 0, rpm)/4000)*ratio;
            if (rpm < 900)
            {
                rpm += transmissionEfficiency*5;
            }
        }
        else
        {
            rpm *= .98f;
            engineForce = 0;
            gear = 0;
        }

        if (rpm > 5500){
            StartCoroutine(RevLimiter());
        }

        if (rpm < 350){
            ignition = false;
        }

        rpm = Mathf.Clamp(rpm, 0, 8000);

    if (gear == -1){
        ratio = -3.8f;
        transmissionEfficiency = 0.8960f;
    }
    if (gear == 0){
        ratio = 0f;
        transmissionEfficiency = 0.9999f;
    }
    if (gear == 1){
        ratio = 4.70f;
        transmissionEfficiency = 0.9660f;
    }
    if (gear == 2){
        ratio = 2.85f;
        transmissionEfficiency = 0.9738f;
    }
    if (gear == 3){
        ratio = 1.9f;
        transmissionEfficiency = 0.9836f;
    }
    if (gear == 4){
        ratio = 1.38f;
        transmissionEfficiency = 0.9917f;
    }
    if (gear == 5){
        ratio = 1f;
        transmissionEfficiency = .999f;
    }
    }


    
    

    //RATIOS

    IEnumerator RevLimiter(){
        float RevElapsedTime = 0f;

        while (RevElapsedTime < 0.1f)
        {
            rpm /= 1.01f;

            RevElapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Starter()
    {
        isTurning = true;
        float starterElapsedTime = 0f;
        audioHandler.audioSourceKeys.Play();

        while (starterElapsedTime < 1f)
        {   
            brake = 1;
            if (brake > .9f)
            {
            rpm += Mathf.Pow(4.8f, starterElapsedTime*3.5f);
            }

            starterElapsedTime += Time.deltaTime;
            yield return null;
        }


        ignition = true;
        isTurning = false;
    }

        void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Sidewalk")
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.65f, rb.velocity.y * 0.65f);
        }
    }
}
