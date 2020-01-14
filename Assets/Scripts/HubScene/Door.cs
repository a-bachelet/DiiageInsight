using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator DoorAnimator;
    public GameObject Portal;
    private bool _isOpen;

    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        if (!_isOpen)
        {
            Portal.SetActive(true);
            _isOpen = true;
            DoorAnimator.SetTrigger("Open");
        }
    }
}
