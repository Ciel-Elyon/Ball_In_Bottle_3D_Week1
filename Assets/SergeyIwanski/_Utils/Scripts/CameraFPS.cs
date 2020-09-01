using UnityEngine;

namespace sergeyiwanski
{
    public class CameraFPS : MonoBehaviour
    {
        float h, v, updown = 0;

        // Use this for initialization
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            MouseRotate();

            MouseVisible();
        }


        void Move()
        {
            float right = Input.GetAxisRaw("Horizontal");
            float forward = Input.GetAxisRaw("Vertical");     

            if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Q)) updown -= 0.001f;
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.E)) updown += 0.001f;
            updown = Mathf.Lerp(Mathf.Clamp(updown,-10,10), 0, 0.1f);

            transform.Translate(new Vector3(right, 0, forward) * 0.01f);
            transform.Translate(new Vector3(0, updown, 0), Space.World);
        }


        void MouseRotate()
        {
            v += Input.GetAxis("Mouse X");

            h += Input.GetAxis("Mouse Y");
            h = Mathf.Clamp(h, -20, 20);

            transform.localEulerAngles = new Vector3(-h, v, 0) * 4;
        }


        void MouseVisible()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if(Input.GetMouseButton(0)||Input.GetMouseButton(1))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
