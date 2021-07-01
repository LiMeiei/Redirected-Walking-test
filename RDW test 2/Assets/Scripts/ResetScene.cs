using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [SerializeField]
    HandRayCast HandRay;


    // bool flag = true;
    void Start()
    {

        for (int i = 0; i < 5; i++)
        {
            // Debug.Log("ok");

            HandRay._CStimer = 0;
        }

        HandRay._stopPinching = false;
        HandRay._Rtimer = 0;
    }


    void Update()
    {
        GoToStartScene();
    }

    public void GoToStartScene()
    {

        Image ButtonImage = GetComponent<Image>();
        Color ButtonColor = ButtonImage.color;
        RaycastHit hit;
        if (Physics.Raycast(HandRay.positions[0], HandRay._hand.PointerPose.forward, out hit) &&
            HandRay._hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            ButtonImage.color = new Color(ButtonColor.r, ButtonColor.g, ButtonColor.b, 0.5f);
            // ButtonImage.color = new Color(1.0f,1.0f,1.0f,0.5f);
            if (hit.collider.tag == "ResetScene")
            {
                HandRay._Rtimer += Time.deltaTime;
                HandRay._stopPinching = true;
                if (HandRay._Rtimer >= 1.0f)
                {
                    HandRay._Rtimer = 0;
                    SceneManager.LoadScene("select stage");
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
            HandRay._Rtimer = 0;
        }

    }

}
