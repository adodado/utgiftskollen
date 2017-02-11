#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Finances.NET.Core.Accounts;
using ZedGraph;

#endregion

namespace Finances.NET.Pie.Plugin
{
    /// <summary>
    /// Class FrmPieChart.
    /// </summary>
    public partial class FrmPieChart : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmPieChart" /> class.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="language">The language.</param>
        public FrmPieChart(Account account, string language)
        {
            InitializeComponent();
            PieChartPlot(account, language);
        }

        /// <summary>
        /// Piechart plot for the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="language">The current application language.</param>
        public void PieChartPlot(Account account, string language)
        {
            var a = zg1.GraphPane;
            zg1.Visible = false;

            zg1.GraphPane.GraphObjList.Clear();

            a.CurveList.Clear();
            switch (language)
            {
                case "de-DE":
                    a.Title.Text = "Kontos : " + account.Name;
                    break;
                case "en-US":
                    a.Title.Text = "Account : " + account.Name;
                    break;
                default:
                    a.Title.Text = "Konto : " + account.Name;
                    break;
            }
            a.Title.FontSpec.StringAlignment = StringAlignment.Center;
            a.Title.FontSpec.Family = "Segoe UI Semilight";
            a.Title.FontSpec.Size = 21.75f;

            a.Fill = new Fill(SystemColors.Control);

            a.Chart.Fill.Type = FillType.None;

            a.Legend.Position = LegendPos.Float;
            a.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            a.Legend.FontSpec.Family = "Segoe UI";
            a.Legend.FontSpec.Size = 9f;
            a.Legend.IsHStack = false;

            var nb_seg = account.Operations.Count;
            var segs = new PieItem[nb_seg];


            var rnd = new Random();

            var totalC = new Dictionary<string, decimal>();
            var totalD = new Dictionary<string, decimal>();

            account.Operations.All(x =>
            {
                if (!totalC.ContainsKey(x.Budget))
                    totalC.Add(x.Budget, 0);
                if (!totalD.ContainsKey(x.Budget))
                    totalD.Add(x.Budget, 0);

                totalC[x.Budget] += x.Credit;
                totalD[x.Budget] += x.Debit;
                return true;
            });

            var ls = new List<string>();

            totalC.Where(x => x.Value == 0).All(x =>
            {
                ls.Add(x.Key);
                return true;
            });
            ls.ForEach(x => totalC.Remove(x));
            ls.Clear();

            totalD.Where(x => x.Value == 0).All(x =>
            {
                ls.Add(x.Key);
                return true;
            });
            ls.ForEach(x => totalD.Remove(x));
            ls.Clear();

            totalC.All(x =>
            {
                a.AddPieSlice(Convert.ToDouble(x.Value), Color.FromArgb(255, rnd.Next(0, 150), 255, rnd.Next(0, 150)),
                    Color.White, 45.0f, 0, x.Key);
                return true;
            });
            totalD.All(x =>
            {
                a.AddPieSlice(Convert.ToDouble(x.Value), Color.FromArgb(255, 255, rnd.Next(0, 150), rnd.Next(0, 150)),
                    Color.White, 45.0f, 0, x.Key);
                return true;
            });

            zg1.IsShowPointValues = true;
            zg1.AxisChange();
            zg1.Refresh();
            zg1.Visible = true;
        }
    }
}