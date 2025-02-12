using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private Rigidbody selfri;
    private Transform selftrans;
    private Animator selfanim;
    //for control can move or not
    public GameObject cam;
    void Update()
    {
        selfri= GetComponent<Rigidbody>();
        selfanim= GetComponent<Animator>();
        selfri.velocity=new Vector3(selfri.velocity.x,selfri.velocity.y,Input.GetAxisRaw("Horizontal")*7);
        selftrans=GetComponent<Transform>();
        if (Input.GetKey(KeyCode.A)){
            selftrans.localScale= new Vector3(1,1,-1);
            selfanim.SetBool("iswalking",true);
        }
        else if (Input.GetKey(KeyCode.D)){
            selftrans.localScale= new Vector3(1,1,1);
            selfanim.SetBool("iswalking",true);
        }
        else{
            selfanim.SetBool("iswalking",false);
        }
        if(cam.GetComponent<camera>().moveforwardable==true){
            selfri.velocity=new Vector3(Input.GetAxisRaw("Vertical")*-7,selfri.velocity.y,selfri.velocity.z);
        }
    }
}
