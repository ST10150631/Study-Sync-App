using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog6212_POE_ST10150631.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserCntrlClock.xaml
    /// </summary>
    public partial class UserCntrlClock : UserControl
    {
        public UserCntrlClock()
        {
            InitializeComponent();
            
        }
        public void Stop()
        {
            StopClockAnimation();
        }
        public void Play()
        {
            StartClockAnimation();
        }
        private void StartClockAnimation()
        {
            var secondHandAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(60), // 60 seconds for one full rotation
                RepeatBehavior = RepeatBehavior.Forever // Repeat indefinitely
            };
            var minuteHandAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromMinutes(60), // 60 seconds for one full rotation
                RepeatBehavior = RepeatBehavior.Forever // Repeat indefinitely
            };

            // Set the rotation axis for the second hand
            RotateTransform secondRotate = new RotateTransform();
            secondHand.RenderTransform = secondRotate;

            // Set the rotation axis for the Minute hand
            RotateTransform minuteRotate = new RotateTransform();
            minuteHand.RenderTransform = minuteRotate;

            // Apply the animation to the second hand
            secondRotate.BeginAnimation(RotateTransform.AngleProperty, secondHandAnimation);
            minuteRotate.BeginAnimation(RotateTransform.AngleProperty, minuteHandAnimation);
        }
        private void StopClockAnimation()
        {
            var secondHandAnimation = new DoubleAnimation
            {
            };
            var minuteHandAnimation = new DoubleAnimation
            {
            };

            // Set the rotation axis for the second hand
            RotateTransform secondRotate = new RotateTransform();
            secondHand.RenderTransform = secondRotate;

            // Set the rotation axis for the Minute hand
            RotateTransform minuteRotate = new RotateTransform();
            minuteHand.RenderTransform = minuteRotate;

            // Apply the animation to the second hand
            secondRotate.BeginAnimation(RotateTransform.AngleProperty, secondHandAnimation);
            minuteRotate.BeginAnimation(RotateTransform.AngleProperty, minuteHandAnimation);
        }
    }
}
