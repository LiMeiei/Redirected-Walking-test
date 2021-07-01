using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redirection : MonoBehaviour
{
    [SerializeField]
    public GameObject ovr_Rig;

    [SerializeField]
    OVRHand leftHand;

    [SerializeField]
    public GameObject centerCamera;
    [SerializeField]
    moveDuePlayer mdp;
    [SerializeField]
    float _TranslationGain;

    public static Vector3 latestPos;
    public static Vector3 latestAng;
    public static Quaternion latestRot;
    public static Quaternion latestRotation;

    public static Vector3 StartPosY;

    float Distance;

    GameObject[] MainCamera;

    void Start()
    {
        latestPos = centerCamera.transform.position;
        // latestAng = ovr_Rig.transform.eulerAngles;
        latestAng = centerCamera.transform.eulerAngles;
        latestRot = centerCamera.transform.rotation;

    }

    public void save()
    {
        Debug.Log("redirection saved");
        PlayerPrefs.SetFloat("rem_Pos_x", latestPos.x);
        PlayerPrefs.SetFloat("rem_Pos_y", latestPos.y);
        PlayerPrefs.SetFloat("rem_Pos_z", latestPos.z);
        PlayerPrefs.SetFloat("rem_Ang_y", latestAng.y);
        PlayerPrefs.SetFloat("rem_Ang_z", latestAng.z);
    }
    public void load()
    {
        Debug.Log("redirection loaded");
        latestPos.x = PlayerPrefs.GetFloat("rem_Pos_x");
        latestPos.y = PlayerPrefs.GetFloat("rem_Pos_y");
        latestPos.z = PlayerPrefs.GetFloat("rem_Pos_z");
        latestAng.x = PlayerPrefs.GetFloat("rem_Ang_x");
        latestAng.y = PlayerPrefs.GetFloat("rem_Ang_y");
        latestAng.z = PlayerPrefs.GetFloat("rem_Ang_z");
    }

    void Update()
    {
        bool isFingerPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        /*
        if(isFingerPinching) {
            Debug.Log(
                leftHand.PointerPose.position.x + "," + 
                leftHand.PointerPose.position.y + "," +
                leftHand.PointerPose.position.z
                );
        }
        */

        string name = SceneManager.GetActiveScene().name;

        /* translation gain */

        Vector3 ovr_Rig_Pos = ovr_Rig.transform.position;
        Vector3 centerCamera_Pos = centerCamera.transform.position;

        Vector3 moveLength = centerCamera_Pos - latestPos;

        // float x = 0;
        // if(name == "t 0.5"){
        //     x = -5E-1f;
        // }
        // else if(name == "t 0.8"){
        //     x = -2E-1f;
        // }
        // else if(name == "t 1" || name == "r"){
        //     x = 0;
        // }
        // else if(name == "t 1.26"){
        //     x = 26E-2f;
        // }
        // else if(name == "t 2"){
        //     x = 1;
        // }

        if (SceneManager.GetActiveScene().name != "r" && SceneManager.GetActiveScene().name != "c 1.2")
        {
            Distance = Mathf.Sqrt(Mathf.Pow(mdp.MoveX, 2) + Mathf.Pow(mdp.MoveZ, 2));
            // ovr_Rig.transform.position +=  new Vector3(
            //     moveLength.x * x,
            //     // 0,
            //     // moveLength.y,
            //     0,
            //     // moveLength.z * x
            //     0
            // );
            // this.transform.position += centerCamera.transform.position.x * Distance * (_TranslationGain - 1);
            latestPos = centerCamera.transform.position;
        }


        // else if(name == "c 1.2")
        // {
        //     /* curvature gain */

        // }

        // Debug.Log("centercamera.transform.position.z:" + centerCamera.transform.position.z);


        if (SceneManager.GetActiveScene().name == "r")
        {
            /* rotation gain */

            Vector3 ovr_Rig_Ang = ovr_Rig.transform.eulerAngles;
            Vector3 centerCamera_Ang = centerCamera.transform.eulerAngles;

            // Vector3 moveAngle = ovr_Rig_Ang - latestAng;
            Vector3 moveAngle = centerCamera_Ang - latestAng;
            if (moveAngle.y != 0)
            {
                ovr_Rig.transform.Rotate(
                0,
                moveAngle.y * (float)0.2,
                // 0, 
                0, Space.World);
            }

            latestAng = ovr_Rig.transform.eulerAngles;
            latestAng = centerCamera.transform.eulerAngles;

            // Quaternion ovr_Rig_Rotation = ovr_Rig.transform.rotation;

            // Quaternion diffRotation = latestRot * Quaternion.Inverse(ovr_Rig_Rotation);

            // ovr_Rig.transform.rotation = Quaternion.LookRotation()
        }



    }
}
