using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionscript : MonoBehaviour
{
    private float explosiontime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        explosiontime += Time.deltaTime;
        if (explosiontime > 0.4)
        {

            Destroy(gameObject);

        }
    }
}
