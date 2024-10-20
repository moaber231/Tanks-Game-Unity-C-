using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3 : MonoBehaviour
{
   public float tc;
    public float h;
    public float s;
    public float w;
    // Start is called before the first frame update
    void Start()
    { 
        s=3;
        h=6;
        w=7;
    }

    // Update is called once per frame
    void Update()
    {
        tc+=Time.deltaTime*s;
        float x=Mathf.Cos(tc)*s;
        float y=transform.position.y;
        float z=transform.position.z;
        transform.position = new Vector3(x, y, z);
        
    }
      private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Tank"){
            Destroy(gameObject);
        }
    }
}
