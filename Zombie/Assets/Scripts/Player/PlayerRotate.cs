using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private static GameObject player;
    public LayerMask mask;
    RaycastHit hit;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Rays for calculate touch place
        if (Input.GetMouseButton(0))
        {
            var camera = GetComponent<Camera>();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                player.transform.LookAt(hit.point);
            }
        }
    }
}
