using UnityEngine;
using System.Collections;

public class MouseToWorld : MonoBehaviour {

    public GameObject Building;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(r,out hit)){
                Instantiate(Building, hit.point, Quaternion.identity);
            }
        }

    }

}
