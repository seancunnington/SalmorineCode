namespace VRTK
{
    using UnityEngine;

    public class MovePiece : MonoBehaviour
    {
        //the whole ship that we're moving
        private GameObject hullParent;
        private GameObject endMoth;
        private GameObject endVideo;

        private GameObject playArea;
        private float circleNum;

        //Big Red Button Stop
        public bool bigRedButton;

        //Bug Collecting
        public float waspCount;
        public float dragonCount_1;
        public float dragonCount_2;
        public float mosqCount;
        public float totalBugCount;

        public bool endStart;

        //the move mechanics of the ship
        private float speed = 2.2f;
        //private float gravity = 0f;
        private Vector3 moveDirection = Vector3.zero;

        //the number of boxes clicked
        public float step_count_forward;      //back is negative
        public float step_count_right;        //left is negative
        public float step_count_up;           //down is negative

        
        private void Start()
        {
            hullParent = GameObject.Find("ShipHull");
            endMoth = GameObject.Find("roseMoth");
            endMoth.SetActive(false);

            endVideo = GameObject.Find("Ending (1)");
            endVideo.SetActive(false);
            Invoke("StartEndVideo", 10);

            step_count_forward = 0f;
            step_count_up = 0f;
            step_count_right = 0f;

            bigRedButton = false;
            endStart = false;

            waspCount = 0;
            dragonCount_1 = 0;
            dragonCount_2 = 0;
            mosqCount = 0;
            totalBugCount = 0;
        }
      

        private void OnTriggerEnter(Collider other)
        {

            ///BUGS COLLISION
            if ( other.gameObject.tag == "Mosq")
            {
                mosqCount++;
                hullParent.GetComponent<AudioSource>().Play();
                Debug.Log("mosqCount: " + mosqCount);
                Destroy(other.gameObject);

                if (mosqCount == 4)
                    totalBugCount++;
            }

            if (other.gameObject.tag == "Dragon1")
            {
                dragonCount_1++;
                hullParent.GetComponent<AudioSource>().Play();
                Debug.Log("dragonCount_1: " + dragonCount_1);
                Destroy(other.gameObject);

                if (dragonCount_1 == 4)
                    totalBugCount++;
            }

            if (other.gameObject.tag == "Dragon2")
            {
                dragonCount_2++;
                hullParent.GetComponent<AudioSource>().Play();
                Debug.Log("dragonCount_2: " + dragonCount_2);
                Destroy(other.gameObject);

                if (dragonCount_2 == 4)
                    totalBugCount++;
            }

            if (other.gameObject.tag == "Wasp")
            {
                waspCount++;
                hullParent.GetComponent<AudioSource>().Play();
                Debug.Log("waspCount: " + waspCount);
                Destroy(other.gameObject);

                if (waspCount == 4)
                    totalBugCount++;
            }

            /////////////////
            //ENDING BUG COLLISION
            if (other.gameObject.tag == "EndMoth")
            {
                Destroy(other.gameObject);
                ZeroAllCounters();
                endStart = true;
            }
        }



        void ActivateMoth()
        {
                endMoth.SetActive(true);
        }



        void StartEndVideo()
        {
            endVideo.SetActive(true);
        }



        void ZeroAllCounters()
        {
            step_count_forward = 0;
            step_count_right = 0;
            step_count_up = 0;
        }



        private void Update()
        {
            if (bigRedButton == false)
                ZeroAllCounters();

            if (totalBugCount == 4)
                ActivateMoth();

            CharacterController controller = GetComponent<CharacterController>();
            
            //forward is negative b/c fish is set up wrong   
            moveDirection = new Vector3(-step_count_forward*1.5f, (step_count_up * 1.5f), 0f);

            //right*10 b/c it makes it faster
            hullParent.transform.Rotate(new Vector3(0f, step_count_right * 10 * Time.deltaTime, 0f));

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            controller.Move(moveDirection * Time.deltaTime);
        }   
    }


}
