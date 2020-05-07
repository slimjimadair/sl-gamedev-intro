using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody myRigidBody;
    public float speed = 6;
    Vector3 velocity;
    int coinCount;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        myRigidBody.position += velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "Coin")
        {
            Destroy(triggerCollider.gameObject);
            coinCount += 1;
            print(coinCount + " coins");
        }
        
    }
}
