using UnityEngine;
using System.Collections;
using System;

public class Worker : MonoBehaviour {

    private bool isMoving, isWorking = false;
    private ResourceContainer Container;
    private ResourceManager resourceManager;
    private WorldVegetationManager vegetationManager;

    public Resource Gather;

	// Use this for initialization
	void Start () {
        resourceManager = (ResourceManager)GameObject.FindGameObjectWithTag("Manager").GetComponent<ResourceManager>();
        vegetationManager = (WorldVegetationManager)GameObject.FindGameObjectWithTag("Manager").GetComponent<WorldVegetationManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoving || isWorking) return;

        if(Container = resourceManager.ResourceLookup(Gather))
        {
            isMoving = true;
            gameObject.GetComponent<Movement>().MoveTo( this.findClosestTree() , () => { this.StartWorking(); });
        }
	}

    private Vector3 findClosestTree()
    {
        return vegetationManager.findClosest(this.gameObject).transform.position;
    }

    private void StartWorking()
    {
        isWorking = true;
        isMoving = false;

        StartCoroutine("Work");
    }

    IEnumerator Work()
    {
        while (this.Gather.Amount < 5)
        {
            this.Gather.Amount++;
            yield return new WaitForSeconds(1f);
        }

        gameObject.GetComponent<Movement>().MoveTo(Container.gameObject.transform.position);
    }

}
