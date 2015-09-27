using UnityEngine;
using System.Collections;

public class ArenaFloorScript : MonoBehaviour
{
    public GameObject FloorObject = null;

    // Use this for initialization
    void Start()
    {
        SetRandomImage();
    }

    private void SetRandomImage()
    {
        Debug.Assert(FloorObject != null, "Floor object not set.");

        // load material
        //Material testMat = (Material)Resources.Load("Images/Ring Textures/Materials/face");

        string materialDirectory = "Images/Ring Textures/Materials/";
        Object[] textures = Resources.LoadAll(materialDirectory);

        if (textures.Length > 0)
        {
            int randomIndex = Random.Range(0, textures.Length);
            Material material = (Material)textures[randomIndex];
            FloorObject.GetComponent<Renderer>().material = material;
        }
        else
        {
            Debug.Log("No floor materials found in directory " + materialDirectory);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
