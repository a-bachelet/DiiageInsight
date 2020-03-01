using System.Collections.Generic;
using UnityEngine;

public class MainBlock : MonoBehaviour
{
    public List<Material> materials = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeBlockMaterial", 1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeBlockMaterial()
    {
        int rnd = Random.Range(0, materials.ToArray().Length);

        GetComponent<Renderer>().material = materials[rnd];       
    }
}
