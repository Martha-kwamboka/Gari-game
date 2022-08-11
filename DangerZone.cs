using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    //Declare the light object
    public Light mylight;
    // Start is called before the first frame update
    public float duration = 50.0F;

    //Create an audio source object
    public AudioSource alarm;
    //create an audio source object for the soft music
    public AudioSource softmusic;
    //create an audio source object for the loud music
    public AudioSource loudmusic;
    //We define the fade time
    public float FadeTime = 5.0F;
    //Create a particle emission object
    public ParticleSystem ps;
 
    void Start()
    {
        //We declare an emission variable: used for playing or stoping the
        //particle emission effect
        var em = ps.emission;
        em.enabled = false;

        loudmusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {//The initial function called immediately you enter the trigger area
        Debug.Log("Entered Danger Zone!");

        //we play the alarm
        alarm.Play();
        //stop soft music
        softmusic.volume = Mathf.Lerp(0, softmusic.volume, FadeTime);
        softmusic.volume -= softmusic.volume;
        //play the loud music
        loudmusic.Play();
        //emit the particles
        var em = ps.emission;
        em.enabled = true;




    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Out of Danger!");
        //Execute logic required after you exit the trigger area
        mylight.intensity = 1;
        //Change the color back to the original color
        mylight.color = Color.white;
        softmusic.Play();
        loudmusic.volume = Mathf.Lerp(0, loudmusic.volume, FadeTime);

        //We stop the alarm
        alarm.Stop();
        //we stop the smoke
        var em = ps.emission;
        em.enabled = false;


    }

    void OnTriggerStay(Collider other)
    {
        //whatever you wish to do recursively while inside the trigger zone should be done here
         mylight.intensity = Mathf.PingPong(Time.time, 1);
        //we define the time within which the color will change
        float t = Mathf.PingPong(Time.time, duration) / duration;
        //we change the color
        mylight.color = Color.Lerp(Color.red, Color.red, t);

    }
   
}
