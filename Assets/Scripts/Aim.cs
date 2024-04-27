using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//part of this script was taken from this tutorial
//https://github.com/BarthaSzabolcs/Tutorial-IsometricAiming/blob/main/Assets/Scripts/Simple%20-%20CopyThis/IsometricAiming.cs
 
public class Aim : MonoBehaviour
{
    #region Datamembers

        #region Editor Settings

        [SerializeField] private LayerMask groundMask;
        public Transform Gun;
        public GameObject BulletPrefab;
        public AudioClip bulletclip;

        #endregion
        #region Private Fields

        private Camera mainCamera;

        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks

        private void Start()
        {
            // Cache the camera, Camera.main is an expensive operation.
            mainCamera = Camera.main;
            
        }

        private void Update()
        {
           MouseAim();
           if(Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                GameObject createdBullet = Instantiate(BulletPrefab, transform.position, transform.localRotation);
                AudioSource.PlayClipAtPoint(bulletclip, transform.position);
            }
        }
        

        #endregion

        private void MouseAim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                // Calculate the direction
                var direction = position - transform.position;

                // Ignore the height difference.
                direction.y = 0;

                // Make the transform look in the direction.    
                transform.forward = direction;
            }
        }
        

        private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                // The Raycast hit something, return with the position.
                return (success: true, position: hitInfo.point);
            }
            else
            {
                // The Raycast did not hit anything.
                return (success: false, position: Vector3.zero);
            }
        }

        #endregion
 }

