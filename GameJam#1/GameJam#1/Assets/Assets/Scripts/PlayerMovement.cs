using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D pMovement;
    

    [SerializeField]
    float horizontalMovement = 0f;
    [SerializeField]
    float runSpeed = 40f;
    [SerializeField]
    bool jumping;
    [SerializeField]
    bool crouch;

    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetKeyDown(KeyCode.Space)){
            jumping = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            crouch = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl)){
            crouch = false;
        }

        
    }

    void FixedUpdate(){
        pMovement.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jumping);
        jumping = false;
    }
}
