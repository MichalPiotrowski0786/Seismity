using System.Collections;
using System.Collections.Generic;

public class Earthquake
{
    public string name;
    public string time;
    public float mag;
    public float lon;
    public float lat;
    public float depth;

    public Earthquake(string name, string time, string mag, string lon, string lat, string depth)
    {
        this.name = name;
        this.time = time;
        float.TryParse(mag,out this.mag);
        float.TryParse(lon,out this.lon);
        float.TryParse(lat,out this.lat);
        float.TryParse(depth, out this.depth);

        FixErrors(true);
    }

    private void FixErrors(bool isEnabled)
    {
        if(!isEnabled)
        {
            return;
        }
        else
        {
            if(depth < 10)
            {
                depth = 10;
            }

            if(mag < 0.1)
            {
                mag = 0.1f;
            }
        }
    }
}
