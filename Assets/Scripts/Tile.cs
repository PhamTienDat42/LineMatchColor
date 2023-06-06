using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorDotsPz
{
    public class Tile : MonoBehaviour
    {
        [Header("SpriteRenderers")]
        public SpriteRenderer circleEnd;
        public SpriteRenderer circleTrace;
        public SpriteRenderer tick;
        public SpriteRenderer trace;
        public SpriteRenderer square;
        [Space]
        public SpriteRenderer upWallThin;
        public SpriteRenderer downWallThin;
        public SpriteRenderer leftWallThin;
        public SpriteRenderer rightWallThin;
        [Space]
        public SpriteRenderer upWallThick;
        public SpriteRenderer downWallThick;
        public SpriteRenderer leftWallThick;
        public SpriteRenderer rightWallThick;

        [HideInInspector]
        public int id;
        private bool _empty;
        private Vector2 _directionTrace;


#if UNITY_EDITOR
        void Start()
        {
            if (!circleEnd || !tick || !trace || !upWallThin || !downWallThin || !leftWallThin || !rightWallThin ||
                !upWallThick || !downWallThick || !leftWallThick || !rightWallThick)
            {
                Debug.LogError("No SpriteRenderer");
            }
        }
#endif

        public bool IsEmpty() { return _empty; }

        public void SetEmpty(bool empty)
        {
            if (empty)
            {
                square.enabled = false;
            }
            _empty = empty;
        }

        public Color GetColor()
        {
            return circleTrace.color;
        }

        public void SetColorTrace(Color c)
        {
            if (!circleEnd.enabled)
            {
                circleTrace.color = c;
                trace.color = c;
            }
        }

        public void SetColorStart(Color c)
        {
            circleEnd.color = c;
            circleTrace.color = c;
            trace.color = c;
        }

        public void SetCircleEnd(bool active)
        {
            circleEnd.enabled = active;
        }

        public void SetCircleTrace(bool active)
        {
            circleTrace.enabled = active;
        }

        public void SetSmallCircle(bool active)
        {
            circleEnd.enabled = active;
            circleEnd.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        public bool IsEnd() { return circleEnd.enabled; }

        public void SetTick(bool active)
        {
            tick.enabled = active;
        }

        public void SetThinWalls(bool up, bool down, bool left, bool right)
        {
            upWallThin.enabled = up;
            downWallThin.enabled = down;
            leftWallThin.enabled = left;
            rightWallThin.enabled = right;
        }

        public void SetThickWalls(bool up, bool down, bool left, bool right)
        {
            upWallThick.enabled = up;
            downWallThick.enabled = down;
            leftWallThick.enabled = left;
            rightWallThick.enabled = right;
        }

        //public void SetThickWalls(Utils.Coord direction, bool active)
        //{
        //    if (direction.x == direction.y)
        //        return;

        //    if (direction.y == -1)
        //        upWallThick.enabled = active;
        //    else if (direction.y == 1)
        //        downWallThick.enabled = active;
        //    else if (direction.x == -1)
        //        leftWallThick.enabled = active;
        //    else if (direction.x == 1)
        //        rightWallThick.enabled = active;
        //}

        
        public bool IsTraceActive()
        {
            return trace.enabled;
        }

        //public bool IsWallInDirection(Utils.Coord direction)
        //{
        //    bool isWall = false;
        //    if (direction.y == -1)
        //        isWall = upWallThick.enabled;
        //    else if (direction.y == 1)
        //        isWall = downWallThick.enabled;
        //    else if (direction.x == -1)
        //        isWall = leftWallThick.enabled;
        //    else if (direction.x == 1)
        //        isWall = rightWallThick.enabled;

        //    return isWall;
        //}

       
        public void ActiveTrace(Vector2 direction)
        {
            if (direction.y < 0)
                SetUp(true);
            else if (direction.y > 0)
                SetDown(true);
            else if (direction.x > 0)
                SetRight(true);
            else if (direction.x < 0)
                SetLeft(true);

            _directionTrace = direction;
        }

        public Vector2 GetDirectionTrace()
        {
            return _directionTrace;
        }

        public void DesactiveTrace()
        {
            trace.enabled = false;
            SetColorTrace(Color.clear);
        }

        private void SetUp(bool enabled)
        {
            trace.enabled = enabled;        
            trace.size = new Vector2(0.25f, 1.25f);
            trace.transform.localPosition = new Vector3(0, 0.5f, 0);
        }
        private void SetDown(bool enabled)
        {
            trace.enabled = enabled;
            trace.size = new Vector2(0.25f, 1.25f);
            trace.transform.localPosition = new Vector3(0, -0.5f, 0);
        }
        private void SetLeft(bool enabled)
        {
            trace.enabled = enabled;
            trace.size = new Vector2(1.25f, 0.25f);
            trace.transform.localPosition = new Vector3(-0.5f, 0, 0);
        }
        private void SetRight(bool enabled)
        {
            trace.enabled = enabled;
            trace.size = new Vector2(1.25f, 0.25f);
            trace.transform.localPosition = new Vector3(0.5f, 0, 0);
        }
    }
}