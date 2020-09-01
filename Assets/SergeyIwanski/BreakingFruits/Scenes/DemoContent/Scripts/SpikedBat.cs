/// <summary>
/// Made specifically for example of breaking fruit.
/// This script is place on a spiked baseball bat (SpicedBat.prefab)
/// When you click the mouse, the attack animation is played, and the sound is played depending on what you hit.
/// </summary>

using UnityEngine;

namespace sergeyiwanski
{
    public class SpikedBat : MonoBehaviour
    {
        [SerializeField] AudioClip[] sounds; //[0]FruitСrushing, [1]FruitHit, [2]WoodHit

        Animator animator;
        AudioSource _audio;

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if(animator)
            {
                animator.SetBool("isAttack", Input.GetMouseButton(0));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<CellFracture>())
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
