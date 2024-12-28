using BinaryKits.Zpl.Viewer;
using System.Runtime.InteropServices.JavaScript;

return;

public partial class Sample
{
    // Accessible from JS
    [JSExport]
    internal static int Add(int a, int b)
    {
        return a + b;
    }
}

public partial class Lib
{
    // Accessible from JS
    [JSExport]
    internal static byte[] CreateLabel(String a, double h, double w, int pd)
    {
        IPrinterStorage printerStorage = new PrinterStorage();
        var drawer = new ZplElementDrawer(printerStorage);

        var analyzer = new ZplAnalyzer(printerStorage);
        var analyzeInfo = analyzer.Analyze(a);

        var imageData = drawer.Draw(analyzeInfo.LabelInfos[0].ZplElements, h, w, pd); // l, 300, 300, 8

        return imageData;
    }
}