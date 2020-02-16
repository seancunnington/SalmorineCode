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

        //jump check prior to the jump bool -- indicates collision with RiverCollision
        //public bool jumpCheck;
        //public float jumpMotion;

        //jump bool to actually jump
        //public bool jumpBool;
        //public float step_up_max = 1;   //prevents from manually moving above water
        // public float selfGravity = 0.5f;       //used for jumping and naturally falling back into water, i.e. going through waterfalls
        //private float waterFriction = 2;
        //float placeHolder = 0;
        //float varShootForward = 0;

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
            //playArea = GameObject.Find("SteamVRSDK");
            endMoth = GameObject.Find("roseMoth");
            endMoth.SetActive(false);

            //circleNum = playArea.GetComponent<Transform>().rotation.y;

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


            //jumpMotion = 0;
            //jumpCheck = false;
            //jumpBool = false;
        }
        /*
        private void OnTriggerExit(Collider other)
        {
            ///RIVER COLLISION
            if (other.gameObject.tag == "River")
            {
                jumpCheck = false;
                //step_up_max = 1;

                //if moving through waterfall, then shoot forward and apply gravity
                //if (hullParent.GetComponent<Collider>().bounds.min.y > other.GetComponent<Collider>().bounds.max.y)
                //{
                    //if (step_count_forward > 0 && jumpBool == false)  //moving forward and NOT jumping
                    //{
                    //print("Found the Bounds!!");
                    //ShootForward();
                    //}

               // }

            }

        }
        */
        /*
        private void OnTriggerStay(Collider other)
        {
            ///RIVER COLLISION
            if (other.gameObject.tag == "River")
            {
                jumpCheck = true;   //we are colliding with a river, we can check if step_count_up == 3
                                    //if this is true, then jump via 'jumpBool' changed in ButtonHeight script

                //step_up_max is 0 when trying to go up, then 1 when trying to go down (multiplication for update funtion)
                if (step_count_up > 0)
                {
                    //step_up_max = 0;
                }
                if (step_count_up <= 0)
                    //step_up_max = 1;
            }

            //if moving through waterfall, then shoot forward and apply gravity
            if (hullParent.GetComponent<Collider>().bounds.min.y > other.GetComponent<Collider>().bounds.min.y)
            {
                if (step_count_forward > 0 && jumpBool == false)  //moving forward and NOT jumping
                {
                    ShootForward();
                }

            }

            //if(hullParent.GetComponent<Collider>().bounds.center > hullParent.GetComponent<Collider>().bounds.ClosestPoint()
            //Debug.DrawLine(hullParent.GetComponent<Collider>().bounds.min, other.GetComponent<Collider>().bounds.max);
            //print("Hull  --  x:  " + hullParent.GetComponent<Collider>().bounds.min.x + "  --  y: " + hullParent.GetComponent<Collider>().bounds.min.y + "  --  z: " + hullParent.GetComponent<Collider>().bounds.min.z);
            //print("River --  x:  " + other.GetComponent<Collider>().bounds.min.x + "  --  y: " + other.GetComponent<Collider>().bounds.min.y + "  --  z: " + other.GetComponent<Collider>().bounds.min.z);

        }
        */
        private void OnTriggerEnter(Collider other)
        {
            ///RIVER COLLISION
            //if (jumpMotion < 0)
            //    StopFall();
            

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
/*
        // always running via moveDirection in Update()
        //handles 'jumpMotion': is 0 when jumpBool == false, but iterates through a jump action if true
        float JumpAction()
        {
            if(jumpBool == true)
            {
                jumpMotion -= selfGravity;
                step_count_up = 0;
            }

            if (jumpBool == false)
            {
                if (jumpMotion < 0)
                {
                    jumpMotion += selfGravity;
                }

                if (jumpMotion >= 0)
                    jumpMotion = 0;
            }
            return jumpMotion;
        }

        void ShootForward()
        {
            jumpBool = true;
            placeHolder = step_count_forward;
            step_count_forward = 0;
            jumpMotion = 10;
            Invoke("StopShoot", 1);
        }

        void StopShoot()
        {
            step_count_forward = placeHolder;
        }
        
        void StopFall()
        {
            jumpBool = false;
            jumpMotion = -17f;
        }
        */

        //void TurnPlayArea()
        //{
        //    print("circleNum - BEFORE: " + circleNum);
//
         //   circleNum += 90;
         //   if (circleNum >= 360)
         //       circleNum = 0;

         //   playArea.GetComponent<Transform>().Rotate(new Vector3(0, circleNum, 0));
        //}

        private void Update()
        {
            if (bigRedButton == false)
                ZeroAllCounters();

            if (totalBugCount == 4)
                ActivateMoth();

           // if (Input.GetButtonDown("Right"))
             //   TurnPlayArea();

            CharacterController controller = GetComponent<CharacterController>();
            
            //forward is negative b/c fish is set up wrong   
            moveDirection = new Vector3(-step_count_forward*1.5f, (step_count_up * 1.5f), 0f);

            //right*3 b/c it makes it faster
            hullParent.transform.Rotate(new Vector3(0f, step_count_right * 10 * Time.deltaTime, 0f));

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            controller.Move(moveDirection * Time.deltaTime);

            //Debug.Log("jumpCheck: " + jumpCheck);
            //Debug.Log("jumpBool: " + jumpBool);

        }

        
    }
}
