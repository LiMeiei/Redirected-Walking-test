using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDuePlayer : MonoBehaviour
{
    [SerializeField]
    redirection rdw;
    // [SerializeField]
    // GameObject player; 
    float distance;

    float InitialDistance;
    float latestz;
    float latestx;

    float MoveSum = 0;
    float FlameCnt = 0;
    [HideInInspector]
    public float MoveX,MoveZ;
    public Vector3 MoveVec;


    // Start is called before the first frame update
    void Start()
    {
        rdw=FindObjectOfType<redirection>();

        this.transform.position = new Vector3(
            rdw.ovr_Rig.transform.position.x ,
            this.transform.position.y,
            this.transform.position.z
        );
        Debug.Log("PlayerMovex : " + rdw.ovr_Rig.transform.position.x + " Guiderx : " + this.transform.position.x);
        distance =  Mathf.Abs(this.transform.position.z - rdw.ovr_Rig.transform.position.z);

        latestx = rdw.centerCamera.transform.position.x;
        latestz = rdw.centerCamera.transform.position.z;
        // InitialDistance = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - latestx, 2) + 
        //                              MMoveVecthf.Pow(this.transform.position.z - latestz, 2));
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = rdw.centerCamera.transform.position.x - latestx;
        MoveZ = rdw.centerCamera.transform.position.z - latestz;
        MoveVec = new Vector3(MoveX, 0, MoveZ);
        // this.transform.position += MoveVec + rdw.centerCamera.transform.right * MoveVec.magnitude * Mathf.Tan(30 * Mathf.Deg2Rad);
        latestx = rdw.centerCamera.transform.position.x;
        latestz = rdw.centerCamera.transform.position.z;
        // float PlayerMoveForward = Mathf.Sqrt(Mathf.Pow(MoveX,2) + Mathf.Pow(MoveZ, 2));
        // float PlayerMoveRight = PlayerMoveForward * Mathf.Tan(10 * Mathf.Deg2Rad);
        // if(FlameCnt == 10){
        //     Debug.Log("player.transform.position.z:" + rdw.centerCamera.transform.position.z);
        //     MoveSum = 0;
        //     FlameCnt=0;
        // }
        // this.transform.position += transform.forward * PlayerMoveForward;
        // FlameCnt++;
    }
}
