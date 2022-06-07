using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EnterVehicle : MonoBehaviour
{
    public bool inVehicle = false;
  
   // public GameObject car_guiObj;
   // public GameObject player_gui;
    public GameObject enterbutton;
    public GameObject exitbutton;
    public GameObject player;
    public GameObject car;
    public GameObject car_cam;
    public GameObject carSounds;
    public VehicleControl _vehicleControl;
   


    void Start()
    {
       
        
        _vehicleControl.activeControl = false;
        carSounds.SetActive(false);

        
       
        // car_guiObj.SetActive(false);
        enterbutton.SetActive(false);
        exitbutton.SetActive(false);
        //player_gui.SetActive(true);
        car_cam.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("triggered");
          
                enterbutton.SetActive(true);


           




        }
    }

   
    public void enter_in_car()
    {
       
            _vehicleControl.activeControl = true;
            carSounds.SetActive(true); ;
            print("entered");
            // car_guiObj.SetActive(true);
            // player_gui.SetActive(false);
            enterbutton.SetActive(false);
            exitbutton.SetActive(true);
            player.transform.parent = car.gameObject.transform;
            car_cam.SetActive(true);
            player.SetActive(false);
            inVehicle = true;
        


    }
    public void exit_from_car()
    {
        if (inVehicle == true)
        {
            _vehicleControl.activeControl = false;
            carSounds.SetActive(false);


            player.SetActive(true);
            player.transform.parent = null;
          
           // car_guiObj.SetActive(false);
           // player_gui.SetActive(true);
            car_cam.SetActive(false);
            enterbutton.SetActive(true);
            exitbutton.SetActive(false);
            inVehicle = false;
           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterbutton.SetActive(false);
        }
        

    }

  
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

        }




    }

        
}