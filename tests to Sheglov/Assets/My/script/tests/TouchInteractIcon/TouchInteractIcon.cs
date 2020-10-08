namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TouchInteractIcon : VRTK_InteractableListener
    {
        [Tooltip("The Interactable Object to monitor the interactions on. If this is left blank, then the Interactable Object will need to be on the current or a parent GameObject.")]
        public VRTK_InteractableObject objectToMonitor;

        [System.Obsolete("`objectToAffect` has been replaced with `objectToHighlight`. This parameter will be removed in a future version of VRTK.")]
        [ObsoleteInspector]
        public VRTK_InteractableObject objectToAffect;


        public GameObject _iconBacground;
        public GameObject _videoBanchmark;
        public GameObject _desktop;
        public ChecTrigerManager _checTrigerManager;
        private void Start()
        {
            
        }

        protected virtual void OnEnable()
        {

            objectToMonitor = (objectToMonitor == null ? objectToAffect : objectToMonitor);
 
            EnableListeners();
        }

        protected virtual void OnDisable()
        {
            DisableListeners();
            _iconBacground.SetActive(false);
        }
        protected override bool SetupListeners(bool throwError)
        {
            objectToMonitor = (objectToMonitor != null ? objectToMonitor : GetComponentInParent<VRTK_InteractableObject>());
            if (objectToMonitor != null)
            {

                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchEnable);
                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, UnTouchDisable);

                return true;
            }
            else if (throwError)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_InteractObjectHighlighter", "VRTK_InteractableObject", "the same or parent"));
            }
            return false;
        }

        protected override void TearDownListeners()
        {
            if (objectToMonitor != null)
            {
                objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchEnable);
                objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, UnTouchDisable);

            }
        }


        protected virtual void TouchEnable(object sender, InteractableObjectEventArgs e)
        {
             Debug.Log("505");
            
        }

        protected virtual void UnTouchDisable(object sender, InteractableObjectEventArgs e)
        {
            if (_iconBacground.activeSelf)
            {
                _iconBacground.SetActive(false);
                _desktop.SetActive(false);
                _videoBanchmark.SetActive(true);
                Debug.Log("909");

            }
            else
            {
                _iconBacground.SetActive(true);

            }
        }       

    }
}

