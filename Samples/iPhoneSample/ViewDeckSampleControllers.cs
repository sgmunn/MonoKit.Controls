// //  --------------------------------------------------------------------------------------------------------------------
// //  <copyright file="ViewDeckSampleControllers.cs" company="sgmunn">
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

namespace ViewDeckSamples
{
    using System;
    using MonoTouch.Dialog;
    using MonoKit.Controls.ViewDeck;
    using MonoTouch.UIKit;

    public class LeftController : DialogViewController
    {
        public LeftController() : base(new RootElement("Left"))    
        {
            this.Root.Add
                (
                    new Section("Left") 
                    {
                    new StringElement("Show Center", this.ShowCenter),
                });
        }
        
        public void ShowCenter()
        {
            var deck = this.ParentViewController as ViewDeckController;
            if (deck != null)
            {
                deck.ShowCenterView();
            }
        }
    }
    
    public class RightController : DialogViewController
    {
        public RightController() : base(new RootElement("Right"))    
        {
            this.Root.Add
                (
                    new Section("Right") 
                    {
                    new StringElement("Show Center", this.ShowCenter),
                });
        }
        
        public void ShowCenter()
        {
            var deck = this.ParentViewController as ViewDeckController;
            if (deck != null)
            {
                deck.ShowCenterView();
            }
        }
    }
    
    public class CenterController : DialogViewController
    {
        public CenterController(bool addCloseButton) : base(new RootElement("Right"))    
        {
            if (addCloseButton)
            {
                this.Root.Add(
                    new Section("") 
                    {
                        new StringElement("Close Sample", this.Close),
                    });
            }

            this.Root.Add(
                new Section("Deck Control")
                {
                    new StringElement("Open Left", this.OpenLeft),
                    new StringElement("Open Right", this.OpenRight),
                    new StringElement("Swap Left and Right", this.Swap)
                }
            );

            // for navigation sample
            if (this.NavigationController != null)
            {
                this.Root.Add(
                    new Section("") 
                    {
                    new StringElement("Some other controller", this.GoNext),
                });
            }
        }
        
        public void Close()
        {
            this.DismissViewController(true, null);
        }
        
        public void OpenLeft()
        {
            var deck = this.ParentViewController as ViewDeckController;
            deck.OpenLeftView();
        }
        
        public void OpenRight()
        {
            var deck = this.ParentViewController as ViewDeckController;
            deck.OpenRightView();
        }
        
        public void Swap()
        {
            var deck = this.ParentViewController as ViewDeckController;
            var left = deck.LeftController;
            var right = deck.RightController;
            deck.LeftController = right;
            deck.RightController = left;
        }
        
        public void GoNext()
        {
            this.NavigationController.PushViewController(new SomeOtherController(), true);
        }
    }
    
    public class SomeOtherController : DialogViewController
    {
        public SomeOtherController() : base(new RootElement("Other"))    
        {
            this.Root.Add
                (
                    new Section("") 
                    {
                    new StringElement("Hello", this.Test),
                });
        }
        
        public void Test()
        {
        }
    }

    
    public class NavigationStartController : DialogViewController
    {
        private bool contained;
        
        public NavigationStartController(bool contained) : base(new RootElement("NavStart"))
        {
            this.contained = contained;
            this.Title = "Start";

            this.Root.Add
                (
                    new Section("") 
                    {
                    new StringElement("Close Sample", this.Close),
                });
            
            this.Root.Add
                (
                    new Section("") 
                    {
                    new StringElement("Go to Deck", this.GotoDeck),
                });
        }

        public void Close()
        {
            this.DismissViewController(true, null);
        }   
        
        public void GotoDeck()
        {
            var leftController = new LeftController(); 
            var rightController = new RightController();
            
            var centerController = new CenterController(false);
            centerController.Title = "Center";
            
            var deckController = new ViewDeckController(centerController, leftController, rightController);
            deckController.RightLedge = 40;
            deckController.LeftLedge = 100;
            
            if (this.contained)
            {
                deckController.NavigationControllerBehavior = ViewDeckNavigationControllerBehavior.Contained;
            }
            else
            {
                deckController.NavigationControllerBehavior = ViewDeckNavigationControllerBehavior.Integrated;
            }
            
            this.NavigationController.PushViewController(deckController, true);
        }
    }

    
    public class MultiMiddleController : DialogViewController
    {
        public MultiMiddleController() : base(new RootElement("Middle"))
        {
            this.Root.Add
                (
                    new Section("Middle") 
                    {
                    new StringElement("Open Bottom", this.OpenLeft),
                });
        }

        public void OpenLeft()
        {
            var deck = this.ParentViewController as ViewDeckController;
            deck.OpenLeftView();
        }
        
        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            return true;
        }
    }
    
    public class MultiBottomController : DialogViewController
    {
        public MultiBottomController() : base(new RootElement("Bottom"))
        {
            this.Root.Add
                (
                    new Section("Bottom") 
                    {
                    new StringElement("Hello", this.Hello),
                });
        }

        public void Hello()
        {
        }
    }
    
    public class MultiTopController : DialogViewController
    {
        public MultiTopController() : base(new RootElement("Top"))
        {
            this.Root.Add
                (
                    new Section("") 
                    {
                    new StringElement("Close Sample", this.Close),
                });

            this.Root.Add
                (
                    new Section("Top") 
                    {
                    new StringElement("Open Middle", this.Open),
                });
        }
        
        public void Close()
        {
            this.DismissViewController(true, null);
        }
        
        public void Open()
        {
            var deck = this.ParentViewController as ViewDeckController;
            deck.OpenLeftView();
        }
    }
}

