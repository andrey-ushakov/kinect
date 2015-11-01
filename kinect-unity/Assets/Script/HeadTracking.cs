using UnityEngine;
using System;
using System.Collections;

public class HeadTracking : MonoBehaviour {
	
	public SkeletonWrapper sw;
	public GameObject Head;
	
	public int player;
	
	public float scale = 1.0f;
    /* D�but ajout F. Davesne */
    public bool isTracked;
	/* Fin ajout F. Davesne */

	void Start () {
        isTracked = false;
	}
	
	void Update () {
        if (player == -1) {
            isTracked = false;
            return;
        }

        if (sw.pollSkeleton()) {
            Debug.Log("After pollSkeleton() ");
            isTracked = false;

            transform.localPosition = new Vector3(
                    sw.bonePos[player, (int)Kinect.NuiSkeletonPositionIndex.Head].x * scale,
                    -sw.bonePos[player, (int)Kinect.NuiSkeletonPositionIndex.Head].y * scale,
                    sw.bonePos[player, (int)Kinect.NuiSkeletonPositionIndex.Head].z * scale - 11);

            Debug.Log(sw.bonePos[player, (int)Kinect.NuiSkeletonPositionIndex.Head].x * scale);

            /* Ajout F. Davesne pour rep�rer si les �l�ments du squelette int�ressants sont track�s => isTracked */
            isTracked = isTracked | (sw.boneState[player, (int)Kinect.NuiSkeletonPositionIndex.Head] == Kinect.NuiSkeletonPositionTrackingState.Tracked);
            /* Fin Ajout F. Davesne */
        }
    }
}
