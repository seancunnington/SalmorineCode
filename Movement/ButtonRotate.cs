namespace VRTK
{
    using UnityEngine;

    public class ButtonRotate : VRTK_InteractableObject
    {

        public float buttonAdd;
        private GameObject shipHullRef;

        public override void StartTouching(VRTK_InteractTouch usingObject)
        {
            base.StartTouching(usingObject);

            //if at 3 max and buttonAdd == -1, then okay to add
            if (shipHullRef.GetComponent<MovePiece>().step_count_right == 3 && buttonAdd == -1)
            {
                shipHullRef.GetComponent<MovePiece>().step_count_right += buttonAdd;
            }
            //if at -3 min and buttonAdd == 1, then okay to add
            else if (shipHullRef.GetComponent<MovePiece>().step_count_right == -3 && buttonAdd == 1)
            {
                shipHullRef.GetComponent<MovePiece>().step_count_right += buttonAdd;
            }
            //if between either extremes, just do your thing
            else if (shipHullRef.GetComponent<MovePiece>().step_count_right <= 2 && shipHullRef.GetComponent<MovePiece>().step_count_right >= -2)
            {
                shipHullRef.GetComponent<MovePiece>().step_count_right += buttonAdd;
            }
        }


        // Use this for initialization
        void Start()
        {
            shipHullRef = GameObject.Find("ShipHull");
        }

    }
}