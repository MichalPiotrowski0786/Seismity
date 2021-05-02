using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    List<Earthquake> e_List;
    public Dropdown dropdown;
    public Button button;
    SphereCollider sphereCollider;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("EarthTag").GetComponent<EarthquakesController>().Earthquakes != null)
        {
            e_List = GameObject.FindGameObjectWithTag("EarthTag")
            .GetComponent<EarthquakesController>().Earthquakes;
            sphereCollider = GameObject.FindGameObjectWithTag("EarthTag")
            .GetComponent<SphereCollider>();

            dropdown.ClearOptions();

            string[] e_data = new string[e_List.Count];

            int index = 0;
            foreach(Earthquake e in e_List)
            {
                e_data[index] = "["+e.mag.ToString()+"]: "+e.lat.ToString()+" , "+e.lon.ToString();
                index++;
            }

            foreach(string e_str in e_data)
            {
                dropdown.options.Add(new Dropdown.OptionData(e_str));
            }

            button.onClick.AddListener(() => MoveCameraToLocationFromDropdown(dropdown.value));
        }       

    }

    private void DisableCameraContoller()
    {
        if(Camera.main != null)
        {
            Camera.main.GetComponent<CameraController>().enabled = 
            !Camera.main.GetComponent<CameraController>().enabled;
        }
    }

    private void MoveCameraToLocationFromDropdown(int index)
    {
        if(Camera.main != null)
        {
            Camera.main.transform.position = CalculateVec3FromLatLon(e_List[index],sphereCollider.radius*150f);
            Camera.main.transform.LookAt(sphereCollider.center);
        }
    }

    private Vector3 CalculateVec3FromLatLon(Earthquake e, float r)
    {
        var threePosition = Quaternion.AngleAxis((float)e.lon,-Vector3.up) 
            * Quaternion.AngleAxis((float)e.lat, -Vector3.right) 
            * new Vector3(0f, 0f, 1f) * r;

        return threePosition;
    }

}
