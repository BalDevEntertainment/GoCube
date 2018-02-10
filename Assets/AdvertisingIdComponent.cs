using UnityEngine;

public class AdvertisingIdComponent : MonoBehaviour{

    private void Start()
    {
        Application.RequestAdvertisingIdentifierAsync (
            (string advertisingId, bool trackingEnabled, string error) =>
            { Debug.Log ("advertisingId " + advertisingId + " " + trackingEnabled + " " + error); }
        );
    }
}