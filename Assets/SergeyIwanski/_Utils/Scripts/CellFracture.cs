/// <summary>
/// Replaces an object with its set fragments, considering the position and size of the object.
/// At the same time optimizes by removing fragments over time.
/// The OnBreakdown() method of this script must be called from another script, for example when it encounters something.
/// </summary>


using UnityEngine;

namespace sergeyiwanski
{
    public class CellFracture : MonoBehaviour
    {
        [Tooltip("Set of fragments with which the object will be replaced.")]
        [SerializeField] GameObject cells_prefab;

        [Tooltip("Approximate time after which the object will be destroyed +/- delta.")]
        [SerializeField] float lifeTime = 60f;

        [Tooltip("The difference in the time of destruction for each object.")]
        [SerializeField] float delta = 10f;


        /// <summary>
        /// Replaces the object with its fragments.
        /// </summary>
        public void OnBreakdown()
        {
            GameObject cells = Instantiate(this.cells_prefab, transform.position, transform.rotation);
            cells.transform.localScale = transform.localScale;
            cells.transform.parent = gameObject.transform.parent;

            foreach (Transform cell in cells.GetComponentsInChildren<Transform>())
            {
                float time = Random.Range(lifeTime - delta, lifeTime + delta);
                Destroy(cell.gameObject, time);
            }

            //So that the parts are not destroyed immediately with the root
            cells.transform.DetachChildren();

            //The cells object are destroyed from the particle when the particle is complete.
            //Destroy(cells);

            Destroy(gameObject);
        }
    }
}
