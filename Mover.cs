using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class Mover : MonoBehaviour

{
    //our sphere is a rigid body and for us to manipulate it into our script we have to create an object
    //In Unity
    
    float timer = 0.0f;
     int points = 0;
   
//declare the color object
public Color goodColor;
public Color badColor;

   public GameObject Cylinder;
//we declare a diff gameobject for the police car
    public GameObject TT_demo_male_B;
    public GameObject PoliceCar;
    public Rigidbody rb;
   



//we declare the text object here
public TMP_Text myText;
// Start is called before the first frame update
void Start()
{
   
}
// Update is called once per frame
void Update()
{

    if (Input.GetKey(KeyCode.W))
    {
        rb.transform.Translate(0f, 0f, 0.5f);
    }
        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Translate(0f, 0f, -0.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Translate(-0.5f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Translate(0.5f, 0f, 0f);
        }
       myTimer();
       if(points >=25)
       {
        SceneManager.LoadScene("Level2");
       }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Cylinder)
        {
           
            points = points + 5;

            Vector3 InstOffset = new Vector3( 0F, 0F, 6F);
            Vector3 newPost = Cylinder. transform.position +InstOffset;
            Debug.Log ("OH NO");
            var clone= Instantiate(Cylinder, newPost,Quaternion.identity);
            Destroy(Cylinder);
          // rb.GetComponent<Renderer>().material.color = goodColor;
            clone.name ="Cylinder";
            Cylinder=clone;
        }

     if(collision.gameObject == PoliceCar)
     {
            points = points -2;

            Vector3 InstOffset = new Vector3( -2.5F, 0F, 6F);
            Vector3 newPost = Cylinder. transform.position +InstOffset;
            Debug.Log ("polce car has been hit!");
            var Fclone= Instantiate(Cylinder, newPost,Quaternion.identity);
            Destroy(Cylinder);
            //rb.GetComponent<Renderer>().material.color = badColor;
            Fclone.name ="PoliceCar";
            Cylinder=Fclone;
     }
         
    }
    public void myTimer()
    {
        //count using delta time
      timer += Time.deltaTime;
        //convert to seconds
        float seconds = timer % 60;
        //remove decimal places
        int secShort = (int)seconds;
   
        myText.text= "Time: "+secShort.ToString()+
         " Seconds" + "\n\n" + "points: " + points.ToString()+"points.";
      
     
    }
     
};
