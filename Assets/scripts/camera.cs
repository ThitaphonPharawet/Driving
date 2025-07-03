using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform player;
    public Vector3 thirdPersonOffset = new Vector3(0, 5, -10);
    public Vector3 firstPersonOffset = new Vector3(0, 2.0f, 0.5f);

    private bool isFirstPerson = false;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFirstPerson = !isFirstPerson;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (isFirstPerson)
        {
            // มุมมองคนขับ
            transform.position = player.position + player.TransformDirection(firstPersonOffset);
            transform.rotation = player.rotation;
        }
        else
        {
            // มุมมองด้านหลัง (บุคคลที่สาม)
            transform.position = player.position + thirdPersonOffset;
            transform.LookAt(player);
        }
    }
}
