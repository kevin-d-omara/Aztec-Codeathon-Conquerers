using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{
    string url = "";
    public float lat = 32.7157f;
    public float lon = 117.1611f;

    LocationInfo li;
    public int zoom = 19; // zoom level; 0 = entire world; 21+ individual street/buildings

    // max 640 by 640 pixels
    public int mapWidth = 640;
    public int mapHeigh = 640;

    public enum mapType { roadmap, satellite, hybrid, terrain };
    public mapType mapSelected;

    public int scale; // scale can be 1,2 for free plan and can also be 4 for paid
    IEnumerator GetGoogleMap()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
                    "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeigh + "&scale=" + scale
                    + "&maptype=" + mapSelected +
                    "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284";
        WWW www = new WWW(url);
        yield return www;

        Texture2D textureToReplace = gameObject.GetComponent<SpriteRenderer>().sprite.texture;
        www.LoadImageIntoTexture(textureToReplace);
    }

    void Start()
    {
        StartCoroutine(GetGoogleMap());
    }
}
