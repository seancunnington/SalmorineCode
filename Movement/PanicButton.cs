namespace VRTK
{
    using UnityEngine;

    public class PanicButton : VRTK_InteractableObject
    {
        private GameObject shipHullRef;
        private GameObject audioMasterRef;

        public override void StartTouching(VRTK_InteractTouch usingObject)
        {
            base.StartTouching(usingObject);

                shipHullRef.GetComponent<MovePiece>().step_count_forward = 0f;
                shipHullRef.GetComponent<MovePiece>().step_count_right = 0f;
                shipHullRef.GetComponent<MovePiece>().step_count_up = 0f;

            //only need to stop all movement until AFTER first press, then resume normal functions of Panic Stopping
            if (audioMasterRef.GetComponent<AudioMaster>().canPlay5 == true)
                shipHullRef.GetComponent<MovePiece>().bigRedButton = true;
        }


        // Use this for initialization
        void Start()
        {
            shipHullRef = GameObject.Find("ShipHull");
            audioMasterRef = GameObject.Find("VO_AudioMaster");
        }

    }
}