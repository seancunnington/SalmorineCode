namespace VRTK
{
    using UnityEngine;

    public class ButtonCount : VRTK_InteractableObject
    {

        public float buttonAdd;
        private GameObject shipHullRef;

        public override void StartTouching(VRTK_InteractTouch usingObject)
        {
            base.StartTouching(usingObject);

            //if at 5 max and buttonAdd == -1, then okay to add
            if (shipHullRef.GetComponent<MovePiece>().step_count_forward == 5 && buttonAdd == -1)
            {
                shipHullRef.GetComponent<MovePiece>().step_count_forward += buttonAdd;
            }
            //if at -1 min and buttonAdd == 1, then okay to add
            else if (shipHullRef.GetComponent<MovePiece>().step_count_forward == -1 && buttonAdd == 1)
            {
                shipHullRef.GetComponent<MovePiece>().step_count_forward += buttonAdd;
            }
            //if between either extremes, just do your thing
            else if (shipHullRef.GetComponent<MovePiece>().step_count_forward <=4 && shipHullRef.GetComponent<MovePiece>().step_count_forward >= 0)
            {
                shipHullRef.GetComponent<MovePiece>().step_count_forward += buttonAdd;
            }
        }


        // Use this for initialization
        void Start()
        {
            shipHullRef = GameObject.Find("ShipHull");
        }
 
    }
}