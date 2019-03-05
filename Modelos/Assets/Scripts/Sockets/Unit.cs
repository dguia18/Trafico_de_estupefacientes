using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public int unitID;
    public bool isPlayersUnit;

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && isPlayersUnit)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (PlayerControl.map.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = hit.point.x;
                float y = hit.point.y;
                float z = hit.point.z;
                GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hit.point);
                PlayerControl.client.Send("Moving|" + unitID + "|" + x + "|" + y + "|" + z + "|");
            }
        }
    }

    public void MoveTo(Vector3 pos)
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(pos);
    }
}
