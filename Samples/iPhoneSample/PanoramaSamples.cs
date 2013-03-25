// //  --------------------------------------------------------------------------------------------------------------------
// //  <copyright file="PanoramaSamples.cs" company="sgmunn">
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

namespace PanoramaSamples
{
    using System;
    using System.Drawing;
    using MonoKit.Controls.Panorama;
    using MonoTouch.UIKit;
    using MonoTouch.Dialog;

    public class TestPanorama : UIPanoramaViewController
    {
        public TestPanorama()
        {    
            this.Title = "my minions";
            this.AddController(new Item2Controller(), 0);
            this.AddController(new Item1Controller(), 0);
            this.AddController(new Item3Controller(), 0);
        }
        
        public override void LoadView()
        {
            base.LoadView();
            
            this.BackgroundView.BackgroundColor = UIColor.Brown;
            
            var img = UIImage.FromBundle("Images/brushTexture1.png");
            
            this.BackgroundView.AddSubview(
                new UIView(new RectangleF(0, 0, 1200, 1000)) { BackgroundColor = UIColor.FromPatternImage(img)}
            );
        }
    }
    
    public class Item1Controller : DialogViewController
    {
        private bool doneInit;
        public Item1Controller() : base(UITableViewStyle.Plain, new RootElement("Item1"))
        {
            this.Title = "item 1";
            
            this.Root.Add(
                new Section("")
                {
                new StringElement("close sample", this.Close),
                new StringElement("test", this.DoTest),
                new StringElement("add", this.DoAdd),
            });
        }
        
        private void Close()
        {
            var p = this.ParentViewController as UIPanoramaViewController;
            p.DismissViewController(true, null);
        }
        
        private void DoTest()
        {
            var p = this.ParentViewController as UIPanoramaViewController;
            p.Present(new OtherController());
        }

        private void DoAdd()
        {
            var p = this.ParentViewController as UIPanoramaViewController;
            p.AddController(new Item3Controller());
        }
    }
    
    public class Item2Controller : UIViewController
    {
        public Item2Controller() : base()
        {
            this.Title = "item 2";
        }
        
        public override void LoadView()
        {
            base.LoadView();
            this.View = new UIView() { BackgroundColor = UIColor.Cyan };
        }
    }
    
    public class Item3Controller : DialogViewController
    {
        public Item3Controller() : base(UITableViewStyle.Plain, new RootElement("Item3"))
        {
            this.Title = "item 3";
        }
    }
    
    
    public class OtherController : DialogViewController
    {
        public OtherController() : base(UITableViewStyle.Grouped, new RootElement("Other"))
        {
            this.Root.Add(
                new Section("")
                {
                new StringElement("Close", this.Close),
            });
        }
        
        public override void LoadView()
        {
            base.LoadView();
            this.View.BackgroundColor = UIColor.Clear;
        }

        public void Close()
        {
            var p = this.ParentViewController as UIPanoramaViewController;
            p.Dismiss(true);
        }
    }
}