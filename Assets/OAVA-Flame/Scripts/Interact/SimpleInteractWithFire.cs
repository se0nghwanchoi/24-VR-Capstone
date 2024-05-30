using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ignis
{
    /// <summary>
    /// A template for interacting with fire using IInteractWithFire interface.
    /// </summary>
    public class SimpleInteractWithFire : MonoBehaviour, IInteractWithFire
    {
        public GameObject ExplosionP;
        public Transform createPoint;
        private bool hasInteracted = false;

        public void OnCollisionWithFire(GameObject burningObject)
        {
            if (!hasInteracted)
            {
                hasInteracted = true;
                StartCoroutine(ExplodeAfterDelay());
            }
        }

        private IEnumerator ExplodeAfterDelay()
        {
            yield return new WaitForSeconds(2f); // 2초 지연
            Instantiate(ExplosionP, createPoint.position, createPoint.rotation);
        }
    }
}
