using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Guns
{
    public GameObject objCentralGun;
    public GameObject objRightGun;
    public GameObject objLeftGun;
}
public class PlayerShooting : MonoBehaviour
{
    [HideInInspector] public int maxPowerLevelGuns = 5;
    public static PlayerShooting instance;
    public GameObject objBullet;
    public Guns guns;
    public float timeBulletSpawn = 0.3f;
    public float timerShot;
    [Range(1, 5)] public int curPuwerLevelGuns = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Time.time > timerShot)
        {
            timerShot = Time.time + timeBulletSpawn;
            MakeAShot();
        }
    }

    private void CreateBullet(GameObject bullet, Vector3 positionBullet, Vector3 rotationBullet)
    {
        Instantiate(bullet, positionBullet, Quaternion.Euler(rotationBullet));
    }

    private void MakeAShot()
    {
        switch (curPuwerLevelGuns)
        {
            case 1:
                CreateBullet(objBullet, guns.objCentralGun.transform.position, Vector3.zero);
                break;
            case 2:
                CreateBullet(objBullet, guns.objRightGun.transform.position, Vector3.zero);
                CreateBullet(objBullet, guns.objLeftGun.transform.position, Vector3.zero);
                break;
            case 3:
                CreateBullet(objBullet, guns.objCentralGun.transform.position, Vector3.zero);
                CreateBullet(objBullet, guns.objRightGun.transform.position, new Vector3(0,0,-5));
                CreateBullet(objBullet, guns.objLeftGun.transform.position, new Vector3(0,0,5));
                break;
            case 4:
                CreateBullet(objBullet, guns.objCentralGun.transform.position, Vector3.zero);
                CreateBullet(objBullet, guns.objRightGun.transform.position, new Vector3(0, 0, 0));
                CreateBullet(objBullet, guns.objRightGun.transform.position, new Vector3(0,0,5));
                CreateBullet(objBullet, guns.objLeftGun.transform.position, new Vector3(0,0,0));
                CreateBullet(objBullet, guns.objLeftGun.transform.position, new Vector3(0,0,-5));
                break;
            case 5:
                CreateBullet(objBullet, guns.objCentralGun.transform.position, Vector3.zero);
                CreateBullet(objBullet, guns.objRightGun.transform.position, new Vector3(0, 0, -5));
                CreateBullet(objBullet, guns.objRightGun.transform.position, new Vector3(0, 0, -15));
                CreateBullet(objBullet, guns.objLeftGun.transform.position, new Vector3(0, 0, 5));
                CreateBullet(objBullet, guns.objLeftGun.transform.position, new Vector3(0, 0, 15));
                break;
        }
    }
}
