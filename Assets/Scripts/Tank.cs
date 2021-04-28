using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] float _delayBetweenShoots;
    [SerializeField] private float _recoilDIstance;
    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                transform.DOMoveX(transform.position.x + _recoilDIstance, _delayBetweenShoots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
        }
    }
    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
    }
}
