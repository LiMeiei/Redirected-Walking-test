using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingHeightController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    RedirectedJumping RDJ;
    void Start()
    {
        this.transform.position = new Vector3(RDJ.centerCamera.transform.position.x,
                                              RDJ.InitialY + 0.3f,
                                              RDJ.centerCamera.transform.position.z + 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(RDJ.centerCamera.transform.position.x,
                                              RDJ.InitialY + 0.3f,
                                              RDJ.centerCamera.transform.position.z + 1.0f);

        if (RDJ.centerCamera.transform.position.y - RDJ.InitialY >= 0.1f)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
