using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Delphin.Staff.Styles
{
    public class StylePage
    {
        public static Style stcCollectionView
        {
            set { }
            get
            {
                return new Style(typeof(CollectionView))
                {
                    Setters =
                    {
                        new Setter{ Property=CollectionView.MarginProperty, Value = new Thickness(5,0,5,0)}                        
                    }
                };
            }
        }
        public static Style stlActivityIndicator
        {
            set { }
            get
            {
                return new Style(typeof(ActivityIndicator))
                {
                    Setters =
                    {
                        new Setter{ Property=ActivityIndicator.ColorProperty, Value = Color.Blue},
                        new Setter{ Property= ActivityIndicator.IsRunningProperty, Value = true}
                    }
                };
            }
        }

        public static Style stlCellFrame
        {
            set { }
            get
            {
                return new Style(typeof(Frame))
                {
                    Setters =
                    {
                        new Setter{ Property=Frame.PaddingProperty, Value=new Thickness(0)}
                    }
                };
            }
        }

        public static Style stlLabelRight
        {
            private set { }
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                        {
                            new Setter{ Property = Label.HorizontalTextAlignmentProperty, Value=TextAlignment.End}
                        }
                };
            }
        }

        public static Style stlLabelBlue
        {
            private set { }
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                        {
                            new Setter{ Property = Label.TextColorProperty, Value=Color.Blue}
                        }
                };
            }
        }
        public static Style stlLabelCenter
        {
            private set { }
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                        {
                            new Setter{ Property = Label.HorizontalTextAlignmentProperty, Value=TextAlignment.Center}
                        }
                };
            }
        }

        public static Style stlView
        {
            private set { }
            get 
            {
                return new Style(typeof(View))
                {
                    Setters =
                    {
                        new Setter{ Property= View.BackgroundColorProperty, Value=Color.FromHex("#E5E5E5")}
                    }
                };
            }
        }

        public static Style stlCellView
        {
            private set { }
            get
            {
                return new Style(typeof(View))
                {
                    Setters =
                    {
                        new Setter{ Property= View.BackgroundColorProperty, Value=Color.White}
                    }
                };
            }
        }
        public static Style stlBtnView
        {
            private set { }
            get
            {
                return new Style(typeof(Button))
                {
                    Setters =
                    {
                        new Setter{ Property= Button.BackgroundColorProperty, Value=Color.Blue},
                        new Setter{ Property= Button.TextColorProperty, Value=Color.White},
                        new Setter{ Property=Button.VerticalOptionsProperty, Value= LayoutOptions.Fill},
                        new Setter{ Property=Button.MarginProperty, Value=new Thickness(5,0,5,5)}
                    }
                };
            }
        }


        public class Main
        {
            public static Style stlLabel
            {
                private set { }
                get
                {
                    return new Style(typeof(Label))
                    {                        
                        Setters =
                        {
                            //new Setter{ Property = Label.HorizontalTextAlignmentProperty, Value= nu}
                        }
                    };
                }
            }

            public static Style stlCellNewsActualTitle
            {
                private set { }
                get
                {
                    return new Style(typeof(Label))
                    {
                        //BasedOn = stlLabelCenter,
                        Setters =
                        {
                            new Setter{ Property = Label.MarginProperty, Value=new Thickness(5,10,5,10)}
                        }
                    };
                }
            }
            public static Style stlCellNewsActualHeader
            {
                private set { }
                get
                {
                    return new Style(typeof(Label))
                    {
                        BasedOn= stlLabelCenter,
                        Setters =
                        {
                            new Setter{ Property = Label.TextColorProperty, Value=Color.Blue}
                        }
                    };
                }
            }

            //public static Style stlCellHotNewsBackgroundColor
            //{
            //    private set { }
            //    get
            //    {
            //        return new Style(typeof(View))
            //        {
            //            Setters =
            //            {
            //                new Setter{ Property = View.BackgroundColorProperty, Value=Color.FromRgba(0,0,0,3)}
            //            }
            //        };
            //    }
            //}

        }
        public class News
        {
            public static Style stlLabelNewsTitle
            {
                private set { }
                get
                {
                    return new Style(typeof(Label))
                    {
                        BasedOn=stlLabelBlue,
                        Setters =
                        {
                            
                        }
                    };
                }
            }
        }
        public class History
        {
            public static Style stlToolbarLabel
            {
                private set { }
                get
                {
                    return new Style(typeof(Label))
                    {
                        Setters =
                        {
                            new Setter{ Property = Label.HorizontalTextAlignmentProperty, Value=TextAlignment.Center},
                            new Setter{ Property = Label.TextColorProperty, Value=Color.Blue}
                        }
                    };
                }
            }
        }

        public class Yet
        {
            public static Style stlCellFrame
            {
                private set { }
                get
                {
                    return new Style(typeof(Frame))
                    {
                        Setters =
                        {
                            new Setter{ Property=Frame.PaddingProperty, Value=new Thickness(15)}
                        }
                    };
                }
            }

            public static Style stlCellLabel
            {
                private set { }
                get
                {
                    return new Style(typeof(Label))
                    {
                        Setters =
                        {}
                    };
                }
            }

            public static Style stlCollectionView
            {
                private set { }
                get
                {
                    return new Style(typeof(CollectionView))
                    {
                        Setters =
                        {
                            new Setter{ Property=CollectionView.MarginProperty, Value = new Thickness(10)}
                        }
                    };
                }
            }
        }
    }
}
