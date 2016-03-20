using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour {

    private List<ResourceContainer> containers = new List<ResourceContainer>();

    public void AddToResourceList(ResourceContainer _container)
    {
        containers.Add(_container);
    }

    public ResourceContainer ResourceLookup(Resource resource)
    {
        foreach (ResourceContainer container in containers)
        {
            foreach (Resource _resource in container.Resources)
            {
                if (_resource.ResourceType == resource.ResourceType) return container;
            }
        }

        return null;
    }

}
