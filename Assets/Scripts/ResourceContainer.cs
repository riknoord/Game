using UnityEngine;
using System.Collections;

public class ResourceContainer : MonoBehaviour {

    public Resource[] Resources;

    void Awake()
    {
        ResourceManager manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ResourceManager>();
        manager.AddToResourceList(this);
    }

}
