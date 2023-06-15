using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    public LayerMask mask;
    RaycastHit hit;

    void Update()
    {
        //Rays for calculate touch place
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                transform.LookAt(hit.point);
            }
        }
    }
}
