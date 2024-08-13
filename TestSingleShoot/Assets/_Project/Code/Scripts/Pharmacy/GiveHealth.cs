using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("������ �������");
            Player player = other.gameObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("player �� �������� ����������");
                return;
            }
            player.TakeDamage(-25);
            Destroy(gameObject);
        }
    }
}
