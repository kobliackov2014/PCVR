namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class TouchSelector : VRTK_InteractableListener
    {
        [Tooltip("The Interactable Object to monitor the interactions on. If this is left blank, then the Interactable Object will need to be on the current or a parent GameObject.")]
        public VRTK_InteractableObject objectToMonitor;

        [System.Obsolete("`objectToAffect` has been replaced with `objectToHighlight`. This parameter will be removed in a future version of VRTK.")]
        [ObsoleteInspector]
        public VRTK_InteractableObject objectToAffect;


        public SelectorDropzone _selectorDropzone;
        //protected GameObject currentAffectingObject;


        protected virtual void OnEnable()
        {

            objectToMonitor = (objectToMonitor == null ? objectToAffect : objectToMonitor);
            //objectToHighlight = (objectToHighlight == null && objectToAffect != null ? objectToAffect.gameObject : objectToHighlight);


            //objectToHighlight = (objectToHighlight != null ? objectToHighlight : gameObject);
            //if (GetValidHighlighter() != baseHighlighter)
            //{
            //    baseHighlighter = null;
            //}
            EnableListeners();
        }

        protected virtual void OnDisable()
        {
            //if (createBaseHighlighter)
            //{
            //    Destroy(baseHighlighter);
            //}
            DisableListeners();
        }
        protected override bool SetupListeners(bool throwError)
        {
            objectToMonitor = (objectToMonitor != null ? objectToMonitor : GetComponentInParent<VRTK_InteractableObject>());
            if (objectToMonitor != null)
            {

                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchSelectorEnable);
                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, UnTouchSelecrorDisable);

                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, TouchSelectorEnable);
                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Ungrab, UnTouchSelecrorDisable);

                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Use, TouchSelectorEnable);
                objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Unuse, UnTouchSelecrorDisable);

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
                objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchSelectorEnable);
                objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, UnTouchSelecrorDisable);

            }
        }


        protected virtual void TouchSelectorEnable(object sender, InteractableObjectEventArgs e)
        {
            Debug.Log("505");
            _selectorDropzone.SelectorDropZoneDisable();
        }

        protected virtual void UnTouchSelecrorDisable (object sender, InteractableObjectEventArgs e)
        {
            Debug.Log("909");
            _selectorDropzone.SelectDropZoneEnable();
        }

    }
}

