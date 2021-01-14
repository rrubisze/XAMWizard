using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace Wizard.Controls.WizardControl
{
    public partial class Wizard : Grid
    {
        private bool IsInitialized = false;
        private bool IsColorSet = false;
        private bool IsCurrentStepSet = false;
        private bool IsNumberOfStepsSet = false;
        private bool IsLineThicknessSet = false;
        private bool IsCircleStepSizeSet = false;
        private bool IsStepsLabelsSet = false;

        protected List<string> Labels = new List<string>();

        public Wizard()
        {
            InitializeComponent();
            StepsGrid.VerticalOptions = LayoutOptions.Fill;
            StepsGrid.HorizontalOptions = LayoutOptions.Fill;
            StepsGrid.ColumnSpacing = 0;
            StepsGrid.Padding = 0;
            StepsGrid.Margin = 0;
        }

        #region -- Properties --

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public int CurrentStep
        {
            get => (int)GetValue(CurrentStepProperty);
            set => SetValue(CurrentStepProperty, value);
        }

        public int NumberOfSteps
        {
            get => (int)GetValue(NumberOfStepsProperty);
            set => SetValue(NumberOfStepsProperty, value);
        }

        public double LineThickness
        {
            get => (double)GetValue(LineThicknessProperty);
            set => SetValue(LineThicknessProperty, value);
        }

        public double CircleStepSize
        {
            get => (double)GetValue(CircleStepSizeProperty);
            set => SetValue(CircleStepSizeProperty, value);
        }


        public ObservableCollection<string> StepsLabels
        {
            get => (ObservableCollection<string>)GetValue(StepsLabelsProperty);
            set => SetValue(StepsLabelsProperty, value);
        }

        public double LabelFontSize
        {
            get => (double)GetValue(LabelFontSizeProperty);
            set => SetValue(LabelFontSizeProperty, value);
        }

        public string LabelFontFamily
        {
            get => (string)GetValue(LabelFontFamilyProperty);
            set => SetValue(LabelFontFamilyProperty, value);
        }

        public FontAttributes LabelFontAttributes
        {
            get => (FontAttributes)GetValue(LabelFontAttributesProperty);
            set => SetValue(LabelFontAttributesProperty, value);
        }


        #endregion

        #region -- Bindable Properties --

        public static readonly BindableProperty CurrentStepProperty =
            BindableProperty.Create(
                nameof(CurrentStep),
                typeof(int),
                typeof(int),
                default(int),
                propertyChanged: OnCurrentStepChanged);

        public static readonly BindableProperty NumberOfStepsProperty =
            BindableProperty.Create(
                nameof(CurrentStep),
                typeof(int),
                typeof(int),
                default(int),
                propertyChanged: OnNumberOfStepsChanged);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(
                nameof(Color),
                typeof(Color),
                typeof(Color),
                default(Color),
                propertyChanged: OnColorChanged);

        public static readonly BindableProperty LineThicknessProperty =
            BindableProperty.Create(
                nameof(LineThickness),
                typeof(double),
                typeof(double),
                default(double),
                propertyChanged: OnLineThicknessChanged);

        public static readonly BindableProperty CircleStepSizeProperty =
            BindableProperty.Create(
                nameof(CircleStepSize),
                typeof(double),
                typeof(double),
                default(double),
                propertyChanged: OnCircleStepSizeChanged);

        public static readonly BindableProperty StepsLabelsProperty =
            BindableProperty.Create(
                nameof(StepsLabels),
                typeof(ObservableCollection<string>),
                typeof(ObservableCollection<string>),
                default(ObservableCollection<string>),
                propertyChanged: OnStepsLabelsChanged);

        public static readonly BindableProperty LabelFontSizeProperty =
        BindableProperty.Create(
            nameof(LabelFontSize),
            typeof(double),
            typeof(double),
            default(double));

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(
                nameof(LabelFontFamily),
                typeof(string),
                typeof(string),
                default(string));

        public static readonly BindableProperty LabelFontAttributesProperty =
            BindableProperty.Create(
                nameof(LabelFontAttributes),
                typeof(FontAttributes),
                typeof(FontAttributes),
                default(FontAttributes));


        #endregion

        #region -- Events --

        private static void OnCurrentStepChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Wizard;
            control.IsCurrentStepSet = true;
            if (control != null && control.IsAllPropertySet())
            {
                if (!control.IsInitialized)
                    InitializeGrid(control);
            }
        }

        private static void OnNumberOfStepsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Wizard;
            control.IsNumberOfStepsSet = true;
            if (control != null && control.IsAllPropertySet())
            {
                if (!control.IsInitialized)
                    InitializeGrid(control);
            }
        }

        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Wizard;
            control.IsColorSet = true;
            if (control != null && control.IsAllPropertySet())
            {
                if (!control.IsInitialized)
                    InitializeGrid(control);
            }
        }

        private static void OnLineThicknessChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Wizard;
            control.IsLineThicknessSet = true;
            if (control != null && control.IsAllPropertySet())
            {
                if (!control.IsInitialized)
                    InitializeGrid(control);
            }
        }

        private static void OnCircleStepSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Wizard;
            control.IsCircleStepSizeSet = true;
            if (control != null && control.IsAllPropertySet())
            {
                if (!control.IsInitialized)
                    InitializeGrid(control);
            }
        }

        private static void OnStepsLabelsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Wizard;
            control.IsStepsLabelsSet = true;
            if (control != null && control.IsAllPropertySet())
            {
                if (!control.IsInitialized)
                    InitializeGrid(control);
                    InitializeLabelGrid(control);
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if(width > 0)
            {
                LabelsGrid.Padding = new Thickness((width/NumberOfSteps)/4, 0, (width / NumberOfSteps) / 4, 0);
            }
        }

        #endregion

        static void InitializeGrid(Wizard @this)
        {
            @this.CreateGridDefinition();
            @this.AddCircles();
            @this.IsInitialized = true;
        }

        static void InitializeLabelGrid(Wizard @this)
        {
            @this.CreateGridDefinition();
            @this.AddCircles();
            @this.CreateLabelGrid();
            @this.IsInitialized = true;
        }

        void CreateGridDefinition()
        {
            StepsGrid.ColumnDefinitions = new ColumnDefinitionCollection();
            for(int i = 0; i<=this.NumberOfSteps*2-1; i++)
            {
                StepsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            }
        }

        void AddLine(int index)
        {
            var line = GetLine();
            Grid.SetColumn(line, index);
            StepsGrid.Children.Add(line);
        }

        void AddCircles()
        {
            var counter = 0;
            for(int i = 0; i <= StepsGrid.ColumnDefinitions.Count; i++)
            {
                AddLine(i);
                if (i%2 != 0 && i != 0 && counter < this.NumberOfSteps)
                {
                    var state = CircleState.Empty;
                    if (counter < CurrentStep) state = CircleState.Filled;
                    var circle = this.GetCircle(state);
                    Grid.SetColumn(circle, i);
                    StepsGrid.Children.Add(circle);
                    counter++;
                }
            }
        }

        void CreateLabelGrid()
        {
            for(int i = 0; i < NumberOfSteps; i++)
            {
                LabelsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            }

            for (int i = 0; i < NumberOfSteps; i++)
            {
                var text = GetTextForLabel(i);
                var label = GetLabel(text);

                SetColumn(label, i);
                LabelsGrid.Children.Add(label);
            }
        }

        string GetTextForLabel(int index)
        {
            var result = string.Empty;
            if(Labels != null && Labels.Count > 0)
            {
                var text = Labels.ElementAtOrDefault(index);
                result = text ?? string.Empty;
            }

            if (StepsLabels != null && StepsLabels.Count > 0)
            {
                var text = StepsLabels.ElementAtOrDefault(index);
                result = text ?? string.Empty;
            }
            return result;
        }

        Label GetLabel(string text)
        {
            var label = new Label();
            label.VerticalOptions = LayoutOptions.CenterAndExpand;
            label.HorizontalOptions = LayoutOptions.CenterAndExpand;
            label.LineBreakMode = LineBreakMode.WordWrap;
            label.Text = text;
            label.FontFamily = LabelFontFamily;
            label.FontSize = LabelFontSize;
            label.FontAttributes = LabelFontAttributes;
            label.FontSize = CircleStepSize / 2;
            return label;
        }

        BoxView GetLine()
        {
            var line = new BoxView()
            {
                Color = Color,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = new Color(10,10,10),
                HeightRequest = LineThickness,
                Margin = 0,
                WidthRequest = -1
            };
            return line;
        }

        Grid GetCircle(CircleState state)
        {
            var height = CircleStepSize;
            var outlineSize = height;
            var outlineCornerRadius = height / 2;
            var insideSize = height * 0.7;
            var insideCornerRadius = height * 0.7 / 2;


            var outlineCircle = new BoxView()
            {
                WidthRequest = outlineSize,
                HeightRequest = outlineSize,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                CornerRadius = outlineCornerRadius,
                BackgroundColor = Color,
                Margin = 0
            };
            var insideCircle = new BoxView()
            {
                WidthRequest = insideSize,
                HeightRequest = insideSize,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                CornerRadius = insideCornerRadius,
                BackgroundColor = state == CircleState.Filled ? Color : Color.White,
                Margin = 0
            };

            var container = new Grid() { ColumnSpacing = 0, RowSpacing = 0, Padding = 0 };
            container.Children.Add(outlineCircle,0,0);
            container.Children.Add(insideCircle,0,0);

            return container;
        }

        private bool IsAllPropertySet()
        {
            return IsColorSet
                && IsNumberOfStepsSet
                && IsCurrentStepSet
                && IsLineThicknessSet
                && IsCircleStepSizeSet;
        }
    }
}
