using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace Practicas.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        private List<SKPath> paths = new List<SKPath>();
        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();

        public ICommand OnPaintingCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            OnPaintingCommand = new ICommand<object, SKPaintSurfaceEventArgs>OnPainting;
        }

        public void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.AliceBlue);

            var touchPathStroke = new SKPaint
            {
                Color = SKColors.OrangeRed,
                StrokeWidth = 2,
                Style = SKPaintStyle.Stroke
            };

            foreach (var touchPath in paths)
            {
                canvas.DrawPath(touchPath, touchPathStroke);
            }
        }

        public void OnTouch(object sender, SKTouchEventArgs e)
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

    }
}
