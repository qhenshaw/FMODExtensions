using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

namespace FMODExtensions
{
    public class FMODCollisionEmitter : MonoBehaviour
    {
        [SerializeField] private EventReference _enterEvent;
        [SerializeField] private EventReference _stayEvent;

        [SerializeField] private Vector2 _enterMinMaxVelocity = new Vector2(0.5f, 15f);
        [SerializeField] private Vector2 _stayMinMaxVelocity = new Vector2(0.5f, 15f);
        [SerializeField] private float _repeatTime = 0.33f;

        private float _nextPlayTime = 0f;

        private void Start()
        {
            _nextPlayTime = Time.time + _repeatTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlaySound(_enterEvent, collision.relativeVelocity, _enterMinMaxVelocity);
        }

        private void OnCollisionEnter(Collision collision)
        {
            PlaySound(_enterEvent, collision.relativeVelocity, _enterMinMaxVelocity);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            PlaySound(_stayEvent, collision.relativeVelocity, _stayMinMaxVelocity);
        }

        private void OnCollisionStay(Collision collision)
        {
            PlaySound(_stayEvent, collision.relativeVelocity, _stayMinMaxVelocity);
        }

        private void PlaySound(EventReference eventReference, Vector3 relativeVelocity, Vector2 minMaxVelocity)
        {
            //Check to see if enough time has elapsed since the last collision
            if (Time.time <= _nextPlayTime || eventReference.IsNull) return;
            _nextPlayTime = Time.time + _repeatTime;

            //Check to see if the magnitude is greater than the minimum value
            float magnitude = relativeVelocity.magnitude;
            if (magnitude > minMaxVelocity.x)
            {
                //Convert the magnitude to a value betten 0 and 1
                float normalizedMagnitude = Mathf.Clamp01(Mathf.InverseLerp(minMaxVelocity.x, minMaxVelocity.y, magnitude));

                //Create a FMOD event instance and set parameters
                EventInstance instance = RuntimeManager.CreateInstance(eventReference);
                instance.setParameterByName("CollisionVelocity", normalizedMagnitude);
                instance.set3DAttributes(gameObject.To3DAttributes());
                //Start the FMOD event and let it cleanup when finished playing
                instance.start();
                instance.release();
            }
        }
    }
}