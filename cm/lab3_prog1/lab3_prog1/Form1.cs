using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace lab3_prog1
{
    public partial class Form1 : Form
    {
        const int size = 10;

        PointF[] _points = new PointF[]
        {
            new PointF { X = 1f, Y = 0.6f },
            new PointF { X = 2f, Y = 2.3f },
            new PointF { X = 3f, Y = 2.1f },
            new PointF { X = 4f, Y = 3.5f },
            new PointF { X = 5f, Y = 4.2f },
            new PointF { X = 6f, Y = 6.0f },
            new PointF { X = 7f, Y = 7.8f },
            new PointF { X = 8f, Y = 9.2f },
        };

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LagrangeMethod lagrangeMethod = new LagrangeMethod(_points, _points.Length);
            CubeSplainMethod cubeSplainMethod = new CubeSplainMethod();

            cubeSplainMethod.BuildSpline(_points, _points.Length);

            PointPairList lpoints = new PointPairList();
            PointPairList cpoints = new PointPairList();

            for (double i = 0; i < size; i+=0.1)
                lpoints.Add(new PointPair { X = i, Y = lagrangeMethod.Resolve(i) });

            for (double i = 0; i < size; i += 0.1)
                cpoints.Add(new PointPair { X = i, Y = cubeSplainMethod.Interpolate(i) });

            GraphPane myPane = zedGraphControl1.GraphPane;

            //myPane.AddCurve("1.Полиномом в форме Лагранжа", lpoints, Color.Blue, SymbolType.None);

            myPane.AddCurve("2.Кубическими сплайнами", cpoints, Color.Red, SymbolType.None);

            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MinorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;

            zedGraphControl1.AxisChange();
        }
    }
}
