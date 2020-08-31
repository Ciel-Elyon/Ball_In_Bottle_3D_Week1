using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
                transform.Rotate(transform.forward, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
        }


        mPrevPos = Input.mousePosition;
    }

}
