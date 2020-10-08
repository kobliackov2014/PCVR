namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TouchInteractionButtonClose : VRTK_InteractableListener
    {
        [Tooltip("The Interactable Object to monitor the interactions on. If this is left blank, then the Interactable Object will need to be on the current or a parent GameObject.")]
        public VRTK_InteractableObject objectToMonitor;

        [System.Obsolete("`objectToAffect` has been replaced with `objectToHighlight`. This parameter will be removed in a future version of VRTK.")]
        [ObsoleteInspector]
        public VRTK_InteractableObject objectToAffect;


        public GameObject _videoBanchmark;
        public GameObject _videoBanchmarkUI;
        public GameObject _desktop;

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
        }
        protected override bool SetupListeners(bool throwError)
        {
            objectToMonitor = (objectToMonitor != null ? objectToMonitor : GetComponentInParent<VRTK_InteractableObject>());
            if (objectToMonitor != null)
            {

                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchButonCloseDisable);
                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, UnTouchButonCloseDisable);

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
                objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchButonCloseDisable);
                objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, UnTouchButonCloseDisable);

            }
        }

        protected virtual void TouchButonCloseDisable(object sender, InteractableObjectEventArgs e)
        {
            Debug.Log("505");

        }

        protected virtual void UnTouchButonCloseDisable(object sender, InteractableObjectEventArgs e)
        {

            _desktop.SetActive(true);
            _videoBanchmark.SetActive(false);
            _videoBanchmarkUI.SetActive(false);


        }

    }
}