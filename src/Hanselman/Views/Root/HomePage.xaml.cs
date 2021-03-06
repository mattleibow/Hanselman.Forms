﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hanselman.Controls;
using Hanselman.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hanselman.Views
{
    public partial class HomePage : TabbedPage
    {
        public HomePage ()
        {
            InitializeComponent();

            if(DeviceInfo.Platform == DevicePlatform.UWP)
            {
                Children.Insert(1, new HanselmanNavigationPage(new BlogPage())
                {
                    Title = "Blog"
                });
            }
            else
            {
                Children.Insert(1, new HanselmanNavigationPage(new BlogCollectionPage())
                {
                    Title = "Blog",
                    IconImageSource = "ic_rss.png"
                });
            }
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            if (CurrentPage is IPageHelpers page)
            {
                page.OnPageVisible();
            }
            else if (CurrentPage is NavigationPage navPage &&
                navPage.CurrentPage is IPageHelpers subPage)
            {
                subPage.OnPageVisible();
            }
        }
    }
}