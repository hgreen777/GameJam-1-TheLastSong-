using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectPosition = transform.position;

        if (objectPosition.y <= -3){
            Debug.Log("Reset");
        }
    }
}
