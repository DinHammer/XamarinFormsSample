﻿using CoreAnimation;
using CoreGraphics;
using Dlphn.iOS.Renderers;
using Dlphn.Staff.Customs.Controls;
using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using FrameRenderer = Xamarin.Forms.Platform.iOS.FrameRenderer;

[assembly: ExportRenderer(typeof(MgcFrame), typeof(MgcFrameRenderer))]

namespace Dlphn.iOS.Renderers
{
    public class MgcFrameRenderer : FrameRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            UpdateCornerRadius();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(MgcFrame.CornerRadius) ||
                e.PropertyName == nameof(MgcFrame))
            {
                UpdateCornerRadius();
            }
        }

        // A very basic way of retrieving same one value for all of the corners
        private double RetrieveCommonCornerRadius(CornerRadius cornerRadius)
        {
            var commonCornerRadius = cornerRadius.TopLeft;
            if (commonCornerRadius <= 0)
            {
                commonCornerRadius = cornerRadius.TopRight;
                if (commonCornerRadius <= 0)
                {
                    commonCornerRadius = cornerRadius.BottomLeft;
                    if (commonCornerRadius <= 0)
                    {
                        commonCornerRadius = cornerRadius.BottomRight;
                    }
                }
            }

            return commonCornerRadius;
        }

        private UIRectCorner RetrieveRoundedCorners(CornerRadius cornerRadius)
        {
            var roundedCorners = default(UIRectCorner);

            if (cornerRadius.TopLeft > 0)
            {
                roundedCorners |= UIRectCorner.TopLeft;
            }

            if (cornerRadius.TopRight > 0)
            {
                roundedCorners |= UIRectCorner.TopRight;
            }

            if (cornerRadius.BottomLeft > 0)
            {
                roundedCorners |= UIRectCorner.BottomLeft;
            }

            if (cornerRadius.BottomRight > 0)
            {
                roundedCorners |= UIRectCorner.BottomRight;
            }

            return roundedCorners;
        }

        private void UpdateCornerRadius()
        {
            var cornerRadius = (Element as MgcFrame)?.CornerRadius;
            if (!cornerRadius.HasValue)
            {
                return;
            }

            var roundedCornerRadius = RetrieveCommonCornerRadius(cornerRadius.Value);
            if (roundedCornerRadius <= 0)
            {
                return;
            }

            var roundedCorners = RetrieveRoundedCorners(cornerRadius.Value);

            var path = UIBezierPath.FromRoundedRect(Bounds, roundedCorners, new CGSize(roundedCornerRadius, roundedCornerRadius));
            var mask = new CAShapeLayer { Path = path.CGPath };
            NativeView.Layer.Mask = mask;
        }
    }
}