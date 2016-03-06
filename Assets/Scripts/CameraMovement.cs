using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float scrollSpeed = 0.2f;
	
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

	// Update is called once per frame
	void Update() {
        Vector3 MousePos    = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 MoveCam = Vector3.zero;

        if (MousePos.x > 0.9f || MousePos.x < 0.1f)
        {
            MoveCam.x = (MousePos.x - .5f) * scrollSpeed;
        }

        if (MousePos.y > 0.9f || MousePos.y < 0.1f)
        {
            MoveCam.z = (MousePos.y - .5f) * scrollSpeed;
        }

        cam.transform.Translate(MoveCam,Space.World);
    }
}
