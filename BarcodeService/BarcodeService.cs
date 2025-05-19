using IronBarCode;
using DotNetEnv;

namespace BarcodeService;

public class BarcodeService
{

    BarcodeService()
    {
        Env.Load();
        License.LicenseKey = Env.GetString("IRON_BARCODE_LICENSE_KEY");
    }
    
    static Stream BarcodeGenerator(int data)
    {
        var barcode = BarcodeWriter.CreateBarcode(data.ToString(), BarcodeWriterEncoding.Code128);
        barcode.SaveAsImage("barcodeCode128.jpeg");
        return barcode.BinaryStream;
    }
}