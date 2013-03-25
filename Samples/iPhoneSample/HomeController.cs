// //  --------------------------------------------------------------------------------------------------------------------
// //  <copyright file="HomeController.cs" company="sgmunn">
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

namespace Sample.Controls
{
	using System;
	using MonoTouch.Dialog;
    using MonoTouch.UIKit;
    using MonoKit.Controls.ViewDeck;
	
	public class HomeController : DialogViewController
	{
		public HomeController() : base(new RootElement("Home"))	
		{
			this.Root.Add
			(
				new Section("View Deck") 
				{
					new StringElement("Simple", this.ViewDeckSimpleSample),
                    new StringElement("Navigation (Contained)", this.ViewDeckContainedSample),
                    new StringElement("Navigation (Integrated)", this.ViewDeckIntegratedSample),
                    new StringElement("Multi-Deck", this.ViewDeckMultiDeckSample),	
				});
			
			this.Root.Add
			(
				new Section("AwesomeMenu") 
				{
					new StringElement("Simple", this.AwesomeMenuSample),
				}
			);
            
            this.Root.Add
                (
                    new Section("Panorama") 
                    {
                    new StringElement("Simple", this.PanoramaSample),
                }
                );
        }
		
		public void ViewDeckSimpleSample()
		{
			var leftController = new ViewDeckSamples.LeftController();
			var rightController = new ViewDeckSamples.RightController();
			
			var centerController = new ViewDeckSamples.CenterController(true);
			
			var deckController = new ViewDeckController(centerController, leftController, rightController);
			deckController.RightLedge = 40;
			deckController.LeftLedge = 100;
            // use this to control if panning is enabled
            // deckController.Enabled = false;
			
			this.PresentViewController(deckController, true, null);
			
		}
        
        public void ViewDeckContainedSample()
        {
            var nav = new UINavigationController(new ViewDeckSamples.NavigationStartController(true));
            
            this.PresentViewController(nav, true, null);
        }
        
        public void ViewDeckIntegratedSample()
        {
            var nav = new UINavigationController(new ViewDeckSamples.NavigationStartController(false));
            
            this.PresentViewController(nav, true, null);
        }
        
        public void ViewDeckMultiDeckSample()
        {
            var leftController = new ViewDeckSamples.MultiMiddleController(); 
            var bottomController = new ViewDeckSamples.MultiBottomController();

            var centerController = new ViewDeckSamples.MultiTopController();

            var secondDeckController = new ViewDeckController(leftController, bottomController);
            secondDeckController.LeftLedge = 100;
            
            var deckController = new ViewDeckController(centerController, secondDeckController);
            deckController.LeftLedge = 30;
            
            this.PresentViewController(deckController, true, null);
        }

        public void AwesomeMenuSample()
        {
            this.PresentViewController(new AwesomeMenuSamples.MenuController(), true, null);
        }

        public void PanoramaSample()
        {
            this.PresentViewController(new PanoramaSamples.TestPanorama(), true, null);
        }

		public void Test()
		{
		}
	}
}