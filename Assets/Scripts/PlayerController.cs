using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float lat;
    private float lon;
    
    [SerializeField]
    private MapController mapTile;

    [SerializeField]
    private RealtimeLocationData realTimeLoc;

    void Awake()
    {
        GetCoordinates(ref lat, ref lon);
    }

    private void Update()
    {
        GetCoordinates(ref lat, ref lon);
        StartCoroutine(mapTile.GetGoogleMap(lat,lon));
    }

    // fetch player's latitude and longitude in real time
    private void GetCoordinates(ref float lat, ref float lon)
    {
        StartCoroutine(realTimeLoc.GetLocation());
        lat = lat + realTimeLoc.latitude/100;
        lon = lon + realTimeLoc.longitude/100;
    }
}
