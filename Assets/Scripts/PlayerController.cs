using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float lat;
    private float lon;

    [SerializeField]
    private MapController mapTile;

    void Awake()
    {
        GetCoordinates(ref lat, ref lon);
    }

    private void Update()
    {
        GetCoordinates(ref lat, ref lon);
        //mapTile.UpdateMap(lat, lon);
    }

    // fetch player's latitude and longitude in real time
    private void GetCoordinates(ref float lat, ref float lon)
    {
        lat = 32.7157f;
        lon = 117.1611f;
    }
}
