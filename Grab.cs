using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    bool isMouseHover;
    bool isGrab;
    Vector3 offset;
    public GameObject gun;
    public bool lockX;
    public bool lockY;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isMouseHover = true;
        }
        else
        {
            isMouseHover = false;
        }

        if (isMouseHover && Input.GetMouseButtonDown(0))
        {
            isGrab = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = new Vector3(offset.x, offset.y, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isGrab = false;
            gun.GetComponent<Animator>().SetBool("IsOpen", false);
        }

        if (isGrab)
        {
            Lookat(gun);
            gun.GetComponent<Animator>().SetBool("IsOpen", true);
            if (lockX)
            {
                if (lockY)
                {

                }
                else
                {
                    transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) + new Vector3(0, offset.y);
                }
            }
            else
            {
                if (lockY)
                {
                    transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y) + new Vector3(offset.x, 0);
                }
                else
                {
                    transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) + offset;
                }
            }

        }
    }

    void Lookat(GameObject _gameObject)
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _gameObject.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        _gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
