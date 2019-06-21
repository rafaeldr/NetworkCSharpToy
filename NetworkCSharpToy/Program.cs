using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkCSharpToy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            /*
            int[,] net = NetworkSamples.Sample_closeness;
            int[] eccValues = Algorithms.Centrality.eccentricity(net);
            MessageBox.Show("Excentricidade: "+string.Join(" ", eccValues));

            net = NetworkSamples.Sample_closeness;
            int[] closenessValues = Algorithms.Centrality.closeness(net);
            MessageBox.Show("Closeness: "+string.Join(" ", closenessValues));

            net = NetworkSamples.Sample_eccentricity;
            closenessValues = Algorithms.Centrality.closeness(net);
            MessageBox.Show("Closeness: " + string.Join(" ", closenessValues));

            net = NetworkSamples.ZacharyKarate;
            closenessValues = Algorithms.Centrality.closeness(net);
            MessageBox.Show("Closeness: " + string.Join(" ", closenessValues));

            net = NetworkSamples.Sample_2components;
            closenessValues = Algorithms.Centrality.closeness(net);
            MessageBox.Show("Closeness: " + string.Join(" ", closenessValues));
            */

            int[,] net = NetworkSamples.Sample_Dijkstra;
            int distance = Algorithms.Graph_Classical.dijkstra(net, 0, 3);
            MessageBox.Show("Menor Distância: " + string.Join(" ", distance));
        }
    }
}
