using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRayCast : MonoBehaviour
{
    [SerializeField] float _rayDistance = 100;

    [SerializeField]
    public GameObject ovr_Rig;
    public OVRHand _hand;
    public LineRenderer _lineRenderer;
    public Vector3[] positions;


    public float _CStimer;
    public float _Rtimer, _CS2timer;

    public bool _stopPinching;

    // Start is called before the first frame update
    void Start()
    {
        _hand = GetComponent<OVRHand>();
        _lineRenderer = GetComponent<LineRenderer>();
        positions = new Vector3[]{
            ovr_Rig.transform.position + _hand.PointerPose.position,
            ovr_Rig.transform.position + _hand.PointerPose.position + _hand.PointerPose.forward * _rayDistance
        };
    }

    // Update is called once per frame
    void Update()
    {
        //  レイをLineRendererで描画
        positions = new Vector3[]{
            ovr_Rig.transform.position + _hand.PointerPose.position,
            ovr_Rig.transform.position + _hand.PointerPose.position + _hand.PointerPose.forward * _rayDistance
        };

        _lineRenderer.SetPositions(positions);

        // //  PointerPoseが有効な時のみLineRendererを表示
        _lineRenderer.enabled = _hand.IsPointerPoseValid;

    }
}

