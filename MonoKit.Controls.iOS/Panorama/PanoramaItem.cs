// //  --------------------------------------------------------------------------------------------------------------------
// //  <copyright file="PanoramaItem.cs" company="sgmunn">
// //    (c) sgmunn 2013  
// //
// //    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// //    documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// //    the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// //    to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// //
// //    The above copyright notice and this permission notice shall be included in all copies or substantial portions of 
// //    the Software.
// //
// //    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
// //    THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// //    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// //    CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
// //    IN THE SOFTWARE.
// //  </copyright>
// //  --------------------------------------------------------------------------------------------------------------------

namespace MonoKit.Controls
{
    using System;
    using System.Drawing;
    using MonoTouch.UIKit;

    /// <summary>
    /// </summary>
    internal sealed class PanoramaItem
    {
        private float width;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MonoKit.Metro.PanoramaItem"/> class.
        /// </summary>
        public PanoramaItem(UIViewController controller, float width)
        {
            this.Controller = controller;
            this.width = width;
        }
        
        /// <summary>
        /// Gets the controller for the item
        /// </summary>
        public UIViewController Controller { get; private set; }
        
        /// <summary>
        /// Gets the width of the item
        /// </summary>
        public float GetWidth(float frameWidth, float previewSize)
        {
            return this.width != 0 ? this.width : frameWidth - previewSize;
        }
        
        // used by controller to manage state
        public UILabel HeaderView { get; set;}
        
        public UIView ContentView { get; set; }
        
        public PointF Origin { get; set; }
        
        public SizeF Size { get; set; }
        
        public SizeF HeaderSize { get; set; }
    }
}