using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject BulletObj;
    [SerializeField] private Transform GunPosition;

    void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating("Shoot", 0f, 0.1f);
    }

    private void Update()
    {
        /* swap 
         
        
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(0f, touch.deltaPosition.x * _rotateSpeed ,0f);

                if ((transform.rotation * rotationY).y <= 0.7f && (transform.rotation * rotationY).y >= -0.7f)
                {
                    transform.rotation *= rotationY;
                }
            }
        }      
        */
    }

    


    private void Shoot()
    {
        Instantiate(BulletObj, GunPosition.position, GunPosition.rotation);
    }

}
