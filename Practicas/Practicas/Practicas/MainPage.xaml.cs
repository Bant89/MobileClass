
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Practicas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
      
        private List<SKPath> paths = new List<SKPath>();
        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
        public SKColor touchPathColor = SKColors.OrangeRed;
        public int lineas = 0;
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
                var surface = e.Surface;
                var canvas = surface.Canvas;
                
                var touchPathStroke = new SKPaint
                {
                    Color = touchPathColor,
                    StrokeWidth = 20,
                    Style = SKPaintStyle.Stroke
                };

                for (int i = lineas; i < paths.Count; i++)
                {
                    var touchPath = paths[i];
                    canvas.DrawPath(touchPath, touchPathStroke);
                    lineas++;
                }
        }

        private void OnTouch(object sender, SKTouchEventArgs e)
        {

            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    var p = new SKPath();
                    p.MoveTo(e.Location);
                    temporaryPaths[e.Id] = p;
                    break;
                case SKTouchAction.Moved:
                    if (e.InContact)
                        temporaryPaths[e.Id].LineTo(e.Location);
                    break;
                case SKTouchAction.Released:
                    paths.Add(temporaryPaths[e.Id]);
                    temporaryPaths.Remove(e.Id);
                    break;
            }

            e.Handled = true;

            // update the UI on the screen
            ((SKCanvasView)sender).InvalidateSurface();

        }

        void OnTapRecognized(object sender, EventArgs args)
        {
            var BoxSender = (BoxView)sender;
            touchPathColor = new SKColor((byte)(BoxSender.BackgroundColor.R * 255), 
                (byte)(BoxSender.BackgroundColor.G * 255), 
                (byte)(BoxSender.BackgroundColor.B * 255), 
                (byte)(BoxSender.BackgroundColor.A * 255));
            System.Diagnostics.Debug.WriteLine(BoxSender.BackgroundColor);
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
        }

    }
}
