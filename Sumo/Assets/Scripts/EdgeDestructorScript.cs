using UnityEngine;
using System.Collections;

public class EdgeDestructorScript : MonoBehaviour
{
    public MatchManagerScript MatchManager = null;
    public GameObject ExplosionPrefab = null;

    void Start()
    {
        Debug.Assert(MatchManager != null, "Match manager object not set.");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LevelEdge")
        {
            MatchManager.PlayerDied(gameObject.tag);

            if (ExplosionPrefab != null)
            {
                Vector3 explosionPosition = transform.position;
                /// Lower explosion position's Y a bit.
                explosionPosition.y = 0.5f;
                Instantiate(ExplosionPrefab, explosionPosition, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}