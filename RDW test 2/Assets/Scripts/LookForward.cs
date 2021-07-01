using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LookForward : MonoBehaviour
{
    [SerializeField]
    HandRayCast HandRay;
    [SerializeField]
    RedirectedJumping RDJ;
    [SerializeField]
    GameObject centerCamera;
    [SerializeField]
    GameObject Scene;
    [SerializeField]
    GameObject Guider;

    float StartPosX, StartPosZ;
    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        HandRay._CStimer = 0;
        RDJ.InitialY = RDJ.centerCamera.transform.position.y;
        HandRay._stopPinching = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            Debug.Log("check");
            _OneFrane();
            flag = false;
        }
        LookToFront();
    }

    void _OneFrane()
    {
        StartPosX = centerCamera.transform.position.x;
        Debug.Log(centerCamera.transform.position.x);
        StartPosZ = centerCamera.transform.position.z;
        Debug.Log(centerCamera.transform.position.z);
    }

    public void LookToFront()
    {

        Image ButtonImage = GetComponent<Image>();
        Color ButtonColor = ButtonImage.color;
        RaycastHit hit;

        if (Physics.Raycast(HandRay.positions[0], HandRay._hand.PointerPose.forward, out hit) &&
            HandRay._hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {

            ButtonImage.color = new Color(ButtonColor.r, ButtonColor.g, ButtonColor.b, 0.5f);
            if (hit.collider.tag == this.gameObject.tag)
            {
                HandRay._stopPinching = true;
                HandRay._CStimer += Time.deltaTime;
                if (HandRay._CStimer >= 1.0f)
                {
                    HandRay._CStimer = 0;
                    Debug.Log("LookForward");
                    Debug.Log((centerCamera.transform.position.x - StartPosX) + " " + (centerCamera.transform.position.z - StartPosZ));
                    Debug.Log(centerCamera.transform.position.y * 100);

                    Scene.transform.position += new Vector3(centerCamera.transform.position.x - StartPosX, 0, centerCamera.transform.position.z - StartPosZ);
                    Scene.transform.RotateAround(centerCamera.transform.position, new Vector3(0, 1, 0), centerCamera.transform.eulerAngles.y - Scene.transform.eulerAngles.y);
                    // Scene.transform.rotation = Quaternion.Euler(0, centerCamera.transform.rotation.y * 180, 0);
                    StartPosX = centerCamera.transform.position.x;
                    StartPosZ = centerCamera.transform.position.z;
                    // Scene.transform.Rotate(
                    //     0,
                    //     centerCamera.transform.rotation.y * 180,
                    //     0,
                    //     Space.World);
                    // cameraRig.transform.LookAt(target.transform);
                    // cameraRig.transform.rotation = Quaternion.Euler(0,0,0);
                    // cameraRig.transform.position = new Vector3(0, 1.6f, -7.44f);
                }
            }

        }
        else
        {
            HandRay._stopPinching = false;
        }

        if (!HandRay._stopPinching)
        {
            ButtonImage.color = new Color(ButtonColor.r, ButtonColor.g, ButtonColor.b, 1.0f);
            HandRay._CStimer = 0;
        }


    }
}
