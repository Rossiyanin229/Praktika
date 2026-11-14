using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class FileWriter : IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed = false;

    public FileWriter(string filePath)
    {
      
        _writer = new StreamWriter(filePath);
    }

    public void WriteLine(string text)
    {
        
        if (_disposed)
            throw new ObjectDisposedException(nameof(FileWriter));

        _writer.WriteLine(text);
    }

   
    public void Dispose()
    {
        if (!_disposed)
        {
            _writer?.Dispose();
            _disposed = true;
        }
    }
}
