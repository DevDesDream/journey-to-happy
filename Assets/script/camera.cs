
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[Serializable]
public class movecaminfor{  
    public float bg;
    public float ed;
    public Transform movepos;
    public GameObject walldisable;
}
[Serializable]
public class movecam{
    public List<movecaminfor> move=new List<movecaminfor>();
}
public class camera : MonoBehaviour
{
    private Transform selftrans;
    public Transform player;
    public movecam mov;
    //diable Cm
    public GameObject cm;
    //trigger
    public AnimationCurve curve;
    public Rigidbody playervel;
    public bool inpos=false;
    private int index;
    public bool moveable=false;
    public bool moveforwardable=false;
    void Start()
    {
        selftrans=GetComponent<Transform>();
    }
    void Update()
    {
        //setposinsidehouse
        for (int i = 0;i<mov.move.Count;i++){
            if (player.position.z<mov.move[i].ed&&player.position.z>mov.move[i].bg){
                transform.position =Vector3.Lerp(selftrans.position,mov.move[i].movepos.position,curve.Evaluate(0.1f));
                transform.rotation =Quaternion.Lerp(selftrans.rotation,mov.move[i].movepos.rotation,curve.Evaluate(0.1f));
                //walldisable
                mov.move[i].walldisable.SetActive(false);
                //disable follow
                cm.SetActive(false);
                //unlock move back or forward
                playervel.constraints &= ~RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
                inpos=true;
                moveforwardable=true;
                index=i;
            }
        }
        if(inpos==false){
            playervel.constraints = RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezeRotation;
            mov.move[index].walldisable.SetActive(true);
            transform.position =Vector3.Lerp(selftrans.position,cm.transform.position,0.1f);
            transform.rotation =Quaternion.Lerp(selftrans.rotation,cm.transform.rotation,0.1f);
            moveforwardable=false;
            if(math.abs(cm.transform.position.z-selftrans.position.z)<0.01f){
                cm.SetActive(true);
            }
            else{
                cm.transform.position =new Vector3(cm.transform.position.x,player.position.y+4.67f,player.position.z);
            }
        }
        inpos=false;
    }
}
