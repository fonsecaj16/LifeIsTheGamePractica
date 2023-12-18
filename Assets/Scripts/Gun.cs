using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    private float bulletSpeed = 600f;
    public GunScriptableObject gunScriptableObject;
    private bool canShoot = true;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = gunScriptableObject.gunMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(_input.shoot&&canShoot)
        {
            StartCoroutine(ShootWithDelay());
            _input.shoot = false;
        }
    }

    public void UpdateMaterial()
    {
        renderer.material = gunScriptableObject.gunMaterial;
    }
    IEnumerator ShootWithDelay()
    {
        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.type = gunScriptableObject.type;
        switch (gunScriptableObject.type)
        {
            case (GunType.Parabole):
                Vector3 shootDirection = Quaternion.Euler(-45, 0, 0) * transform.forward;
                bullet.GetComponent<Rigidbody>().AddForce(shootDirection * bulletSpeed);
                rb.useGravity = true ;
                bulletController.power = false;
                break;
            case (GunType.Pull):
            case (GunType.Push):
                bulletController.power = true;
                rb.useGravity = false;
                rb.AddForce(transform.forward * bulletSpeed);
                break;

        }
        Destroy(bullet, 2);
    }
}
