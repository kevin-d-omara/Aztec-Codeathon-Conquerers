using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RealtimeLocationData : MonoBehaviour
{

    public float latitude { get; set; }
    public float longitude { get; set; }

    public IEnumerator GetLocation()
    {
        Debug.Log("Starting");
        //Pass true to use mocked Location. Pass false or don't pass anything to use real location
        LocationServiceExt locationServiceExt = new LocationServiceExt(true);

        LocationInfoExt locInfo = new LocationInfoExt();
        locInfo.latitude = 32.7757f;
        locInfo.longitude = -117.0719f;
        locInfo.altitude = -3.0f;
        locInfo.horizontalAccuracy = 5.0f;
        locInfo.verticalAccuracy = 5.0f;
        locationServiceExt.lastData = locInfo;

        // First, check if user has location service enabled
        if (!locationServiceExt.isEnabledByUser)
        {
            Debug.Log("Location Data Not Enabled");
            yield break;
        }
        else
        {
            Debug.Log("Enabled!");
        }

        // Start service before querying location
        locationServiceExt.Start();


        // Wait until service initializes
        int maxWait = 20;
        while (locationServiceExt.status == LocationServiceStatusExt.Initializing && maxWait > 0)
        {
            Debug.Log("Timer: " + maxWait);
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // Connection has failed
        if (locationServiceExt.status == LocationServiceStatusExt.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            latitude = locationServiceExt.lastData.latitude;
            longitude = locationServiceExt.lastData.longitude;

            string location = "Latitude: " + latitude + "\nLongitude: " + longitude;
            string morelocationdata = "Altitude: " + locationServiceExt.lastData.altitude + "Horizontal Accuracy: " + locationServiceExt.lastData.horizontalAccuracy + "TimeStamp: " + locationServiceExt.lastData.timestamp;

            // print(location);
        }

        // Stop service if there is no need to query location updates continuously
        locationServiceExt.Stop();
    }    
}