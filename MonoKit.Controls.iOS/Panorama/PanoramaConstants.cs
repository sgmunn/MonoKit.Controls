//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="PanoramaConstants.cs" company="sgmunn">
//    (c) sgmunn 2012  
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//    documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
//    the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
//    to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all copies or substantial portions of 
//    the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//    THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
//    CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
//    IN THE SOFTWARE.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
//

namespace MonoKit.Controls.Panorama
{
    using System;
    using MonoTouch.UIKit;

    /// <summary>
    /// Constants for panorama views
    /// </summary>
    public static class PanoramaConstants
    {
        /// <summary>
        /// The amount of the next content item that is visible 
        /// </summary>
        public static float NextContentItemPreviewSize = 50;

        public static float DefaultBackgroundMotionRate = 0.1f;

        /// <summary>
        /// The name of the default font to use for titles
        /// </summary>
        public static string DefaultFontName = "Thonburi";

        /// <summary>
        /// The name of the default font to use for titles
        /// </summary>
        public static string DefaultFontBoldName = "Thonburi-Bold";

        /// <summary>
        /// The default font size for titles
        /// </summary>
        public static float DefaultTitleFontSize = 46;

        /// <summary>
        /// The default font size for titles
        /// </summary>
        public static float DefaultHeaderFontSize = 36;

        /// <summary>
        /// The default text color for titles
        /// </summary>
        public static UIColor DefaultTextColor = UIColor.White;

        /// <summary>
        /// The left margin between content items and titles
        /// </summary>
        public static float Margin = 10;
    }
}
