﻿using System;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class PlayerMovementComponent : IUpdateable
    {
        private Bounds objectData;

        public PlayerMovementComponent(Bounds objectData)
        {
            this.objectData = objectData;
        }

        public void Move()
        {
            var keyboardState = Keyboard.GetState();

            // handel left right movement
            var leftRightAxis = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -0.1f :
                keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 0.1f : 0f;

            objectData.MinX += leftRightAxis;
            objectData.MinX = Math.Max(objectData.MinX, -1f);

            // handel upwards movement
            if (keyboardState.IsKeyDown(Key.Up) || keyboardState.IsKeyDown(Key.W))
            {
                objectData.MinY += 0.1f;
                objectData.MinY = Math.Max(objectData.MinY, -1f);
            }

            // handel downwards movement
            if (keyboardState.IsKeyDown(Key.Down) || keyboardState.IsKeyDown(Key.S))
            {
                objectData.MinY += -0.1f;
                objectData.MinY = Math.Max(objectData.MinY, -1f);
            }
        }
    }
}