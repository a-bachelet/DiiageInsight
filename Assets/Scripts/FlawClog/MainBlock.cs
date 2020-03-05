using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MainBlock : MonoBehaviour
{
    #region Variables

    // The object destroyable status
    private bool _destroyable = false;
    // The object interactable behavior
    private Interactable _interactable;
    // The object renderer
    private Renderer _renderer;
    // The object RigidBody
    private Rigidbody _rigidbody;

    // The object possible materials
    public List<Material> materials = new List<Material>();

    #endregion Variables

    #region Unity

    // Called before the first frame update
    private void Start()
    {
        // Sets variables
        this._interactable = GetComponent<Interactable>();
        this._renderer = GetComponent<Renderer>();
        this._rigidbody = GetComponent<Rigidbody>();

        // Sets the object material value with a randomly picked material value every 0.2 seconds
        this.InvokeRepeating("randomizeObjectMaterial", 0, 0.2f);
    }

    // Called once per frame
    private void Update()
    {
    }

    // Called when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // If the object is destroyable
        if (this._destroyable)
        {
            // Destroy the object
            Destroy(this.gameObject);
        }
    }

    #endregion Unity

    #region SteamVR

    // Called once per frame while the object is attached to the hand
    private void HandAttachedUpdate(Hand hand)
    {
        // Makes the object destroyable
        this._destroyable = true;

        // Gets the actual grabbing end type
        GrabTypes endGrabType = hand.GetGrabEnding();

        // If the object is not being grabbed anymore
        if (endGrabType != GrabTypes.None)
        {
            // Detaches the object from the hand
            hand.DetachObject(this.gameObject, true);
            // Adds an impulse force to the detached object
            this._rigidbody.AddForce(Vector3.back * 1000 * Time.deltaTime, ForceMode.Impulse);
        }
    }

    // Called once per frame while the hand is hovering the object
    private void HandHoverUpdate(Hand hand)
    {
        // Gets the actual grabbing start type
        GrabTypes startGrabType = hand.GetGrabStarting();

        // If the object is being grabbed
        if (startGrabType != GrabTypes.None)
        {
            // Cancels all function calls runned programmatically
            this.CancelInvoke();
            // Reduces the size of the object making it 70% smaller
            this.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            // Attaches the object to the hand
            hand.AttachObject(this.gameObject, startGrabType);
        }
    }

    #endregion SteamVR

    #region Behavior

    // Sets the object material value with a randomly picked material value
    private void randomizeObjectMaterial()
    {
        // Gets the material list size
        int materialsCount = this.materials.ToArray().Length;

        // If there is at least one material in the material list
        if (materialsCount != 0)
        {
            // Gets a random number according to the material list size
            int randomNumber = Random.Range(0, materialsCount);
            // Picks a random material from the material list
            Material randomMaterial = this.materials[randomNumber];
            // Sets the object material value with the randomly picked material value
            this._renderer.material = randomMaterial;
        }
    }

    #endregion Behavior
}