using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mime;
using Cirrious.MvvmCross.Binding.Touch.ExtensionMethods;
using Cirrious.MvvmCross.Converters;
using Cirrious.MvvmCross.Interfaces.Commands;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.Conference.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Views;

namespace Cirrious.Conference.UI.Touch
{
	public class AboutView : MvxBindingTouchViewController<AboutViewModel>
	{
	    public AboutView(MvxShowViewModelRequest request) : base(request)
	    {
	    }

        private UIScrollView _scrollview;
        private int _currentTop = 0;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Black;

            _scrollview = new UIScrollView(new RectangleF(0,0,320,365));
            View.AddSubview(_scrollview);
			
            AddHeading("SQLBitsXApp");
            AddTextBlock("AboutSQLBitsXApp");
            AddCommand(ViewModel.ContactSlodgeCommand, "StuartLinkText", "appbar.feature.email.rest");
            AddTextBlock("Disclaimer");

            AddHeading("SQLBitsX");
            AddTextBlock("AboutSQLBitsX");
            AddCommand(ViewModel.ShowSqlBitsCommand,"SQLBitsLinkText","appbar.link");

            AddHeading("SQLBits");
            AddTextBlock("AboutSQLBits");
            AddCommand(ViewModel.ShowSqlBitsCommand,"SQLBitsLinkText","appbar.link");

            AddHeading("MvvmCross");
            AddTextBlock("AboutMvvmCross");
            AddCommand(ViewModel.ContactSlodgeCommand, "StuartLinkText", "appbar.feature.email.rest");
            AddTextBlock("ForMvvmSource");
            AddCommand(ViewModel.MvvmCrossOnGithubCommand, "MvvmCrossLinkText", "appbar.link");
            AddTextBlock("ForXamarin");
            AddCommand(ViewModel.MonoTouchCommand, "MonoTouch", "appbar.link");
            AddCommand(ViewModel.MonoDroidCommand, "MonoForAndroid", "appbar.link");
                            
            AddTextBlock("DisclaimerMono");

            _scrollview.ContentSize = new SizeF(320, _currentTop);
        }

        private string GetText(string which)
        {
            return ViewModel.TextSource.GetText(which);
        }

	    private void AddHeading(string which)
	    {
	        _currentTop += 10;
            var frame = new RectangleF(10, _currentTop, 300, 30);
	        var view = new UILabel(frame);
	        view.BackgroundColor = UIColor.Black;
            view.TextColor = UIColor.White;
	        view.Text = GetText(which);
            view.Font = UIFont.FromName("Helvetica", 17);
            view.AdjustsFontSizeToFitWidth = false;
            AddView(view);
			_currentTop += 2;
        }

	    private void AddTextBlock(string which)
	    {
			var text = GetText(which);
			var nsText = new NSString(text);
			var font = UIFont.FromName("Helvetica", 13);
			var size = nsText.StringSize(font, new SizeF(300,100000), UILineBreakMode.WordWrap);
			var frame = new RectangleF(10, _currentTop, 300, size.Height);
            var view = new UILabel(frame);
            view.BackgroundColor = UIColor.Black;
            view.AutoresizingMask = UIViewAutoresizing.None;
	        view.AdjustsFontSizeToFitWidth = false;
            view.TextColor = UIColor.White;
	        view.Font = font;
			view.LineBreakMode = UILineBreakMode.WordWrap;
            view.Text = GetText(which);
			view.Lines = 0;
            AddView(view);
        }

	    private void AddCommand(IMvxCommand command, string whichText, string image)
	    {
            var frame = new RectangleF(10, _currentTop, 280, 37);
	        var button = UIButton.FromType(UIButtonType.Custom);
	        button.Frame = frame;
	        button.BackgroundColor = UIColor.Black;
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.SetTitle(GetText(whichText), UIControlState.Normal);
            button.SetImage(UIImage.FromFile("ConfResources/Images/" + image + ".png"), UIControlState.Normal);
            AddView(button);
			
			button.TouchDown += (sender, e) => command.Execute();
	    }

	    private void AddView(UIView view)
	    {
            _scrollview.AddSubview(view);
            _currentTop += (int)view.Frame.Height;
	    }
	}

	public partial class MapView : MvxBindingTouchViewController<MapViewModel>
	{
		public MapView (MvxShowViewModelRequest request) : base (request, "MapView", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            Button1.SetImage(UIImage.FromFile("ConfResources/Images/appbar.link.png"), UIControlState.Normal);
            Button2.SetImage(UIImage.FromFile("ConfResources/Images/appbar.phone.png"), UIControlState.Normal);
            Button3.SetImage(UIImage.FromFile("ConfResources/Images/appbar.feature.email.rest.png"), UIControlState.Normal);

            this.AddBindings(new Dictionary<object, string>()
		                         {
                                     {Label1,"{'Text':{'Path':'Name'}}"}, 
                                     {Button1,"{'Title':{'Path':'Address'}}"},
                                     {Button2,"{'Title':{'Path':'Phone'}}"},
                                     {Button3,"{'Title':{'Path':'Email'}}"},
		                         });

            this.AddBindings(new Dictionary<object, string>()
		                         {
                                     {Button1,"{'TouchDown':{'Path':'WebPageCommand'}}"},
                                     {Button2,"{'TouchDown':{'Path':'PhoneCommand'}}"},
                                     {Button3,"{'TouchDown':{'Path':'EmailCommand'}}"},
		                         });

#warning TODO - map setup!
        }
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

