using UnityEngine;
using System.Collections;

public class ThrustScript : MonoBehaviour
{
    public float ForceMultiplier = 10.0f;
    public float ThrustTimeout = 0.5f;
    private Rigidbody rb = null;
    private float timeSinceLastThrust = 0.0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(rb != null, "Rigidbody not set for thrust script. No thrusting will occur.");
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastThrust += Time.deltaTime;
        if (timeSinceLastThrust >= ThrustTimeout)
        {
            if (isThrustKeyPressed() == true)
            {
                ApplyThrust();
            }
        }
    }

    /// <summary>
    /// Checks if the thrust key is pressed. Fire1 (A button) for player 1, D-Pad axis Y for player 2.
    /// </summary>
    /// <returns></returns>
    private bool isThrustKeyPressed()
    {
        bool result = false;

        string buttonName = "Fire";
        if (gameObject.tag == "Player1")
        {
            buttonName += "1";
        }
        else if (gameObject.tag == "Player2")
        {
            buttonName += "2";
        }

        result = Input.GetButtonDown(buttonName);
        if (result == false)
        {
            buttonName += "Keyboard";
            result = Input.GetButtonDown(buttonName);
        }
        
        return result;
    }

    private void ApplyThrust()
    {
        /// Reset last thrust time.
        timeSinceLastThrust = 0.0f;

        /// Apply thrust in the heading direction.
        float h = 0.0f;
        float v = 0.0f;
        UnityStandardAssets.Vehicles.Ball.BallUserControl.GetInputValues(out h, out v, gameObject);

        Vector3 directionVector = new Vector3();
        directionVector.x = h;
        directionVector.z = v;

        rb.AddForce(directionVector * ForceMultiplier, ForceMode.Impulse);
    }
}
