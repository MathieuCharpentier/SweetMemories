using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionExtensions {

	public static bool OnGround(this CollisionFlags cf){
		return (cf & CollisionFlags.Below)!=0 ;
	}	

}
