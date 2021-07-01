using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ResetInitialY : MonoBehaviour
{
    [SerializeField]
    HandRayCast HandRay;
    [SerializeField]
    RedirectedJumping RDJ;

    // bool flag = true;
    void Start()
    {
        HandRay._CStimer = 0;
        RDJ.InitialY = RDJ.centerCamera.transform.position.y;
        HandRay._stopPinching = false;
    }

    void Update()
    {
        ResetPos();
    }

    public void ResetPos()
    {

        Image ButtonImage = GetComponent<Image>();
        Color ButtonColor = ButtonImage.color;
        RaycastHit hit;

        if (Physics.Raycast(HandRay.positions[0], HandRay._hand.PointerPose.forward, out hit) &&
            HandRay._hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {

            ButtonImage.color = new Color(ButtonColor.r, ButtonColor.g, ButtonColor.b, 0.5f);
            if (hit.collider.tag == "ResetPosition")
            {
                HandRay._stopPinching = true;
                HandRay._CStimer += Time.deltaTime;
                if (HandRay._CStimer >= 1.0f)
                {
                    HandRay._CStimer = 0;
                    Debug.Log("ResetInitialY");
                    Debug.Log(RDJ.centerCamera.transform.position.z);
                    Debug.Log(RDJ.centerCamera.transform.rotation.y * 180);
                    // Debug.Log(RDJ.ovr_Rig.transform.rotation.x + " " + RDJ.ovr_Rig.transform.rotation.y + " " + RDJ.ovr_Rig.transform.rotation.z);
                    RDJ.InitialY = RDJ.centerCamera.transform.position.y;
                    // Debug.Log(RDJ.InitialY);
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
