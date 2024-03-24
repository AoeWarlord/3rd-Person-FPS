using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform laserSpawn;
    public float laserVelocity = 150;
    KillCounter killCounterScript;

    // Private variable that has a reference to the camera
    private Camera cam;

    private bool allowedToShoot = true;

    private PlayerCharacter stillAlive;
    // Start is called before the first frame update
    void Start()
    {
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
        //Use GetComponent to get a reference to the Camera
        cam = GetComponent<Camera>();

        stillAlive = GetComponentInParent<PlayerCharacter>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        allowedToShoot = stillAlive.notDead;
        if (allowedToShoot)
        {
            //Run the following code if the player clicks the left mouse button
            if (Input.GetMouseButtonDown(0))
            {
                GameObject laser = Instantiate(laserPrefab, laserSpawn.position, Quaternion.identity);
                laser.GetComponent<Rigidbody>().AddForce(laserSpawn.forward.normalized * laserVelocity, ForceMode.Impulse);

                Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

                Ray ray = cam.ScreenPointToRay(point);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    if (target != null)
                    {
                        target.ReactToHit();
                        killCounterScript.AddKill();
                    }

                }

                }
        }
    }

    // edit here potentially make smaller
/*    private void OnGUI()
    {
        //font size
        int size = 12;

        //Coords at which the crosshairs are drawn
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        //Draw the crosshairs as text
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
*/
}

