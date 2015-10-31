using UnityEngine;

public class SinglePlayerFinishScript : MonoBehaviour
{
    public MatchManagerScript MatchManager
    {
        get { return MatchManagerScript.Instance; }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinishObject") == true)
        {
            MatchManager.DidReachFinish();
        }
    }
}
