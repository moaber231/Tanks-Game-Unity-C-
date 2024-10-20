using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTank : MonoBehaviour
{    
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
       // gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up,rotateSpeed);
    }
      private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Tank"){
            Destroy(gameObject);
        }
    }
}
