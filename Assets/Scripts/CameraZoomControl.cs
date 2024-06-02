using UnityEngine;

public class CameraZoomControl : MonoBehaviour
{
    public float zoomSpeed = 10f; // Speed of zooming
    public float minZoom = 5f; // Minimum zoom limit
    public float maxZoom = 50f; // Maximum zoom limit

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("CameraZoomControl script needs to be attached to a Camera object.");
        }
        else if (!cam.orthographic)
        {
            Debug.LogError("CameraZoomControl script is designed for orthographic cameras.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cam != null && cam.orthographic)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
