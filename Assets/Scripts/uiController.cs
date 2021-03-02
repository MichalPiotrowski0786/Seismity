using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{

    List<Earthquake> e_List;
    public Dropdown dropdown;
    float sphereRadius;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("EarthTag").GetComponent<EarthquakesController>().Earthquakes != null)
        {
            e_List = GameObject.FindGameObjectWithTag("EarthTag")
            .GetComponent<EarthquakesController>().Earthquakes;
            sphereRadius = GameObject.FindGameObjectWithTag("EarthTag")
            .GetComponent<SphereCollider>().radius*101f;

            dropdown.ClearOptions();

            string[] e_data = new string[e_List.Count];

            int index = 0;
            foreach(Earthquake e in e_List)
            {
                e_data[index] = "["+e.mag.ToString()+"]: "+e.lat.ToString()+" , "+e.lon.ToString();
                index++;
            }

            System.Array.Sort(e_data);
            System.Array.Reverse(e_data);

            foreach(string e_str in e_data)
            {
                dropdown.options.Add(new Dropdown.OptionData(e_str));
            }

        }

        

    }

}
