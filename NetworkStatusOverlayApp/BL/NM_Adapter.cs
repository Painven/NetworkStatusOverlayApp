using System.Diagnostics;

namespace NetworkStatusOverlayApp.BL;
public class NM_Adapter
{

    internal NM_Adapter(string strName)
    {
        strAdapterName = strName;
    }

    private long lngDownloadSpeed;
    private long lngUploadSpeed;
    private long lngDownloadValue;
    private long lngUploadValue;
    private long lngOldDownloadValue;
    private long lngOldUploadValue;

    internal string strAdapterName;
    internal PerformanceCounter pcDownloadCounter;
    internal PerformanceCounter pcUploadCounter;

    internal void Initialize()
    {
        lngOldDownloadValue = pcDownloadCounter.NextSample().RawValue;
        lngOldUploadValue = pcUploadCounter.NextSample().RawValue;
    }

    internal void Update()
    {
        lngDownloadValue = pcDownloadCounter.NextSample().RawValue;
        lngUploadValue = pcUploadCounter.NextSample().RawValue;

        lngDownloadSpeed = lngDownloadValue - lngOldDownloadValue;
        lngUploadSpeed = lngUploadValue - lngOldUploadValue;

        lngOldDownloadValue = lngDownloadValue;
        lngOldUploadValue = lngUploadValue;
    }

    public override string ToString()
    {
        return this.strAdapterName;
    }

    public string AdapterName
    {
        get
        {
            return strAdapterName;
        }
    }

    public long DownloadSpeed
    {
        get
        {
            return lngDownloadSpeed;
        }
    }

    public long UploadSpeed
    {
        get
        {
            return lngUploadSpeed;
        }
    }

    public double DownloadSpeedKbps
    {
        get
        {
            return lngDownloadSpeed / 1024.0;
        }
    }

    public double UploadSpeedKbps
    {
        get
        {
            return lngUploadSpeed / 1024.0;
        }
    }
}
