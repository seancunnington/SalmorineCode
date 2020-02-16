namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class ButtonHaptic : MonoBehaviour
    {
        private float hapticStrength = 0.8f;
        public VRTK_ControllerReference controllerReference;

        private VRTK_Button_UnityEvents buttonEvents;
        private VRTK_InteractableObject io;


        void OnEnable()
        {
            io = GetComponent<VRTK_InteractableObject>();
            io.InteractableObjectTouched += Io_InteractableObjectTouched;
            io.InteractableObjectUntouched += Io_InteractableObjectUntouched;
        }
        
               
        private void Io_InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
        {
            VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(e.interactingObject);
            if(controllerReference != null)
            {
                VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, 1f, 0.5f, 0.5f);
            }
        }


        private void Io_InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
        {
            controllerReference = null;
        }
        

        private void Start()
        {
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }

            buttonEvents.OnPushed.AddListener(handlePush);
        }

        private void handlePush(object sender, Control3DEventArgs e)
        {
            //VRTK_Logger.Info("Pushed");

            VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength, 0.5f, 0.1f);

        }


    }
}