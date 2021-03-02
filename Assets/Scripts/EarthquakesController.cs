using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EarthquakesController : MonoBehaviour
{
    public List<Earthquake> Earthquakes;
    List<Vector3> EarthquakesLocations;
    List<GameObject> EarthquakesGameObjects;

    SphereCollider sphereCollider;
    UnityWebRequest www;

    public GameObject MarkerPrefab;

    void Awake() {
        StartCoroutine(AddEventsFromFile());
        Init();
        ConfigGameObjects(); 
    }

    IEnumerator AddEventsFromFile()
    {
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_week.csv";
        www = 
        UnityWebRequest.Get(url);

        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string savePath = string.Format(
            "{0}/{1}.csv", 
            "C:/Users/MichalPiotrowski/Desktop/AiB/2 rok - II sem/Inżynieria oprogramowania/Projekt/Assets", 
            "data"); 
            Debug.Log(Application.persistentDataPath);       
            System.IO.File.WriteAllText(savePath, www.downloadHandler.text);
        }
    }

    void FormatFile()
    {
        string Spreedsheet = System.IO.File.ReadAllText(
        "C:/Users/MichalPiotrowski/Desktop/AiB/2 rok - II sem/Inżynieria oprogramowania/Projekt/Assets/data.csv"
        );

        string[] lines = Spreedsheet.Split("\n"[0]);

        int index = 0;
        foreach(string line in lines)
        {
            if(index > 0)
            {
                string[] splitted = (line.Trim()).Split(","[0]);
                if(splitted.Length < 5)
                {
                    return;
                }
                int inner_index = 0;
                foreach(string line_spl in splitted)
                {
                    splitted[inner_index] = line_spl.Replace(".",",");
                    inner_index++;
                }

                Earthquakes.Add(
                    new Earthquake(
                        "0",
                        splitted[0],
                        splitted[4],
                        splitted[2],
                        splitted[1],
                        splitted[3]
                    )
                );
            }
            index++;
        }
        
    }

    void Init()
    {
        Earthquakes = new List<Earthquake>();
        FormatFile();
        sphereCollider = this.GetComponent<SphereCollider>();

        if(Earthquakes != null && Earthquakes.Count > 0)
        {
            EarthquakesLocations = new List<Vector3>();
            EarthquakesGameObjects = new List<GameObject>();
            foreach(Earthquake e in Earthquakes)
            {
                EarthquakesLocations.Add(CalculateVec3FromLatLon(e));
            }

            if(EarthquakesLocations != null && EarthquakesLocations.Count > 0)
            {
                foreach(Vector3 e_loc in EarthquakesLocations)
                {
                    EarthquakesGameObjects.Add(MarkerPrefab);
                }
            }
        }
    }

    void ConfigGameObjects()
    {
        if(EarthquakesGameObjects != null && EarthquakesGameObjects.Count > 0)
        {
            for(int i = 0; i < EarthquakesGameObjects.Count; i++)
            {
                GameObject g = EarthquakesGameObjects[i];

                Instantiate(g);

                var e = Earthquakes[i];
                var e_loc = EarthquakesLocations[i];


                g.transform.position = e_loc;
                g.transform.LookAt(sphereCollider.center);
                g.transform.localScale = 
                Vector3.one*(e.mag*0.05f);

                g.name = "["+i.ToString()+"]:"+e.mag.ToString();
            }
        }
    }

    private Vector3 CalculateVec3FromLatLon(Earthquake e)
    {
        float lat = e.lat;
        float lon = e.lon;

        float r = sphereCollider.radius*101f;

        var threePosition = Quaternion.AngleAxis(lon,-Vector3.up) 
            * Quaternion.AngleAxis(lat, -Vector3.right) 
            * new Vector3(0, 0, 1) * r;

        return threePosition;
    }

}
