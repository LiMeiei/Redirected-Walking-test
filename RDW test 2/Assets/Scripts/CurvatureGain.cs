using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvatureGain : MonoBehaviour
{
    [SerializeField]
    redirection rdw;
    [SerializeField]
    moveDuePlayer mdp;
    [SerializeField]
    float _CurvatureGain;

    float Distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Distance = Mathf.Sqrt(Mathf.Pow(mdp.MoveX, 2) + Mathf.Pow(mdp.MoveZ, 2));
        if (Vector3.Dot(this.transform.forward, mdp.MoveVec) >= 0)
        {
            this.transform.position += rdw.centerCamera.transform.right * Distance * Mathf.Tan(_CurvatureGain * Mathf.Deg2Rad);
        }
        else
        {
            this.transform.position += rdw.centerCamera.transform.right * Distance * Mathf.Tan((-1 * _CurvatureGain) * Mathf.Deg2Rad);
        }
    }
}
