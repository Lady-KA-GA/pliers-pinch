using UnityEngine;
using System.Collections;

public class PoseToChange : MonoBehaviour 
{
public void PoseDeactive()
	{
		Time.timeScale = 1;
		Pose.i = false;
	}
}
