using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Portal : MonoBehaviour
{
    private Interactable _interactable;
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        _interactable = GetComponent<Interactable>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_interactable.isHovering)
        {
            if (_interactable.attachedToHand)
            {
                Debug.Log("Attached");
            }
        }
    }


    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);
        
        if (_interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            Debug.Log("TELEPORTING");
            SteamVR_LoadLevel.Begin(SceneName);
        }
    }
}
