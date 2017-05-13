using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Profiler
{
    public class MovementLogic : Logic
    {
        public float movementSpeed;
        public Vector3 velocity;
        public Vector3 direction;
        public bool controllable;
        float xAxis = 0, yAxis = 0;

        Rigidbody rigidbody;

        // Use this for initialization
        public void Start() {
            LogicHandler logicHandler = GameObject.Find("Root").GetComponent<LogicHandler>();

            logicHandler.AddToLogicHandler(this);

            rigidbody = GetComponent<Rigidbody>();
            int random = Random.Range(0, 4);
            if (random > 1) {
                controllable = true;
            }
            direction = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
        }

        // Update is called once per frame
        public override void LogicUpdate() {
            if (controllable) {
                CheckInput();
                direction = new Vector3(xAxis, 0, yAxis);
            }
            direction = direction.normalized;
            velocity = transform.rotation * direction * movementSpeed;
            rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
        }

        void CheckInput() {

            if (UnityEngine.Input.GetButtonDown("Forward")) {
                yAxis += 1.0f;
            } else if (UnityEngine.Input.GetButtonUp("Forward")) {
                yAxis -= 1.0f;
            }
            if (UnityEngine.Input.GetButtonDown("Backward")) {
                yAxis -= 1.0f;
            } else if (UnityEngine.Input.GetButtonUp("Backward")) {
                yAxis += 1.0f;
            }
            if (UnityEngine.Input.GetButtonDown("Left")) {
                xAxis -= 1.0f;
            } else if (UnityEngine.Input.GetButtonUp("Left")) {
                xAxis += 1.0f;
            }
            if (UnityEngine.Input.GetButtonDown("Right")) {
                xAxis += 1.0f;
            } else if (UnityEngine.Input.GetButtonUp("Right")) {
                xAxis -= 1.0f;
            }

            xAxis = Mathf.Clamp(xAxis, -1.0f, 1.0f);
            yAxis = Mathf.Clamp(yAxis, -1.0f, 1.0f);
        }
    }
}
