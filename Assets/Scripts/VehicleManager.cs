using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{

    public GameObject wheel_lf,wheel_lb, wheel_rf, wheel_rb;
    public WheelCollider wheel_lf_col, wheel_lb_col, wheel_rf_col, wheel_rb_col;

    [SerializeField]
    private GameObject leftDoor, rightDoor;

    Rigidbody rigidbody;

    int speed = 5;

    public int torque = 200;

    int wheelCounter = 0;

    int a;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.transform.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CarController();
        DoorMechnism();


    }

    void CarController()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {

            speed+=10;

            wheel_lf.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, 0, 0);
            wheel_lb.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, 0, 0);
            wheel_rf.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, 0, 0);
            wheel_rb.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, 0, 0);



            wheel_lb_col.motorTorque = Input.GetAxis("Horizontal") * torque;
            wheel_rb_col.motorTorque = Input.GetAxis("Horizontal") * torque;
            rigidbody.velocity = new Vector3(0, 0, torque * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed-=10;

            wheel_lf.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, 0, 0);
            wheel_lb.transform.eulerAngles = new Vector3(wheel_lb.transform.position.x + speed, 0, 0);
            wheel_rf.transform.eulerAngles = new Vector3(wheel_rf.transform.position.x + speed, 0, 0);
            wheel_rb.transform.eulerAngles = new Vector3(wheel_rb.transform.position.x + speed, 0, 0);



            wheel_lb_col.motorTorque = Input.GetAxis("Horizontal") * -torque;
            wheel_rb_col.motorTorque = Input.GetAxis("Horizontal") * -torque;
            rigidbody.velocity = new Vector3(0, 0, -torque * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            wheelCounter = wheelCounter >= -35 ? wheelCounter-=5: wheelCounter;

            if (wheelCounter > -40)
            {
                wheel_lf.transform.eulerAngles = new Vector3(0, wheel_lf.transform.position.y + wheelCounter, 0);
                wheel_rf.transform.eulerAngles = new Vector3(0, wheel_rf.transform.position.y + wheelCounter, 0);
              

            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            wheelCounter = wheelCounter <= 35 ? wheelCounter+=5 : wheelCounter;

           // wheelCounter += 5;

            if (wheelCounter < 40)
            {
                wheel_lf.transform.eulerAngles = new Vector3(0, wheel_lf.transform.position.y + wheelCounter, 0);
                wheel_rf.transform.eulerAngles = new Vector3(0, wheel_rf.transform.position.y + wheelCounter, 0);
                
            }

        }
        else if(Input.GetKey(KeyCode.UpArrow) & Input.GetKey(KeyCode.RightArrow))
        {
            speed++;

            wheelCounter = wheelCounter <= 35 ? wheelCounter += 5 : wheelCounter;
           

            if(wheelCounter > 50)
            {
                wheel_lf.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, wheel_lf.transform.position.y + wheelCounter, 0);
                wheel_rf.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, wheel_lf.transform.position.y+wheelCounter, 0);

            }


            wheel_lb.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, 0, 0);
            wheel_rb.transform.eulerAngles = new Vector3(wheel_lf.transform.position.x + speed, 0, 0);



            wheel_lb_col.motorTorque = Input.GetAxis("Horizontal") * torque;
            wheel_rb_col.motorTorque = Input.GetAxis("Horizontal") * torque;
            rigidbody.velocity = new Vector3(0, 0, torque * Time.deltaTime);

        }


        Debug.Log(wheelCounter);

    }



    //Door Mechanism
    void DoorMechnism()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {

           a = 0;

     
                rightDoor.GetComponent<Transform>().eulerAngles = new Vector3(0, a, 0);

                  StartCoroutine(OpenTheDoor());

        }

    }


    IEnumerator OpenTheDoor()
    {
        while (false)
        {

            a--;

        }
        

        yield return new WaitForSeconds(1f);
    }


}
