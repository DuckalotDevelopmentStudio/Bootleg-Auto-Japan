using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shoot : NetworkBehaviour {

    public GameObject bullet; //Bullet prefab

    /* public void TriggerPull(int amount, Transform emmisionTransform, ParticleSystem muzzleFlash,float spread)
     {
         for (int i = 0; i < amount; i++) //Repeats for amount of bullets
         {

             Vector3 pos = new Vector3(emmisionTransform.position.x, emmisionTransform.position.y,emmisionTransform.position.z);
             Vector3 fireDirection = transform.forward;
             Quaternion fireRotation = Quaternion.LookRotation(fireDirection);
             Quaternion randomRotation = Random.rotation;
             fireRotation = Quaternion.RotateTowards(fireRotation, randomRotation, Random.Range(-spread, spread));
             GameObject GO = Instantiate(bullet, pos, fireRotation);
             NetworkServer.Spawn(GO);
         }
     }*/
     
}
