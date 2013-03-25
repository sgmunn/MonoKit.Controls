// //  --------------------------------------------------------------------------------------------------------------------
// //  <copyright file="AwesomeMenuSamples.cs" company="sgmunn">
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

namespace AwesomeMenuSamples
{
    using System;
    using MonoTouch.Dialog;
    using MonoTouch.UIKit;
    using MonoKit.Controls.AwesomeMenu;

    public class MenuController : DialogViewController
    {
        public MenuController() : base(new RootElement("Menu"))    
        {
            this.Root.Add(
                new Section("") 
                {
                new StringElement("Close Sample", this.Close),
            });
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            var storyMenuItemImage = UIImage.FromFile("Images/bg-menuitem.png");
            var storyMenuItemImagePressed = UIImage.FromFile("Images/bg-menuitem-highlighted.png");
            
            var starImage = UIImage.FromFile("Images/icon-star.png");
            
            var starMenuItem1 = new MenuItem(storyMenuItemImage, storyMenuItemImagePressed, starImage);
            var starMenuItem2 = new MenuItem(storyMenuItemImage, storyMenuItemImagePressed, starImage);
            var starMenuItem3 = new MenuItem(storyMenuItemImage, storyMenuItemImagePressed, starImage);
            
            var menu = new Menu(
                this.View.Bounds,
                UIImage.FromFile("Images/bg-addbutton.png"),                                                               
                UIImage.FromFile("Images/bg-addbutton-highlighted.png"),                                                               
                UIImage.FromFile("Images/icon-plus.png"),                                                               
                UIImage.FromFile("Images/icon-plus-highlighted.png")                                                               
                );

            menu.MenuItems.AddRange(new[] { starMenuItem1, starMenuItem2, starMenuItem3 });
            
            menu.MenuItemSelected += (sender, e) => Console.WriteLine(e.Selected);
            
            menu.BackgroundColor = UIColor.White;
            this.View.AddSubview(menu);
        }
        
        public void Close()
        {
            this.DismissViewController(true, null);
        }
    }
}