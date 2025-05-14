using IronBarCode;

namespace BarcodeService;

public class BarcodeService
{

    BarcodeService()
    { 
        IronBarCode.License.LicenseKey = "IRONSUITE.THOM689H.EDU.SDE.DK.16949-42B3BF01DB-D55MFI6-K4YEYAGAPAYH-LUHTYZGDJTCY-6RMSGYI56N43-ANOIVNSCJPM4-47S7NCH7RG5X-BD4I766X2JV5-EVPXOK-THR6ZOXJVDGPUA-DEPLOYMENT.TRIAL-XHL7MN.TRIAL.EXPIRES.13.JUN.2025";
        
    }
    
    static Stream BarcodeGenerator(int data)
    {
        var barcode = BarcodeWriter.CreateBarcode(data.ToString(), BarcodeWriterEncoding.Code128);
        barcode.SaveAsImage("barcodeCode128.jpeg");
        return barcode.BinaryStream;
    }
}