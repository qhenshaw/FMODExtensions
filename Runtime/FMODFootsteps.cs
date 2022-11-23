using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMODExtensions
{
    public class FMODFootsteps : MonoBehaviour
    {
        [SerializeField] private FMODUnity.EventReference _footstepEvent;

        public void PlayFootstep(GameObject surfaceObject)
        {
            // create instance and set initial parameters
            FMOD.Studio.EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(_footstepEvent);
            instance.setParameterByName("Material", GetSurfaceMaterial(surfaceObject));
            instance.setParameterByName("Speed", 1f);
            // start play and move to correct position
            instance.start();
            instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
            // clean up instance once finished playing
            instance.release();
        }

        // get surface material value from GameObject
        public float GetSurfaceMaterial(GameObject surfaceObject)
        {
            if (surfaceObject != null && surfaceObject.TryGetComponent(out FMODSurface surface) && surface.SurfaceMaterial != null) return surface.SurfaceMaterial.SurfaceValue;
            return 0f;
        }
    }
}