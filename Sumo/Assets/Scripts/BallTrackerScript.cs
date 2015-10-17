using UnityEngine;
using System.Collections;

public class BallTrackerScript : MonoBehaviour
{
    public Transform ObjectToTrack = null;

    bool trackerStatus = false;

    void Update()
    {
        if (ObjectToTrack != null)
        {
            // lock up Y position from start - arena start from 0.0f
            //transform.position = ObjectToTrack.position;
            Vector3 position = ObjectToTrack.position;
            position.y = 0.0f;
            transform.position = position;
        }
    }

    void SetStatus(bool on)
    {
        if (trackerStatus != on)
        {
            trackerStatus = on;

            Renderer[] objectsToDisable = GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in objectsToDisable)
            {
                obj.enabled = on;
                //if (on == true)
                //{
                //    //obj.Play();
                //}
                //else
                //{
                //    obj.Stop();
                //    obj.Clear();
                //}
            }
        }
    }


    public void HideTracker()
    {
        SetStatus(false);
    }

    public void ShowTracker()
    {
        SetStatus(true);
    }
}
