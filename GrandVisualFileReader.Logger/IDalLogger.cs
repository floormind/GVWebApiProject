using System;

namespace GrandVisualFileReader.Logger
{
    // This is here for future proof
    // another logger framework or class may be used
    // extend this interface and use the interface.
    public interface IDalLogger
    {
        void LogError(Exception ex);
    }
}
