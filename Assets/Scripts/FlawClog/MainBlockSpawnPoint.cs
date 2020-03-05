using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlockSpawnPoint : MonoBehaviour
{
    #region Variables

    // The game current main block
    private MainBlock _currentMainBlock;

    // A MainBlock object
    public MainBlock mainBlock;

    #endregion Variables

    #region Unity

    // Called before the first frame update
    private void Start()
    {
        // Sets variables
        this._currentMainBlock = Instantiate(this.mainBlock, this.transform);
    }

    // Called once per frame
    private void Update()
    {
        if (this._currentMainBlock == null)
        {
            this._currentMainBlock = Instantiate(this.mainBlock, this.transform);
        }
    }

    #endregion Unity
}
