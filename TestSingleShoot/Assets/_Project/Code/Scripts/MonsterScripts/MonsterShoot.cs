using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public Weapon weapon;
    public void Shoot()
    {
        // ��������� ��������
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, weapon.range))
        {
            Debug.Log("������ �����! � ������ " + _hit.collider.name);
            if (_hit.collider.tag == "Player")
            {
                string namePlayer = _hit.collider.name;
                Player player = _hit.collider.GetComponent<Player>();
                player.TakeDamage(weapon.damage);
                Debug.Log("Monster shoot in " + _hit.collider.name);
            }
        }
    }
}
