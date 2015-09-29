using UnityEngine;
using System.Collections.Generic;

public class BallSkinScript : MonoBehaviour
{
    public GameObject Ball1 = null;
    public GameObject Ball2 = null;

    /// <summary>
    /// Possible ball prefab combinations.
    /// </summary>
    private List<string[]> ballPrefabCombinations = null;

    // Use this for initialization
    void Start()
    {
        InitPrefabCombinations();
        RemoveBallModels();
        AddPrefabs();
    }

    /// <summary>
    /// Disables ball gameobject's mesh rendeder to hide the underlying sample model.
    /// </summary>
    private void RemoveBallModels()
    {
        Debug.Assert(Ball1 != null, "Ball 1 poitner not set.");
        Debug.Assert(Ball2 != null, "Ball 2 poitner not set.");

        RemoveModelForBall(Ball1);
        RemoveModelForBall(Ball2);
    }

    /// <summary>
    /// Gets mesh renderer for game object & disables it.
    /// </summary>
    /// <param name="ball"></param>
    private void RemoveModelForBall(GameObject ball)
    {
        MeshRenderer renderer = ball.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        else
        {
            Debug.Log("Failed getting mesh renderer for object " + ball);
        }
    }

    /// <summary>
    /// Adds ball prefab variants as models for balls.
    /// </summary>
    private void AddPrefabs()
    {
        // load prefab pair
        if (ballPrefabCombinations.Count > 0)
        {
            int randomNumber = Random.Range(0, ballPrefabCombinations.Count);

            string[] randomPair = ballPrefabCombinations[randomNumber];
            if (randomPair.Length == 2)
            {
                string prefab1name = randomPair[0];
                string prefab2name = randomPair[1];

                // load prefabs
                GameObject obj1 = LoadGameObjectByName(prefab1name);
                GameObject obj2 = LoadGameObjectByName(prefab2name);

                // set to objects
                InstantiatePrefab(obj1, Ball1);
                InstantiatePrefab(obj2, Ball2);
            }
            else
            {
                Debug.Log("Invalid random pair " + randomPair);
            }
        }
        else
        {
            Debug.Log("Ball prefab combinations empty.");
        }
    }

    /// <summary>
    /// Instantiates prefab object as a child to the parent object.
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="parentObject"></param>
    private void InstantiatePrefab(GameObject prefab, GameObject parentObject)
    {
        if (prefab != null && parentObject != null)
        {
            GameObject instance = (GameObject)Instantiate(prefab, parentObject.transform.position, Quaternion.identity);
            instance.transform.parent = parentObject.transform;
        }
        else
        {
            Debug.Log("Prefab or parent object not set. Prefab: " + prefab + " Parent: " + parentObject);
        }
    }

    private GameObject LoadGameObjectByName(string name)
    {
        GameObject result = null;

        string path = "Prefab/Balls/" + name;
        result = (GameObject)Resources.Load(path);
        
        return result;
    }

    /// <summary>
    /// Initializes prefab objects dictionary.
    /// </summary>
    private void InitPrefabCombinations()
    {
        ballPrefabCombinations = new List<string[]>();

        string[] possibleElements =
        {
            "ball_variant_foot",
            "ball_variant_rugged",
            "ball_variant_mesh"
        };

        // add any combination of the ball kinds
        for (int i = 0; i < possibleElements.Length; ++i)
        {
            for (int j = 0; j < possibleElements.Length; ++j)
            {
                AddBallPair(possibleElements[i], possibleElements[j]);
            }
        }
    }

    private void AddBallPair(string ballName1, string ballName2)
    {
        string[] comb1 = { ballName1, ballName2 };
        ballPrefabCombinations.Add(comb1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
