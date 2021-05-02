using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class EarthquakesController : MonoBehaviour
{
    public List<Earthquake> Earthquakes;
    List<Vector3> EarthquakesLocations;
    List<GameObject> EarthquakesGameObjects;

    SphereCollider sphereCollider;
    UnityWebRequest www;

    public GameObject MarkerPrefab;

    void Start() {
        StartCoroutine(AddEventsFromFile());
        Init();
        ConfigGameObjects(); 
    }

    IEnumerator AddEventsFromFile()
    {
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/2.5_day.csv";
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
            Application.dataPath, 
            "data");     
            if(File.Exists(savePath))
            {
                File.Delete(savePath);
            } 
            System.IO.File.WriteAllText(savePath, www.downloadHandler.text);
        }
    }

    void FormatFile()
    {
        string Spreedsheet = System.IO.File.ReadAllText(
        Application.dataPath+"/data.csv"
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
            int index = 0;
            foreach(GameObject g in EarthquakesGameObjects)
            {
                var e = Earthquakes[index];
                var e_loc = EarthquakesLocations[index];

                g.transform.localScale = 
                Vector3.one*(e.mag*0.01f);
                g.transform.position = e_loc;
                g.transform.LookAt(sphereCollider.center);

                g.name = "["+index.ToString()+"]:"+e.mag.ToString();
                Instantiate(g);
                index++;
            }
        }
    }

    private Vector3 CalculateVec3FromLatLon(Earthquake e)
    {
        float r = sphereCollider.radius*100.5f;

        var threePosition = 
            Quaternion.AngleAxis((float)e.lon,-Vector3.up) 
            * Quaternion.AngleAxis((float)e.lat, -Vector3.right) 
            * new Vector3(0.0f, 0.0f, 1.0f) * r;

        return threePosition;
    }

}
