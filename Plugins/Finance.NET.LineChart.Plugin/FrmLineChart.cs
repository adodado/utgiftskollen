#region

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Finances.NET.Core.Accounts;
using ZedGraph;

#endregion

namespace Finances.NET.LineChart.Plugin
{
    /// <summary>
    /// Class FrmLineChart.
    /// </summary>
    public partial class FrmLineChart : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmLineChart" /> class.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="language">The language.</param>
        public FrmLineChart(Account account, string language)
        {
            InitializeComponent();
            LineChartPlot(account, language);
        }

        /// <summary>
        /// LineChart plot the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="language">The current application language.</param>
        public void LineChartPlot(Account account, string language)
        {
            var a = zg1.GraphPane;
            zg1.Visible = false;

            zg1.GraphPane.GraphObjList.Clear();

            a.LineType = LineType.Normal;
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
            a.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            switch (language)
            {
                case "de-DE":
                    a.XAxis.Title.Text = "Datum";
                    break;
                default:
                    a.XAxis.Title.Text = "Date";
                    break;
            }
            a.XAxis.Title.FontSpec.Family = "Segoe UI";
            a.XAxis.Title.FontSpec.Size = 9f;
            a.XAxis.Type = AxisType.Date;
            a.XAxis.Scale.MajorUnit = DateUnit.Month;
            a.XAxis.Scale.MinorUnit = DateUnit.Day;
            a.XAxis.MajorGrid.IsVisible = true;
            a.XAxis.MajorGrid.PenWidth = 1;
            a.XAxis.MajorGrid.DashOn = 2;
            a.XAxis.MajorGrid.DashOff = 2;
            a.XAxis.MinorGrid.IsVisible = true;
            a.XAxis.MajorTic.Size = 10;
            a.XAxis.IsVisible = true;

            switch (language)
            {
                case "de-DE":
                    a.YAxis.Title.Text = "Kontostand (" + account.Currency.Symbol + ")";
                    break;
                case "en-US":
                    a.YAxis.Title.Text = "Balance (" + account.Currency.Symbol + ")";
                    break;
                default:
                    a.YAxis.Title.Text = "Konto saldo (" + account.Currency.Symbol + ")";
                    break;
            }
            a.YAxis.Title.FontSpec.Family = "Segoe UI";
            a.YAxis.Title.FontSpec.Size = 9f;
            a.YAxis.MajorGrid.Color = Color.Black;
            a.YAxis.MajorGrid.IsVisible = true;
            a.YAxis.Scale.FontSpec.FontColor = Color.Black;
            a.YAxis.Title.FontSpec.FontColor = Color.Black;
            a.YAxis.MajorTic.IsOpposite = false;
            a.YAxis.MinorTic.IsOpposite = false;
            a.YAxis.MajorGrid.IsZeroLine = true;
            a.YAxis.Scale.Align = AlignP.Inside;
            a.YAxis.MajorGrid.IsVisible = true;
            a.YAxis.IsVisible = true;


            var crP = new PointPairList();
            decimal Xp = 0;

            foreach (var t in account.Operations)
            {
                if (t.Credit > 0) Xp += t.Credit;
                if (t.Debit > 0) Xp -= t.Debit;

                crP.Add(t.Date.ToOADate(), (double) Xp);
            }

            LineItem cr; // = a.AddCurve("solde", crP, Color.Red, SymbolType.XCross);
            switch (language)
            {
                case "de-DE":
                    cr = a.AddCurve("kontostand", crP, Color.Red, SymbolType.XCross);
                    break;
                case "en-US":
                    cr = a.AddCurve("balance", crP, Color.Red, SymbolType.XCross);
                    break;
                default:
                    cr = a.AddCurve("saldo", crP, Color.Red, SymbolType.XCross);
                    break;
            }

            zg1.PointDateFormat = "dd/MM";
            zg1.IsShowPointValues = true;

            a.YAxis.Scale.MinAuto = true;
            a.YAxis.Scale.MaxAuto = true;

            a.XAxis.Scale.Min = account.Operations.First().Date.ToOADate();
            a.XAxis.Scale.Max = DateTime.Now.ToOADate();

            zg1.AxisChange();
            zg1.Visible = true;
        }
    }
}