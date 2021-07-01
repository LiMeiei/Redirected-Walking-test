using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectedJumping : MonoBehaviour
{
    // [SerializeField]
    // public GameObject ovr_Rig;
    [SerializeField]
    moveDuePlayer mdp;

    [SerializeField]
    public GameObject centerCamera;
    [System.NonSerialized]
    public float InitialY;
    [System.NonSerialized]
    public bool flag = true;
    int countW, countJ;
    int separateW, separateJ;
    float LastPosX, LastPosZ;
    [SerializeField]
    float _CurvatureGain;
    float Distance;
    // Start is called before the first frame update
    void Start()
    {
        LastPosX = centerCamera.transform.position.x;
        LastPosZ = centerCamera.transform.position.z;
        InitialY = centerCamera.transform.position.y;
        countJ = 0;
        countW = 0;
        separateW = 1;
        separateJ = 1;

    }

    // Update is called once per frame
    void Update()
    {
        // if (Mathf.Sqrt(Mathf.Pow(centerCamera.transform.position.x - LastPosX, 2) + Mathf.Pow(centerCamera.transform.position.z - LastPosZ, 2)) >= 1)
        // {
        //     this.transform.position += centerCamera.transform.right * Mathf.Tan(10 * Mathf.Deg2Rad);
        //     LastPosX = centerCamera.transform.position.x;
        //     LastPosZ = centerCamera.transform.position.z;
        // }
        Distance = Mathf.Sqrt(Mathf.Pow(mdp.MoveX, 2) + Mathf.Pow(mdp.MoveZ, 2));
        if (centerCamera.transform.position.y - InitialY > 0.05f)
        {

            flag = true;
            countJ++;
            if (separateJ != 1)
            {
                Debug.Log(separateJ);
                // Debug.Log("Curvature");

                // Vector3 _OperationAmount = centerCamera.transform.right * Mathf.Tan(_CurvatureGain * Mathf.Deg2Rad) * Distance;
                // Debug.Log(_OperationAmount.x + " " + _OperationAmount.z);
                // this.transform.position += _OperationAmount;
                this.transform.RotateAround(centerCamera.transform.position, Vector3.up, (float)(_CurvatureGain / separateJ));
            }
            // Debug.Log("Jumping");
            if (countW != 0)
            {
                // Debug.Log("count W : " + countW);
                separateW = countW;
                countW = 0;
            }
        }
        else
        {
            countW++;
            if (flag && Mathf.Abs(centerCamera.transform.position.y - InitialY) < 0.02f)
            {
                flag = false;
                // if(separateW != 1){

                // }
                // Debug.Log("Landing");
            }
            // this.transform.position += centerCamera.transform.right * Mathf.Tan((5f / 15) * Mathf.Deg2Rad);
            if (countJ != 0)
            {
                // Debug.Log("count J : " + countJ);
                separateJ = countJ;
                countJ = 0;
            }
        }
    }
}
