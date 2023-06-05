using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorPassing : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    public FirstPersonMove move;
    public Vector3 pos1;

    public void OpenDoor()
    {
        door.transform.DORotate(new Vector3(0,-90,0), 6f).SetEase(Ease.OutBack);
    }

    public void CloseDoor()
    {
        door.transform.DORotate(new Vector3(0,0,0), 1.5f).SetEase(Ease.OutBack);
    }

    public void LaunchEnd()
    {
        move.enabled = false;
        player.transform.DORotate(new Vector3(0,180,0), 0.5f);
        Camera.main.transform.DOLocalRotate(new Vector3(0,0,0), 0.5f);   
    }

    IEnumerator DoAnim()
    {
        door.transform.DORotate(new Vector3(0,-90,0), 6f).SetEase(Ease.OutBack);
        player.transform.DOMove(pos1, 4.5f, false);
        yield return new WaitForSeconds(6f);
        door.transform.DORotate(new Vector3(0,0,0), 1.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1.5f);
        move.enabled = true;
    }
}
