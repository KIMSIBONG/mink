using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashimpact : MonoBehaviour
{
    private float DashDestroyCool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DashDestroyCool+= Time.deltaTime;
        if (DashDestroyCool > 0.4)
        {

            Destroy(gameObject);
            
        }
    }
}
