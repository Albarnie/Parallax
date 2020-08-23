using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albarnie.Parallax
{
    public class ParallaxElement : MonoBehaviour
    {
        bool hasPosition;
        public Vector2 originalPosition;

        private void OnEnable()
        {
            if (!hasPosition)
            {
                originalPosition = transform.position;
                hasPosition = true;
            }

            if (ParallaxManager.manager != null)
            {

                //Offset the object to preserve its position
                Vector2 delta = originalPosition - (Vector2)ParallaxManager.manager.transform.position;
                transform.position -= (Vector3)(delta * ParallaxManager.manager.axis) * (transform.position.z / ParallaxManager.manager.maxDistance);

                //Add the object to the list of objects that should be parallaxed

                ParallaxManager.manager.elements.Add(this);
            }
        }

        private void OnDisable()
        {
            //Remove the object from the list
            if (ParallaxManager.manager != null)
            {
                ParallaxManager.manager.elements.Remove(this);
            }
        }
    }
}
