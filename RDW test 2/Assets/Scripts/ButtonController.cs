using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    HandRayCast HandRay;


    [SerializeField]
    string sceneName;

    void Start()
    {
        // ovr = FindObjectOfType<redirection>();
        HandRay._CStimer = 0;



        HandRay._stopPinching = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeToScene();
    }

    public void ChangeToScene()
    {
        // ovr.save();
        RaycastHit hit;
        Image ButtonImage = GetComponent<Image>();
        Color ButtonColor = ButtonImage.color;

        if (Physics.Raycast(HandRay.positions[0], HandRay._hand.PointerPose.forward, out hit) &&
            HandRay._hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            HandRay._stopPinching = true;

            if (hit.collider.tag == this.gameObject.tag)
            {
                ButtonImage.color = new Color(ButtonColor.r, ButtonColor.g, ButtonColor.b, 0.5f);
                HandRay._CStimer += Time.deltaTime;
                Debug.Log(sceneName);
                Debug.Log(HandRay._CStimer);
                if (HandRay._CStimer >= 1f)
                {
                    HandRay._CStimer = 0;
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
        else
        {
            HandRay._stopPinching = false;
        }

        if (HandRay._stopPinching == false)
        {
            ButtonImage.color = new Color(ButtonColor.r, ButtonColor.g, ButtonColor.b, 1.0f);
            HandRay._CStimer = 0;

        }

    }

    // void sceneLoaded(Scene next,LoadSceneMode mode){
    //     ovr.load();
    //     SceneManager.sceneLoaded -= this.sceneLoaded;
    // }

}
