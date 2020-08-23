using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albarnie.Parallax
{
    public class ParallaxManager : MonoBehaviour
    {
        public static ParallaxManager manager;

        public float maxDistance = 5000;

        public Vector2 axis = Vector2.one;

        public Vector2 delta { get; private set; }
        public List<ParallaxElement> elements;

        Transform cam;
        Vector2 lastCameraPos;

        private void Awake()
        {
            //Singleton
            if (manager == null)
            {
                //DontDestroyOnLoad(gameObject);
                manager = this;
            }
            else if (manager != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            //Get a reference to the camera
            cam = Camera.main.transform;

            lastCameraPos = cam.position;
        }

        private void Update()
        {
            //Get the delta from the last frame
            delta = (Vector2)cam.position - lastCameraPos;

            //If the camera has moved since the last frame
            if (delta.sqrMagnitude > 0)
            {
                UpdateParallax();
            }
            lastCameraPos = cam.position;
        }

        void UpdateParallax()
        {
            foreach (ParallaxElement element in elements)
            {
                element.transform.position += (Vector3)(delta * axis) * (element.transform.position.z / maxDistance);
            }
        }
    }
}