using System;
using System.Collections.Generic;
using System.Text;
using DownloadManager.Abstract;

namespace DownloadManager
{
    public class DownloadJob
    {
        private readonly IDownloadOperation _downloadOperation;

        public DownloadJob(IDownloadOperation downloadOperation)
        {
            _downloadOperation = downloadOperation;
        }

        public void Start()
        {
            _downloadOperation.Download();
        }

        public void Strop()
        {

        }
    }
}
