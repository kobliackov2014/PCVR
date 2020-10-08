namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class StopInteractions : VRTK_InteractableObject
    {
        [SerializeField]
        GameObject _basePoin;
        public float _breakDistance;

        protected override void Update()
        {
            base.Update();
            if (Vector3.Distance(transform.position, _basePoin.transform.position) > _breakDistance)
            {
                ForceStopInteracting();
                gameObject.transform.parent = _basePoin.transform;
            }
        }
    }
}

