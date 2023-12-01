using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserShot : MonoBehaviour
{
    private Camera camera;

    void Start()
    {
        //інфа про камеру
        camera = GetComponent<Camera> ();

        //прибираєм курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //якщо ліва кнопка миші
        if (Input.GetMouseButtonDown(0))
        {
            //змінна центр екрану
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Ray ray = camera.ScreenPointToRay(screenCenter);//пускаєм пострід
            RaycastHit hit;//змінна попадання 

            //якщо попав
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject; //витягуєм обєкт в який попали
                EnemyTarg target = hitObject.GetComponent<EnemyTarg>();

                //перевірка попадання в ворогга
                if (target != null)
                {
                    target.ReackToHit();
                }
                else
                {
                    StartCoroutine(SphereInicatorCoroutine(hit.point)); //запуск 'сопрограми'
                    Debug.DrawLine(this.transform.position, hit.point, Color.green, 6);//візуалізація траекторії

                }
            }
        }
    }
    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
    {
        //створюєм сфору(майбутній спецефект)
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        //чекаєм 6 секнд і видаляєм сферу
        yield return new WaitForSeconds(6);
        Destroy(sphere);
    }
}
