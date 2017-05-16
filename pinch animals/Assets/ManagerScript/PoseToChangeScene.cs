using UnityEngine;
using System.Collections;

public class PoseToChangeScene : MonoBehaviour 
{

public void PoseDeactive()
	{
		Time.timeScale = 1;
		Pose.i = false;
	}
}
