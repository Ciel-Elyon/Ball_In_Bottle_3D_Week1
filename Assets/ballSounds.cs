using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSounds : MonoBehaviour
{
    float speed;
    Rigidbody rigidBody;
    AudioSource[] ballSoundSource;
    AudioSource ballRolling;
    AudioSource ballHit;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        ballSoundSource = GetComponents< AudioSource>();
        ballRolling = ballSoundSource[0];
        ballHit = ballSoundSource[1];

    }

    void FixedUpdate()
    {
        speed = rigidBody.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballSoundSource[1].Play();
    }

    void OnCollisionStay(Collision collision)
    {
        if (ballSoundSource[0].isPlaying == false && speed >= 0.1f && collision.gameObject.tag == "Ground")
        {
            ballSoundSource[0].Play();
        }
        else if (ballSoundSource[0].isPlaying == true && speed < 0.1f && collision.gameObject.tag == "Ground")
        {
            ballSoundSource[0].Pause();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (ballSoundSource[0].isPlaying == true && collision.gameObject.tag == "Ground")
        {
            ballSoundSource[0].Pause();
            ballSoundSource[1].Pause();

        }
    }

}
