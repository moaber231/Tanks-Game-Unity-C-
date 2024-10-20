using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{    
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixesUpdate()
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
