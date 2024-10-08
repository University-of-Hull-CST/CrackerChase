using System;
using Microsoft.Xna.Framework.Graphics;


namespace DemoGame
{
    class PhysicsMover : Mover
    {
        protected float xAcceleration;
        protected float yAcceleration;

        protected float resetXAcceleration;
        protected float resetYAcceleration;

        protected float friction;
        protected float resetFriction;

        public override void Reset()
        {
            xAcceleration = resetXAcceleration;
            yAcceleration = resetYAcceleration;
            friction = resetFriction;
            base.Reset();
        }


        public PhysicsMover(int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed, float inResetXAccel, float inResetYAccel, float inResetFriction) :
            base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            resetXAcceleration = inResetXAccel;
            resetYAcceleration = inResetYAccel;
            resetFriction = inResetFriction;
            Reset();
        }

        public void SetAcceleration( int inX, int inY)
        {
            xAcceleration = inX;
            yAcceleration = inY;
        }


        public override void Update(float deltaTime)
        {
            if (MovingLeft) xSpeed = xSpeed - (xAcceleration * deltaTime);
            if (MovingRight) xSpeed = xSpeed + (xAcceleration * deltaTime);
            if (MovingUp) ySpeed = ySpeed - (yAcceleration * deltaTime);
            if (MovingDown) ySpeed = ySpeed + (yAcceleration * deltaTime);

            xPosition = xPosition + (xSpeed * deltaTime);
            yPosition = yPosition + (ySpeed * deltaTime);

            if (xPosition < 0) xSpeed = Math.Abs(xSpeed);
            if (xPosition + rectangle.Width > screenWidth) xSpeed = Math.Abs(xSpeed) * -1;

            if (yPosition < 0) ySpeed = Math.Abs(ySpeed);
            if (yPosition + rectangle.Height > screenHeight) ySpeed = Math.Abs(ySpeed) * -1 ;

            xSpeed = xSpeed * (1 - deltaTime * friction);
            ySpeed = ySpeed * (1 - deltaTime * friction);

            if (Math.Abs(xSpeed) < 0.01) xSpeed = 0;
            if (Math.Abs(ySpeed) < 0.01) ySpeed = 0;
        }
    }
}
