using UnityEngine;
using System.Collections;
using Vector3 = UnityEngine.Vector3;


public class RayShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    private float speed = 50;

    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Rigidbody rg;
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit(hit);
                }
                // else
                // {
                //     StartCoroutine(SphereIndicator(hit.point));
                // }
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
    private void jump(Rigidbody rig)
    {
        rig.AddForce(rig.transform.up * speed, ForceMode.Impulse);
    }
}