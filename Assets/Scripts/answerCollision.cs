using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class answerCollision : MonoBehaviour
{

    public TMP_Text thisText;
    public TMP_Text answerText;



    public GameObject circle;





    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    //Variable for tracking how often the bullet it shot
    private int howOften = 0;
    //Variable for tracking when the trigger is on or off (pull trigger it fires)
    private bool trigger;


     private void OnTriggerEnter2D(Collider2D other){


        Int32 integerNumber = Int32.Parse(thisText.text);
    

        if(integerNumber == circle.GetComponent<Collision>().answer){
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;

            trigger = true;
        }
        

        

     }


     void Update(){
        if(trigger){
            howOften ++;
            if(howOften % 240 == 0){
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            }
        }
    }
}
