using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
[Serializable]
public class cutscenepos {
    public Transform actposbegin;
    public float range;
    public PlayableDirector cutscene;
}
public class character : MonoBehaviour
{
    public List<cutscenepos> cutscene=new List<cutscenepos>();
    void Start()
    {
        selfri= GetComponent<Rigidbody>();
        selfanim= GetComponent<Animator>();
    }

    // Update is called once per frame
    private Rigidbody selfri;
    public Transform selftrans;
    private Animator selfanim;
    public GameObject interactbutton;
    //for control can move or not
    public GameObject cam;
    void Update()
    {
        selfri.velocity=new Vector3(selfri.velocity.x,selfri.velocity.y,Input.GetAxisRaw("Horizontal")*7);
        if (Input.GetKey(KeyCode.A)){
            selftrans.localRotation=Quaternion.Euler(-90,0,0);
            selfanim.SetBool("iswalking",true);
        }
        else if (Input.GetKey(KeyCode.D)){
            selfanim.SetBool("iswalking",true);
            selftrans.localRotation=Quaternion.Euler(-90,180,0);
        }
        else{
            selfanim.SetBool("iswalking",false);
        }
        //allow to move forward
        if(cam.GetComponent<camera>().moveforwardable==true){
            selfri.velocity=new Vector3(Input.GetAxisRaw("Vertical")*-7,selfri.velocity.y,selfri.velocity.z);
            if(Input.GetKey(KeyCode.W)){
                selfanim.SetBool("iswalking",true);
                selftrans.localRotation=Quaternion.Euler(-90,90,0);
            }
            if(Input.GetKey(KeyCode.S)){
                selfanim.SetBool("iswalking",true);
                selftrans.localRotation=Quaternion.Euler(-90,-90,0);
            }
        }
        // activate cutscene
        activatecutscene();
    }
    public void activatecutscene(){
        bool isinpos=false;
        for(int i=0;i<cutscene.Count;i++){
            if(selftrans.position.z>cutscene[i].actposbegin.position.z&&selftrans.position.z<cutscene[i].actposbegin.position.z+cutscene[i].range){
                interactbutton.SetActive(true);
                if(Input.GetKeyDown(KeyCode.F)){
                    cutscene[i].cutscene.Play();
                }
                isinpos=true;
            }
        }
        if(!isinpos){
            interactbutton.SetActive(false);
        }
    }
}
