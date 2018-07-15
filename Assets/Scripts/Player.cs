using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1.8f;
    public float horizontalLimit = 2.6f;
    public float firingSpeed = 3f;
    public float firingCooldownDuration = 1f;
    public GameObject missilePrefab;

    
    private float CooldownTimer;

    // Update is called once per frame
    void Update()
    {

        //Horizontal Movement
        GetComponent<Rigidbody2D>().velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed,
            0
            );

        //Keep the player inside the screen

        if (transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3(horizontalLimit, transform.position.y, transform.position.z);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        //Fire missiles

        CooldownTimer -= Time.deltaTime;

        if (CooldownTimer <= 0 && Input.GetAxis("Fire1") == 1f)
        {
            CooldownTimer = firingCooldownDuration;

            GameObject missileInstance = Instantiate(missilePrefab);
            missileInstance.transform.SetParent(transform.parent);
            missileInstance.transform.position = transform.position;
            missileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(
                0,
                firingSpeed
                );
            Destroy(missileInstance, 2f);

        }

    }
}
