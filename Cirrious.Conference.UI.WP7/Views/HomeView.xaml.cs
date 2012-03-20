﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Cirrious.Conference.Core.ViewModels;
using Microsoft.Phone.Controls;

namespace Cirrious.Conference.UI.WP7.Views
{
    public class BaseHomeView : BaseView<HomeViewModel>
    {
        
    }

    public partial class HomeView 
        : BaseHomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}