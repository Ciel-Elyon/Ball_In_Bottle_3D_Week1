using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sergeyiwanski
{
    public class SpikeFruit : MonoBehaviour
    {
        [SerializeField] AudioClip[] sounds; //[0]FruitСrushing, [1]FruitHit, [2]WoodHit

        AudioSource _audio;
        // Start is called before the first frame update
        void Start()
        {
            _audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CellFracture>())
            {
                //Example of the call OnBreakdown() method (see Readme).
                CellFracture breakable = other.GetComponent<CellFracture>();
                breakable.OnBreakdown();

                SoundPlay(0);
            }
            else if (other.name == "Plane")
            {
                SoundPlay(2);
            }
            else
            {
                SoundPlay(1);
            }
        }

        void SoundPlay(int index)
        {
            try
            {
                if (_audio.isPlaying) return;
                _audio.clip = sounds[index];
                _audio.pitch = Random.Range(0.85f, 1.25f);
                _audio.Play();
            }
            catch { }
        }
    }
}

