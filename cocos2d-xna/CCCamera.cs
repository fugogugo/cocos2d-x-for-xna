/****************************************************************************
Copyright (c) 2010-2012 cocos2d-x.org
Copyright (c) 2008-2009 Jason Booth
Copyright (c) 2011-2012 openxlive.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cocos2d
{
    public class CCCamera : CCObject
    {

        protected float m_fEyeX;
        protected float m_fEyeY;
        protected float m_fEyeZ;

        protected float m_fCenterX;
        protected float m_fCenterY;
        protected float m_fCenterZ;

        protected float m_fUpX;
        protected float m_fUpY;
        protected float m_fUpZ;

        protected bool m_bDirty;
        /// <summary>
        ///  sets \ get the dirty value
        /// </summary>
        public bool Dirty
        {
            get { return m_bDirty; }
            set { m_bDirty = value; }
        }

        public CCCamera()
        {
            init();
        }

        public void init()
        {
            restore();
        }

        public string description()
        {
            string ret;
            ret = String.Format("<CCCamera | center = ({0},{1},{2})>", m_fCenterX, m_fCenterY, m_fCenterZ);
            //sprintf(ret, "<CCCamera | center = (%.2f,%.2f,%.2f)>", m_fCenterX, m_fCenterY, m_fCenterZ);
            return ret;
        }

        /// <summary>
        /// sets the camera in the default position
        /// </summary>
        public void restore()
        {
            m_fEyeX = m_fEyeY = 0.0f;
            m_fEyeZ = getZEye();

            m_fCenterX = m_fCenterY = m_fCenterZ = 0.0f;

            m_fUpX = 0.0f;
            m_fUpY = 1.0f;
            m_fUpZ = 0.0f;

            m_bDirty = false;
        }
        /// <summary>
        ///  Sets the camera using gluLookAt using its eye, center and up_vector
        /// </summary>
        public void locate()
        {
            if (m_bDirty)
            {
                //gluLookAt(m_fEyeX, m_fEyeY, m_fEyeZ,
                //    m_fCenterX, m_fCenterY, m_fCenterZ,
                //    m_fUpX, m_fUpY, m_fUpZ);
            }
        }
        /// <summary>
        /// sets the eye values in points
        /// </summary>
        /// <param name="fEyeX"></param>
        /// <param name="fEyeY"></param>
        /// <param name="fEyeZ"></param>
        public void setEyeXYZ(float fEyeX, float fEyeY, float fEyeZ)
        {
            m_fEyeX = fEyeX * CCDirector.sharedDirector().ContentScaleFactor;
            m_fEyeY = fEyeY * CCDirector.sharedDirector().ContentScaleFactor;
            m_fEyeZ = fEyeZ * CCDirector.sharedDirector().ContentScaleFactor;

            m_bDirty = true;
        }

        /// <summary>
        /// sets the center values in points
        /// </summary>
        /// <param name="fCenterX"></param>
        /// <param name="fCenterY"></param>
        /// <param name="fCenterZ"></param>
        public void setCenterXYZ(float fCenterX, float fCenterY, float fCenterZ)
        {
            m_fCenterX = fCenterX * CCDirector.sharedDirector().ContentScaleFactor;
            m_fCenterY = fCenterY * CCDirector.sharedDirector().ContentScaleFactor;
            m_fCenterZ = fCenterZ * CCDirector.sharedDirector().ContentScaleFactor;

            m_bDirty = true;
        }

        /// <summary>
        ///  sets the up values
        /// </summary>
        /// <param name="fUpX"></param>
        /// <param name="fUpY"></param>
        /// <param name="fUpZ"></param>
        public void setUpXYZ(float fUpX, float fUpY, float fUpZ)
        {
            m_fUpX = fUpX;
            m_fUpY = fUpY;
            m_fUpZ = fUpZ;

            m_bDirty = true;
        }

        /// <summary>
        ///  get the eye vector values in points
        /// </summary>
        /// <param name="pEyeX"></param>
        /// <param name="pEyeY"></param>
        /// <param name="pEyeZ"></param>
        public void getEyeXYZ(out float pEyeX, out float pEyeY, out float pEyeZ)
        {
            pEyeX = m_fEyeX / CCDirector.sharedDirector().ContentScaleFactor;
            pEyeY = m_fEyeY / CCDirector.sharedDirector().ContentScaleFactor;
            pEyeZ = m_fEyeZ / CCDirector.sharedDirector().ContentScaleFactor;
        }

        /// <summary>
        ///  get the center vector values int points 
        /// </summary>
        /// <param name="pCenterX"></param>
        /// <param name="pCenterY"></param>
        /// <param name="pCenterZ"></param>
        public void getCenterXYZ(out float pCenterX, out float pCenterY, out float pCenterZ)
        {
            pCenterX = m_fCenterX / CCDirector.sharedDirector().ContentScaleFactor;
            pCenterY = m_fCenterY / CCDirector.sharedDirector().ContentScaleFactor;
            pCenterZ = m_fCenterZ / CCDirector.sharedDirector().ContentScaleFactor;
        }

        /// <summary>
        ///  get the up vector values
        /// </summary>
        /// <param name="pUpX"></param>
        /// <param name="pUpY"></param>
        /// <param name="pUpZ"></param>
        public void getUpXYZ(out float pUpX, out float pUpY, out float pUpZ)
        {
            pUpX = m_fUpX;
            pUpY = m_fUpY;
            pUpZ = m_fUpZ;
        }

        /// <summary>
        /// returns the Z eye
        /// </summary>
        /// <returns></returns>
        public static float getZEye()
        {
            return 1.192092896e-07F;
        }

        //private:


        //    DISALLOW_COPY_AND_ASSIGN(CCCamera);
    }
}
