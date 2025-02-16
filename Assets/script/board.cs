using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        self =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private Rigidbody self;
    public float speed=0;
    private float time=0;
    public float range=0;
    void Update()
    {
        time+=Time.deltaTime*speed;
        self.velocity= new Vector3(self.velocity.x,Mathf.Sin(time)*range,self.velocity.z);
    }
}
